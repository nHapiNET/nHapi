namespace NHapi.Base.NUnit.Llp
{
    using System;
    using System.Text;

    using global::NUnit.Framework;

    using NHapi.Base.Llp;
    using NHapi.Base.Parser;

    [TestFixture]
    public class Hl7CharSetsTests
    {
#if NET6_0_OR_GREATER
        public Hl7CharSetsTests()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
#endif

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void FromHl7Encoding_InputIsNullEmptyOrWhiteSpace_ThrowsArgumentException(string input)
        {
            // Arrange / Act / Assert
            Assert.Throws<ArgumentException>(() => Hl7CharSets.FromHl7Encoding(input));
        }

        [TestCase("UNKNOWN")]
        [TestCase("NOT NOWN")]
        [TestCase("KLJHJKLHHKLJ")]
        public void FromHl7Encoding_InputIsNotKnownOrMapped_ThrowsEncodingNotSupportedException(string input)
        {
            // Arrange / Act / Assert
            Assert.Throws<EncodingNotSupportedException>(() => Hl7CharSets.FromHl7Encoding(input));
        }

        [TestCase("ISO IR6")]
        [TestCase("ISO IR14")]
        [TestCase("ISO IR87")]
        [TestCase("ISO IR159")]
        [TestCase("CNS 11643-1992")]
        public void CheckCharset_WhenEncodingNotSupportByPlatform_ThrowsArgumentException(string hl7CharSet)
        {
            // Arrange / Act / Assert
            Assert.Throws<ArgumentException>(() => Hl7CharSets.FromHl7Encoding(hl7CharSet));
        }

        [TestCase("ASCII", "us-ascii")] // ASCII
        [TestCase("8859/1", "iso-8859-1")] // Western European (ISO)
        [TestCase("8859/2", "iso-8859-2")] // Central European (ISO)
        [TestCase("8859/3", "iso-8859-3")] // Latin 3 (ISO)
        [TestCase("8859/4", "iso-8859-4")] // Baltic (ISO)
        [TestCase("8859/5", "iso-8859-5")] // Cyrillic (ISO)
        [TestCase("8859/6", "iso-8859-6")] // Arabic (ISO)
        [TestCase("8859/7", "iso-8859-7")] // Greek (ISO)
        [TestCase("8859/8", "iso-8859-8")] // Hebrew (ISO-Visual)
        [TestCase("8859/9", "iso-8859-9")] // Turkish (ISO)
        [TestCase("8859/15", "iso-8859-15")] // Latin 9 (ISO)
#if NET6_0_OR_GREATER
        [TestCase("GB 18030-2000", "gb18030")] // Chinese Simplified (GB18030)
#elif NETFRAMEWORK
        [TestCase("GB 18030-2000", "GB18030")] // Chinese Simplified (GB18030)
#endif
        [TestCase("KS X 1001", "euc-kr")] // Korean (EUC)
        [TestCase("BIG-5", "big5")] // Chinese Traditional (Big5)
        [TestCase("UNICODE", "utf-8")]
        [TestCase("UNICODE UTF-8", "utf-8")] // Unicode (UTF-8)
        [TestCase("UNICODE UTF-16", "utf-16")] // Unicode
        [TestCase("UNICODE UTF-32", "utf-32")] // Unicode (UTF-32)
        public void CheckCharset_WhenEncodingSupportByPlatform_ReturnsExpectedEncoding(string hl7CharSet, string expectedDotnetEncoding)
        {
            // Arrange / Act
            var result = Hl7CharSets.FromHl7Encoding(hl7CharSet);

            // Assert
            Assert.AreEqual(expectedDotnetEncoding, result.BodyName);
        }
    }
}