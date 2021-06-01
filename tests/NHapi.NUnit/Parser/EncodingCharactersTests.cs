namespace NHapi.NUnit.Parser
{
    using global::NUnit.Framework;

    using NHapi.Base;
    using NHapi.Base.Parser;
    using NHapi.Base.Util;

    [TestFixture]
    public class EncodingCharactersTests
    {
        [TestCase('|', "^~\\&")]
        [TestCase('?', "]@/$")]
        [TestCase('>', "\"£^*")]
        public void Constructor_ValidInput_ReturnsExpectedResult(char fieldSeperator, string encodingCharacters)
        {
            // Arrange / Act
            var sut = new EncodingCharacters(fieldSeperator, encodingCharacters);

            // Assert
            Assert.AreEqual(fieldSeperator, sut.FieldSeparator);
            Assert.AreEqual(encodingCharacters[0], sut.ComponentSeparator);
            Assert.AreEqual(encodingCharacters[1], sut.RepetitionSeparator);
            Assert.AreEqual(encodingCharacters[2], sut.EscapeCharacter);
            Assert.AreEqual(encodingCharacters[3], sut.SubcomponentSeparator);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("\r")]
        [TestCase("\t")]
        [TestCase("\n")]
        [TestCase(" ")]
        public void Constructor_EncodingCharactersAreNullEmptyOrWhiteSpace_SetsDefaultValues(string encodingCharacters)
        {
            // Arrange / Act
            var sut = new EncodingCharacters('|', encodingCharacters);

            // Assert
            Assert.AreEqual('|', sut.FieldSeparator);
            Assert.AreEqual('^', sut.ComponentSeparator);
            Assert.AreEqual('~', sut.RepetitionSeparator);
            Assert.AreEqual('\\', sut.EscapeCharacter);
            Assert.AreEqual('&', sut.SubcomponentSeparator);
        }

        [TestCase("^~\\ ")]
        [TestCase("]@/\t")]
        [TestCase("\"£\n*")]
        [TestCase("\"\r£*")]
        [TestCase("\"\0£*")]
        public void Constructor_EncodingCharactersContainWhiteSpaceCharactersOrNullCharacter_ThrowsHl7Exception(string encodingCharacters)
        {
            // Arrange / Act / Assert
            Assert.Throws<HL7Exception>(
                () => new EncodingCharacters('|', encodingCharacters));
        }

        [TestCase("^^^^")]
        [TestCase("~~~~")]
        [TestCase("^~\\\\")]
        [TestCase("^\\&&")]
        [TestCase("0000")]
        [TestCase("@#$$")]
        [TestCase("****")]
        public void Constructor_EncodingCharactersAreNotUnique_ThrowsHl7Exception(string encodingCharacters)
        {
            // Arrange / Act / Assert
            Assert.Throws<HL7Exception>(
                () => new EncodingCharacters('|', encodingCharacters));
        }

        [TestCase(' ')]
        [TestCase('\r')]
        [TestCase('\n')]
        [TestCase('\t')]
        [TestCase('\0')]
        public void Constructor_FieldSeperatorIsWhiteSpaceOrNullCharacter_ThrowsHl7Exception(char fieldSeperator)
        {
            // Arrange / Act / Assert
            Assert.Throws<HL7Exception>(
                () => new EncodingCharacters(fieldSeperator, "^~\\&"));
        }

        [TestCase('|', '^', '~', '\\', '&')]
        [TestCase('?', ']', '@', '/', '$')]
        [TestCase('>', '\\', '£', '^', '*')]
        public void Constructor_ValidInput_ReturnsExpectedResult(
            char fieldSeperator, char componentSeperator, char repetitionSeperator, char escapeCharacter, char subcomponentSeperator)
        {
            // Arrange / Act
            var sut = new EncodingCharacters(fieldSeperator, componentSeperator, repetitionSeperator, escapeCharacter, subcomponentSeperator);

            // Assert
            Assert.AreEqual(fieldSeperator, sut.FieldSeparator);
            Assert.AreEqual(componentSeperator, sut.ComponentSeparator);
            Assert.AreEqual(repetitionSeperator, sut.RepetitionSeparator);
            Assert.AreEqual(escapeCharacter, sut.EscapeCharacter);
            Assert.AreEqual(subcomponentSeperator, sut.SubcomponentSeparator);
        }

        [Test]
        [TestCaseSource(nameof(EncodingCharactersConstructorTestData))]
        public void Constructor_ValidInput_ReturnsExpectedResult(EncodingCharacters input)
        {
            // Arrange / Act
            var sut = new EncodingCharacters(input);

            // Assert
            Assert.AreEqual(input.FieldSeparator, sut.FieldSeparator);
            Assert.AreEqual(input.ComponentSeparator, sut.ComponentSeparator);
            Assert.AreEqual(input.RepetitionSeparator, sut.RepetitionSeparator);
            Assert.AreEqual(input.EscapeCharacter, sut.EscapeCharacter);
            Assert.AreEqual(input.SubcomponentSeparator, sut.SubcomponentSeparator);
        }

        [Test]
        public void ToString_ReturnsEncodingCharactersWithoutFieldSeperator()
        {
            // Arrange
            var encodingCharacters = "^~\\&";
            var sut = new EncodingCharacters('|', encodingCharacters);

            // Act
            var result = sut.ToString();

            // Assert
            Assert.AreEqual(encodingCharacters, result);
        }

        [TestCase('|', "^~\\&")]
        [TestCase('?', "]@/$")]
        [TestCase('>', "\"£^*")]
        public void Clone_ReturnsClonesInstanceEncodingCharacters(char fieldSeperator, string encodingCharacters)
        {
            // Arrange
            var sut = new EncodingCharacters(fieldSeperator, encodingCharacters);

            // Act
            var clone = sut.Clone();

            // Assert
            Assert.AreEqual(sut, clone);
        }

        [Test]
        public void FromMessage_NoEncodingCharactersInMessage_ThrowsHl7Exception()
        {
            // Arrange
            var input = "MSH|^~\\&|sys1|sys1|sys2|sys2|20180503174921||ORM^O01|1234567890|P|2.3\r"
                        + "PID|||1^^^XXX~2^^^YYY||LastName^FirstName||19660429|F\r"
                        + "PV1||I|3906||||||||||||||||100001\r"
                        + "ORC|CA|1410|3121||CA\r"
                        + "OBR|1|1410|3121|RX50^ADDOME SUPINO";

            var parser = new PipeParser();
            var message = parser.Parse(input);
            var terser = new Terser(message);

            terser.Set("MSH-2", null);

            // Action / Assert
            Assert.Throws<HL7Exception>(
                () => EncodingCharacters.FromMessage(message));
        }

        [Test]
        public void FromMessage_NoFieldSeperatorCharacterInMessage_ThrowsHl7Exception()
        {
            // Arrange
            var input = "MSH|^~\\&|sys1|sys1|sys2|sys2|20180503174921||ORM^O01|1234567890|P|2.3\r"
                        + "PID|||1^^^XXX~2^^^YYY||LastName^FirstName||19660429|F\r"
                        + "PV1||I|3906||||||||||||||||100001\r"
                        + "ORC|CA|1410|3121||CA\r"
                        + "OBR|1|1410|3121|RX50^ADDOME SUPINO";

            var parser = new PipeParser();
            var message = parser.Parse(input);
            var terser = new Terser(message);

            terser.Set("MSH-1", null);

            // Action / Assert
            Assert.Throws<HL7Exception>(
                () => EncodingCharacters.FromMessage(message));
        }

        [TestCase('|', "^~\\&")]
        [TestCase('?', "]@/$")]
        [TestCase('>', "\"£^*")]
        public void FromMessage_EncodingCharactersInMessage_ReturnsExpectedResult(char fieldSeperator, string encodingCharacters)
        {
            // Arrange
            var input = "MSH|{0}|sys1|sys1|sys2|sys2|20180503174921||ORM^O01|1234567890|P|2.3\r"
                          + "PID|||1^^^XXX~2^^^YYY||LastName^FirstName||19660429|F\r"
                          + "PV1||I|3906||||||||||||||||100001\r"
                          + "ORC|CA|1410|3121||CA\r"
                          + "OBR|1|1410|3121|RX50^ADDOME SUPINO";

            input =
                input.Replace('|', fieldSeperator)
                    .Replace('^', encodingCharacters[0]);

            input = string.Format(input, encodingCharacters);

            var parser = new PipeParser();
            var message = parser.Parse(input);

            var expected = new EncodingCharacters(fieldSeperator, encodingCharacters);

            // Act
            var actual = EncodingCharacters.FromMessage(message);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] EncodingCharactersConstructorTestData =
        {
            new object[] { new EncodingCharacters('|', "^~\\&") },
            new object[] { new EncodingCharacters('?', "]@/$") },
            new object[] { new EncodingCharacters('>', "\"£^*") },
        };
    }
}
