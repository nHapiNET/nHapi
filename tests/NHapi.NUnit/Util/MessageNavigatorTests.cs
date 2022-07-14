namespace NHapi.NUnit.Util
{
    using global::NUnit.Framework;

    using NHapi.Base.Util;
    using NHapi.Model.V24.Message;
    using NHapi.Model.V24.Segment;

    [TestFixture]
    public class MessageNavigatorTests
    {
        [Test]
        public void TestNavigate()
        {
            // Arrange
            var message = new ADT_A01();
            message.GetINSURANCE().IN1.CoverageType.Value = "a";
            message.MSH.CountryCode.Value = "b";
            message.PD1.Handicap.Value = "c";

            var sut = new MessageNavigator(message);

            // Act
            sut.DrillDown(16, 0);
            var in1 = (IN1)sut.GetCurrentStructure(0);

            sut.Reset();
            sut.NextChild();
            var msh = (MSH)sut.GetCurrentStructure(0);

            sut.Reset();
            sut.NextChild();
            sut.NextChild();
            sut.NextChild();
            sut.NextChild();
            var pd1 = (PD1)sut.GetCurrentStructure(0);

            // Assert
            Assert.AreEqual("a", in1.CoverageType.Value);
            Assert.AreEqual("b", msh.CountryCode.Value);
            Assert.AreEqual("a", in1.CoverageType.Value);
            Assert.AreEqual("c", pd1.Handicap.Value);
        }

        [Test]
        public void TestIterator()
        {
            // Arrange
            var message = new ADT_A01();
            message.GetINSURANCE().IN1.CoverageType.Value = "a";
            message.MSH.CountryCode.Value = "b";
            message.PD1.Handicap.Value = "c";

            var sut = new MessageNavigator(message);

            // Act
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            sut.Iterate(true, false);
            var in1 = (IN1)sut.GetCurrentStructure(0);

            sut.Reset();
            sut.ToChild(3);
            var pd1 = (PD1)sut.GetCurrentStructure(0);

            // Assert
            Assert.AreEqual("a", in1.CoverageType.Value);
            Assert.AreEqual("c", pd1.Handicap.Value);
        }
    }
}