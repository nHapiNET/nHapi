namespace NHapi.SourceGeneration;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public static class FileAbstraction
{
    private static readonly Action<string, byte[]> DefaultWriteAllBytesImplementation =
        (filePath, bytes) =>
        {
            using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(bytes, 0, bytes.Length);
        };

    private static readonly Func<string, byte[], CancellationToken, Task> DefaultWriteAllBytesAsyncImplementation =
        async (filePath, bytes, cancellationToken) =>
        {
            using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            await fileStream.WriteAsync(bytes, 0, bytes.Length, cancellationToken).ConfigureAwait(false);
        };

    private static Action<string, byte[]> writeAllBytesImplementation;

    private static Func<string, byte[], CancellationToken, Task> writeAllBytesAsyncImplementation;

    /// <summary>
    /// Sets the implementation of <see cref="WriteAllBytes"/>.
    /// </summary>
    /// <param name="writeAllBytes">Implementation of <see cref="WriteAllBytes"/>.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="writeAllBytes" /> is null.</exception>
    public static void UsingImplementation(Action<string, byte[]> writeAllBytes)
    {
        FileAbstraction.writeAllBytesImplementation =
            writeAllBytes ?? throw new ArgumentNullException(nameof(writeAllBytes));
    }

    /// <summary>
    /// Sets the implementation of <see cref="WriteAllBytesAsync(string, byte[], CancellationToken)"/>.
    /// </summary>
    /// <param name="writeAllBytesAsync">Implementation of <see cref="WriteAllBytesAsync(string, byte[], CancellationToken)"/>.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="writeAllBytesAsync" /> is null.</exception>
    public static void UsingImplementation(Func<string, byte[], CancellationToken, Task> writeAllBytesAsync)
    {
        FileAbstraction.writeAllBytesAsyncImplementation =
            writeAllBytesAsync ?? throw new ArgumentNullException(nameof(writeAllBytesAsync));
    }

    /// <summary>
    /// Creates a new file, writes the specified byte array to the file, and then closes the file.
    /// If the target file already exists, it is overwritten.
    /// </summary>
    /// <param name="filePath">The file to write to.</param>
    /// <param name="bytes">The bytes to write to the file.</param>
    public static void WriteAllBytes(string filePath, byte[] bytes)
    {
        (writeAllBytesImplementation ?? DefaultWriteAllBytesImplementation)(filePath, bytes);
    }

    /// <summary>
    /// Asynchronously creates a new file, writes the specified byte array to the file, and then closes the file.
    /// If the target file already exists, it is overwritten.
    /// </summary>
    /// <param name="filePath">The file to write to.</param>
    /// <param name="bytes">The bytes to write to the file.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static async Task WriteAllBytesAsync(string filePath, byte[] bytes)
    {
        await (writeAllBytesAsyncImplementation ??
               DefaultWriteAllBytesAsyncImplementation)(filePath, bytes, default).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously creates a new file, writes the specified byte array to the file, and then closes the file.
    /// If the target file already exists, it is overwritten.
    /// </summary>
    /// <param name="filePath">The file to write to.</param>
    /// <param name="bytes">The bytes to write to the file.</param>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests.
    /// The default value is <see cref="P:System.Threading.CancellationToken.None" />.
    /// </param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public static async Task WriteAllBytesAsync(
        string filePath,
        byte[] bytes,
        CancellationToken cancellationToken)
    {
        await (writeAllBytesAsyncImplementation ??
               DefaultWriteAllBytesAsyncImplementation)(filePath, bytes, cancellationToken)
            .ConfigureAwait(false);
    }
}