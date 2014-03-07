using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NHapi.NUnit.Additional
{
    [TestFixture]
    public class CustomZSegmentTest
    {
        [Test]
        public void ParseADT_A08()
        {
            //this is some fictive data
            string message = @"MSH|^~\&|SUNS1|OVI02|AZIS|CMD|200606221348||ADT^A08|1049691900|P|2.2
EVN|A08|200601060800
PID||8912716038^^^51276|0216128^^^51276||BARDOUN^LEA SACHA||19981201|F|||AVENUE FRANC GOLD 8^^LUXEMBOURGH^^6780^150||053/12456789||N|S|||99120162652||^^^|||||B
PV1||O|^^|U|||07632^MORTELO^POL^^^DR.|^^^^^|||||N||||||0200001198
PV2|||^^AZIS||N|||200601060800
IN1|0001|2|314000|||||||||19800101|||1|BARDOUN^LEA SACHA|1|19981201|AVENUE FRANC GOLD 8^^LUXEMBOURGH^^6780^150|||||||||||||||||
ZIN|0164652011399|0164652011399|101|101|45789^Broken bone";


            /*	**********************************************************
             * 	YOU NEED TO ADD THIS CHAINED CONSTRUCTOR TO THE PiperParser CLASS!!!
             * 
             * 	public PipeParser(IModelClassFactory theFactory) : base(theFactory)
             *	{
             *	}
             * 
             * 	***********************************************************/
            NHapi.Base.Parser.PipeParser parser = new NHapi.Base.Parser.PipeParser();

            NHapi.Base.Model.IMessage m = parser.Parse(message, NHapi.Model.V22_ZSegments.Constants.VERSION);

            Assert.IsNotNull(m);

            Console.WriteLine("Type: " + m.GetType().ToString());

            NHapi.Model.V22_ZSegments.Message.ADT_A08 adtA08 =
                m as NHapi.Model.V22_ZSegments.Message.ADT_A08;
            //verify some Z segment data
            Assert.AreEqual("45789", adtA08.ZIN.AccidentData.Id.Value);
            Assert.AreEqual("Broken bone", adtA08.ZIN.AccidentData.Text.Value);
        }
    }
}
