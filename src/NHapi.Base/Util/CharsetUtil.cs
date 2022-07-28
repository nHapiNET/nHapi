namespace NHapi.Base.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CharsetUtil
    {
        private static readonly List<Bom> Boms = new()
        {
            new Bom(new byte[] { }, Encoding.ASCII),
            new Bom(new byte[] { 0xEF, 0xBB, 0xBF }, Encoding.UTF8),
            new Bom(new byte[] { 0xFF, 0xFE }, Encoding.Unicode), // UTF-16LE
            new Bom(new byte[] { 0xFE, 0xFF, 0xBF }, Encoding.BigEndianUnicode), // UTF-16BE
            new Bom(new byte[] { 0xFF, 0xFE, 0x00, 0x00 }, Encoding.UTF32), // UTF-32LE
            new Bom(new byte[] { 0x00, 0x00, 0xFE, 0xFF }, new UTF32Encoding(true, true)), // UTF-32BE
        };

        public static Encoding CheckCharset(byte[] messageBytes, Encoding fallbackEncoding)
        {
            var messageString = SkipBom(messageBytes);
            return CheckCharset(messageString, fallbackEncoding);
        }

        public static Encoding CheckCharset(string messageString, Encoding fallbackEncoding)
        {
            throw NotImplementedException();
        }

        public static byte[] WithoutBom(byte[] messageBytes)
        {
            var bom = GetBom(messageBytes);
            return messageBytes.Skip(bom.BomBytes.Length).ToArray();
        }

        private static string SkipBom(byte[] messageBytes)
        {
            var bom = GetBom(messageBytes);
            var encoding = bom.Encoding;
            var messageBytesWithoutBom = messageBytes.Skip(bom.BomBytes.Length).ToArray();
            return encoding.GetString(messageBytesWithoutBom);
        }

        private static Bom GetBom(byte[] messageBytes)
        {
            if (messageBytes == null)
            {
                return Boms[0];
            }

            foreach (var bom in Boms)
            {
                var messageBomBytes = messageBytes.Take(bom.BomBytes.Length);
                if (bom.BomBytes.SequenceEqual(messageBomBytes))
                {
                    return bom;
                }
            }

            return Boms[0];
        }

        private class Bom
        {
            public Bom(byte[] bomBytes, Encoding encoding)
            {
                BomBytes = bomBytes;
                Encoding = encoding;
            }

            public byte[] BomBytes { get; }

            public Encoding Encoding { get; }
        }
    }

    public static class PreParser
    {
        public static string GetFields(string message, params string[] fields)
        {
            throw new NotImplementedException();
        }
    }
}