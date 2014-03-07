using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V25UCH;
using NHapi.Model.V25UCH.Message;
using NUnit.Framework;

namespace NHapi.NUnit.UCH.V25Tests
{
    [TestFixture]
    public class PaseA08MessageWithObx
    {
        [Test]
        public void ParseSimpleMessage()
        {
            PipeParser parser = new PipeParser();
            ADT_A01 msg = parser.Parse(GetMessage(), Constants.VERSION_25_UCH) as ADT_A01;
            Assert.IsNotNull(msg);

            Assert.AreEqual(2, msg.OBXRepetitionsUsed);
        }

        private string GetMessage()
        {
            return
                @"MSH|^~\&|EPIC|UCH|||20100521143056|EDIREGO|ADT^A08|7407|T|2.5|||AL
EVN|A08|201005211430|||EDIREGO^EDI^RAD^OUT^^^^^UCH^^^^^UCHIS|
PID|1||E1845^^^^EPI~201650^^^MRN^MRN||TEST^B A||201005100800|M|||^^^^^USA^P^^|||||S|||000-00-0000||TEST^NICU^^|||||||||N
PD1|||EHS MODEL HOSPITAL^^10101|||||||||||
CON|1|HIPAA NOP|||||||||||||
CON|2|Phys Consent|||||||||||||
CON|3|ADLW|||||||||||||
CON|4|POA|||||||||||||
CON|5|Phys Fin ROI|||||||||||||
NK1|1|WILLIAMS^MICHAEL^^|PAR|4563 QUARTZ STREET^^MADISON^WI^53719^USA|(608)555-4578^^PH^^^608^5554578~|||||||||||||||||||||||||||||
NK1|2|TEST^NICU^^|PAR|4563 QUARTZ STREET^^MADISON^WI^53719^USA|(608)555-4578^^PH^^^608^5554578~(608)555-7774^^CP^^^608^5557774|(608)555-4785^^PH^^^608^5554785||||||||||||||||||||||||||||
PV1|1|NEWBORN|^NICU^NICU-01^EHSMH^R^^^^^^|NB||||||Neonatology||||Clinic Ref|||||22351|CARE||||||||||||||||||||||||201005100800||||||
PV2||||||||||||||||||||||N|||||||||||||||||||||||||||
OBX||NM|HT^HEIGHT||2' 11\" + @"|ft
OBX||NM|WT^WEIGHT||42.3|oz
DG1|1||^Newborn|Newborn||
GT1|1|1602|TEST^NICU^^||4563 QUARTZ STREET^^MADISON^WI^53719^USA^^^|(608)555-4578^^^^^608^5554578|(608)555-4785^^^^^608^5554785|19820905|F|P/F|Mother|898-76-1715||||OTHER|^^^^^USA||||||||||||||||||||||||||||||||Documentation Specialist
IN1|1|||MEDICARE|1979 MILKY WAY^^VERONA^WI^53593^||(555)555-5555^^^^^555^5555555|||||||||TEST^NICU^^||19820905|4563 QUARTZ STREET^^MADISON^WI^53719^USA^^^||||||YES||||||||||||||||||F|^^^^^USA|||BOTH||
IN2||898-76-1715|||Payor Plan||||||||||||||||||||||||||||||||||||||||||||||||||||||||||(608)555-4578^^^^^608^5554578|||||||OTHER
ACC|||||||||
UB2||||||||";
        }
    }
}
