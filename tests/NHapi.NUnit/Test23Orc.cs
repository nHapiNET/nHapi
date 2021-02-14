namespace NHapi.NUnit
{
    using global::NUnit.Framework;

    using NHapi.Model.V23.Datatype;
    using NHapi.Model.V23.Group;
    using NHapi.Model.V23.Message;

    [TestFixture]
    public class Test23Orc
    {
        [Test]
        public void Test()
        {
            var msg = new ORM_O01();
            var order = msg.GetORDER(0);
            var placerNumber = order.ORC.GetPlacerOrderNumber(0);
            placerNumber.EntityIdentifier.Value = "123";
        }
    }
}