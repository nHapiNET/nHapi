using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V25UCH;
using NHapi.Model.V25UCH.Message;
using NUnit.Framework;

namespace NHapi.NUnit.UCH.V25Tests
{
    [TestFixture]
    public class ParseA04Message
    {
        [Test]
        public void ParseSimpleMessage()
        {
            PipeParser parser = new PipeParser();
            ADT_A01 msg = parser.Parse(GetMessage(), Constants.VERSION_25_UCH) as ADT_A01;
            Assert.IsNotNull(msg);

            Assert.AreEqual(2, msg.INSURANCERepetitionsUsed);
            Assert.AreEqual(msg.GetINSURANCE(0).IN1.SetIDIN1.Value, "1");
            Assert.AreEqual(msg.GetINSURANCE(1).IN1.SetIDIN1.Value, "2");
        }

        private string GetMessage()
        {
            return
                @"MSH|^~\&|EPIC|UCH|||20100513181307|ESDESK|ADT^A04|6564|T|2.5|||AL
EVN|A04|201005131813|||^CADENCE^FRONT^DESK^^^^^UCH^^^^^EHSMC
PID|1||E1362^^^^EPI~201175^^^MRN^MRN||ADTVALTWO^ANA||19700321|F||Unknown|5543 LAKE^^MADISON^WI^53703^USA^P^^DANE|DANE|(345)567-4545^P^PH^^^345^5674545~^NET^^ana@gmail.com|||MARRIED|||345-42-5346|||HISPANIC||||||||N
PD1|||EHS MODEL HOSPITAL^^10101
ROL|1||GENERAL||20100321||||||5301 TOKAY BLVD.^^MADISON^WI^53711^^^^DANE|(608)271-9000^^PH^^^608^2719000
CON|1|HIPAA NOP|||||||||SIGNED||20100321
CON|2|ADLW|||||||||||20100321
CON|3|POA|||||||||||20100321||201103210000
CON|4|Phys Consent
CON|5|Phys Fin ROI
NK1|1|BOBBY^RICKY|Spouse|5543 LAKE^^MADISON^WI^53703^USA^^^DANE|(345)567-4545^^PH^^^345^5674545
PV1|1|OUTPATIENT|^^^EHSMC|EL||||||||||Clinic Ref|||||22724|COMM||||||||||||||||||||||||201005130824
PV2|||||||W/C|201005131130||||ARRIVED||||||||||N
CON|1|CMS IM SIGN
CON|2|CMS IM COPY
GT1|1|1257|ADTVALTWO^ANA||5543 LAKE^^MADISON^WI^53703^USA^^^DANE|(345)567-4545^^^^^345^5674545||19700321|F|P/F|SLF|345-42-5346|||||^^^^^USA|||Full
IN1|1|||AETNA|PO BOX 981107^^EL PASO^TX^79998-1107||(555)555-5555^^^^^555^5555555|456||||||||ADTVALTWO^ANA|Self|19700321|5543 LAKE^^MADISON^WI^53703^USA^^^DANE||||||YES|||||||||||243543456|||||||F||||BOTH
IN2||345-42-5346|||Payor Plan||||||||||||||||||||||||||||||||||||||||||||||||||||||||||(345)567-4545^^^^^345^5674545
IN1|2|||AETNA SAMPLE|^^VERONA^WI|||||||||||ADTVALTWO^ANA|Self|19700321|5543 LAKE^^MADISON^WI^53703^USA^^^DANE|||||||||||||||||56765756|||||||F
IN2||345-42-5346|||Payor||||||||||||||||||||||||||||||||||||||||||||||||||||||||||(345)567-4545^^^^^345^5674545";
        }
    }
}
