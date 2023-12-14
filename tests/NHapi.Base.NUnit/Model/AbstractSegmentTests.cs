﻿namespace NHapi.Base.NUnit.Model
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Model.V22.Message;
    using NHapi.Model.V24.Segment;

    [TestFixture]
    public class AbstractSegmentTests
    {
        [Test]
        public void TestEnsureEnoughFields()
        {
            // Arrange
            var factory = new DefaultModelClassFactory();
            var msh = new MSH(new GenericMessage.V25(factory), factory);
            var n = msh.NumFields();

            // Act
            msh.GetField(n + 3, 0);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(msh.GetField(n + 1, 0).GetType(), Is.EqualTo(typeof(Varies)));
                Assert.That(msh.GetField(n + 2, 0).GetType(), Is.EqualTo(typeof(Varies)));
                Assert.That(msh.GetField(n + 3, 0).GetType(), Is.EqualTo(typeof(Varies)));
            });
        }

        [Test]
        public void TestUnexpectedFieldReps()
        {
            // Arrange
            var factory = new DefaultModelClassFactory();
            var msh = new MSH(new GenericMessage.V25(factory), new DefaultModelClassFactory());

            // Act
            msh.GetField(1, 0);
            msh.GetField(1, 1);

            // Assert
            Assert.That(msh.GetField(1).Length, Is.EqualTo(2));
        }

        [Test]
        [Ignore("This is the behaviour of Hapi when using the Parse method on AbstractSegment which nhapi doesn't have.")]
        public void TestParseEmpty()
        {
            // Arrange
            var input = "MSH|^~\\&|LABGL1||DMCRES||19951002185200||ADT^A01|LABGL1199510021852632|P|2.2\r"
                        + "PID|||T12345||TEST^PATIENT^P||19601002|M||||||||||123456\r"
                        + "PV1|||NER|||||||GSU||||||||E||||||||||||||||||||||||||19951002174900|19951006\r";

            var expected = "MSH|^~\\&|LABGL1||DMCRES||19951002185200||ADT^A01|LABGL1199510021852632|P|2.2\r"
                           + "PV1|||NER|||||||GSU||||||||E||||||||||||||||||||||||||19951002174900|19951006\r";

            var parser = new PipeParser();

            var a01 = new ADT_A01();
            parser.Parse(a01, input);

            Assert.That(parser.Encode(a01), Is.EqualTo(input));

            // Act
            parser.Parse(a01.PID, "PID", EncodingCharacters.FromMessage(a01));

            // Assert
            Assert.That(parser.Encode(a01), Is.EqualTo(expected));
        }

        [Test]
        [Ignore("This is the behaviour of Hapi when using the Parse method on AbstractSegment which nhapi doesn't have.")]
        public void TestParseNull()
        {
            // Arrange
            var input = "MSH|^~\\&|LABGL1||DMCRES||19951002185200||ADT^A01|LABGL1199510021852632|P|2.2\r"
                        + "PID|||T12345||TEST^PATIENT^P||19601002|M||||||||||123456\r"
                        + "PV1|||NER|||||||GSU||||||||E||||||||||||||||||||||||||19951002174900|19951006\r";

            var parser = new PipeParser();
            var a01 = new ADT_A01();

            parser.Parse(a01, input);

            // Act / Assert
            Assert.That(
                () => parser.Parse(a01.PID, null, EncodingCharacters.FromMessage(a01)),
                Throws.ArgumentNullException);
        }
    }
}