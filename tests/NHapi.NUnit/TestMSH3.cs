namespace NHapi.NUnit
{
    using global::NUnit.Framework;

    using NHapi.Base.Parser;
    using NHapi.Model.V23.Message;

    /// <summary>
    /// This test case was created from BUG 1812261 on the SourceForge project site
    /// Chad Chenoweth.
    /// </summary>
    [TestFixture]
    public class TestMSH3
    {
        [Test]
        public void TestMSH3Set()
        {
            var a01 = new ADT_A01();
            a01.MSH.SendingApplication.UniversalID.Value = "TEST";

            var parser = new PipeParser();
            var hl7 = parser.Encode(a01);

            var data = hl7.Split('|');
            Assert.That(data[8], Is.EqualTo("ADT^A01"));
        }
    }
}