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

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(sut.FieldSeparator, Is.EqualTo(fieldSeperator));
                Assert.That(sut.ComponentSeparator, Is.EqualTo(encodingCharacters[0]));
                Assert.That(sut.RepetitionSeparator, Is.EqualTo(encodingCharacters[1]));
                Assert.That(sut.EscapeCharacter, Is.EqualTo(encodingCharacters[2]));
                Assert.That(sut.SubcomponentSeparator, Is.EqualTo(encodingCharacters[3]));
            });
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

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(sut.FieldSeparator, Is.EqualTo('|'));
                Assert.That(sut.ComponentSeparator, Is.EqualTo('^'));
                Assert.That(sut.RepetitionSeparator, Is.EqualTo('~'));
                Assert.That(sut.EscapeCharacter, Is.EqualTo('\\'));
                Assert.That(sut.SubcomponentSeparator, Is.EqualTo('&'));
            });
        }

        [TestCase("^~\\ ")]
        [TestCase("]@/\t")]
        [TestCase("\"£\n*")]
        [TestCase("\"\r£*")]
        [TestCase("\"\0£*")]
        public void Constructor_EncodingCharactersContainWhiteSpaceCharactersOrNullCharacter_ThrowsHl7Exception(string encodingCharacters)
        {
            // Arrange / Act / Assert
            Assert.That(
                () => new EncodingCharacters('|', encodingCharacters),
                Throws.TypeOf<HL7Exception>());
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
            Assert.That(
                () => new EncodingCharacters('|', encodingCharacters),
                Throws.TypeOf<HL7Exception>());
        }

        [TestCase(' ')]
        [TestCase('\r')]
        [TestCase('\n')]
        [TestCase('\t')]
        [TestCase('\0')]
        public void Constructor_FieldSeperatorIsWhiteSpaceOrNullCharacter_ThrowsHl7Exception(char fieldSeperator)
        {
            // Arrange / Act / Assert
            Assert.That(
                () => new EncodingCharacters(fieldSeperator, "^~\\&"),
                Throws.TypeOf<HL7Exception>());
        }

        [TestCase('|', '^', '~', '\\', '&')]
        [TestCase('?', ']', '@', '/', '$')]
        [TestCase('>', '\\', '£', '^', '*')]
        public void Constructor_ValidInput_ReturnsExpectedResult(
            char fieldSeperator, char componentSeperator, char repetitionSeperator, char escapeCharacter, char subcomponentSeperator)
        {
            // Arrange / Act
            var sut = new EncodingCharacters(fieldSeperator, componentSeperator, repetitionSeperator, escapeCharacter, subcomponentSeperator);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(sut.FieldSeparator, Is.EqualTo(fieldSeperator));
                Assert.That(sut.ComponentSeparator, Is.EqualTo(componentSeperator));
                Assert.That(sut.RepetitionSeparator, Is.EqualTo(repetitionSeperator));
                Assert.That(sut.EscapeCharacter, Is.EqualTo(escapeCharacter));
                Assert.That(sut.SubcomponentSeparator, Is.EqualTo(subcomponentSeperator));
            });
        }

        [Test]
        [TestCaseSource(nameof(EncodingCharactersConstructorTestData))]
        public void Constructor_ValidInput_ReturnsExpectedResult(EncodingCharacters input)
        {
            // Arrange / Act
            var sut = new EncodingCharacters(input);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(sut.FieldSeparator, Is.EqualTo(input.FieldSeparator));
                Assert.That(sut.ComponentSeparator, Is.EqualTo(input.ComponentSeparator));
                Assert.That(sut.RepetitionSeparator, Is.EqualTo(input.RepetitionSeparator));
                Assert.That(sut.EscapeCharacter, Is.EqualTo(input.EscapeCharacter));
                Assert.That(sut.SubcomponentSeparator, Is.EqualTo(input.SubcomponentSeparator));
            });
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
            Assert.That(result, Is.EqualTo(encodingCharacters));
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
            Assert.That(clone, Is.EqualTo(sut));
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
            Assert.That(
                () => EncodingCharacters.FromMessage(message),
                Throws.TypeOf<HL7Exception>());
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
            Assert.That(
                () => EncodingCharacters.FromMessage(message),
                Throws.TypeOf<HL7Exception>());
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
            Assert.That(actual, Is.EqualTo(expected));
        }

        private static readonly object[] EncodingCharactersConstructorTestData =
        {
            new object[] { new EncodingCharacters('|', "^~\\&") },
            new object[] { new EncodingCharacters('?', "]@/$") },
            new object[] { new EncodingCharacters('>', "\"£^*") },
        };
    }
}