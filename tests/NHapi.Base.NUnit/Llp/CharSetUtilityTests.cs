namespace NHapi.Base.NUnit.Llp
{
    using System;
    using System.Text;

    using global::NUnit.Framework;

    using NHapi.Base.Llp;

    [TestFixture]
    public class CharSetUtilityTests
    {
#if NET6_0_OR_GREATER
        public CharSetUtilityTests()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
#endif

        [TestCase("random")]
        [TestCase("not supported")]
        [TestCase("doesnt exist")]
        [TestCase("bdba4f1a-4984-4c78-ba02-48c3fdaca4d2")]
        [TestCase("##}}{}{}DANGER##}{{}")]
        public void CheckCharset_WhenEncodingNotSupportByHl7Specification_ReturnsDefaultEncoding(string hl7CharSet)
        {
            // Arrange
            var message =
                $"MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.3|||AL|||{hl7CharSet}\r"
                + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
                + "ORC|||||F\r"
                + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
                + "OBX|1||||STValue||||||F\r";

            // Act
            var result = CharSetUtility.CheckCharset(message);

            // Assert
            Assert.AreEqual("us-ascii", result.BodyName);
        }

        [TestCase("ISO IR6")]
        [TestCase("ISO IR14")]
        [TestCase("ISO IR87")]
        [TestCase("ISO IR159")]
        [TestCase("CNS 11643-1992")]
        public void CheckCharset_WhenEncodingNotSupportByPlatform_ThrowsArgumentException(string hl7CharSet)
        {
            // Arrange
            var message =
                $"MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.3|||AL|||{hl7CharSet}\r"
                + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
                + "ORC|||||F\r"
                + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
                + "OBX|1||||STValue||||||F\r";

            // Act / Assert
            Assert.Throws<ArgumentException>(() => CharSetUtility.CheckCharset(message));
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
            // Arrange
            var message =
                $"MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.3|||AL|||{hl7CharSet}\r"
                + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
                + "ORC|||||F\r"
                + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
                + "OBX|1||||STValue||||||F\r";

            // Act
            var result = CharSetUtility.CheckCharset(message);

            // Assert
            Assert.AreEqual(expectedDotnetEncoding, result.BodyName);
        }
    }
}