using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHapi.Base.Model;
using NUnit.Framework;
using NHapi.Model.V25UCH.Message;
using NHapi.Model.V25UCH;
using NHapi.Base.Parser;

namespace NHapi.NUnit.UCH.V25Tests
{
    [TestFixture]
    public class TestParsingWithMessageStructure
    {
        [Test]
        public void TestUch25Parse_Simple()
        {
            PipeParser parser = new PipeParser();
            ADT_A01 msg = (ADT_A01)parser.Parse(GetSimpleMessage(), Constants.VERSION_25_UCH);
            Assert.IsNotNull(msg);
        }

        [Test]
        public void TestUch25Parse_Complex()
        {
            PipeParser parser = new PipeParser();
            ADT_A01 msg = (ADT_A01)parser.Parse(GetComplexMessage(), Constants.VERSION_25_UCH);
            Assert.IsNotNull(msg);

            Assert.AreEqual(2, msg.CON2RepetitionsUsed);
            Assert.AreEqual(5, msg.CONRepetitionsUsed);
        }


        private static string  GetComplexMessage()
        {
            return
                @"MSH|^~\&|EPIC|UCH|||20100513181309|EDIREGO|ADT^A08|6589|T|2.5|||AL
EVN|A08|201005131813|||^EDI^RAD^OUT^^^^^UCH^^^^^UCHOS
PID|1||E1361^^^^EPI~201174^^^MRN^MRN||TEST^TEST||19500606|M||White|12 ELM ST.^^AURORA^CO^80015^USA^P^^ARAPAHOE|ARAPAHOE|(303)555-0000^P^PH^^^303^5550000|||SINGLE|||999-11-1110|||NON-HISPANIC||||||||N
PD1|||EHS MODEL CLINIC^^10501
CON|1|HIPAA NOP
CON|2|Phys Consent
CON|3|ADLW
CON|4|POA
CON|5|Phys Fin ROI
NK1|1|TEST^TRINA|Sister|12 DAYSPRING ST^^COLORADO SPGS^CO^80923^USA^^^EL PASO|(719)555-1659^^PH^^^719^5551659
PV1|1|HOSPITAL OP|^^^EHSMH|EL||||||Gastro||||Clinic Ref|||||22032|COMM
PV2||||||||201005130900|||||||||||||n|N
CON|1|CMS IM SIGN
CON|2|CMS IM COPY
DG1|1||^GI Bleeding|GI Bleeding
GT1|1|1567|TEST^TEST||12 ELM ST.^^AURORA^CO^80015^USA^^^ARAPAHOE|(303)555-0000^^^^^303^5550000||19500606|M|P/F|SLF|999-11-1110||||EHS EMPLOYER|1979 MILKY WAY^^VERONA^WI^53593^USA|(608)271-9000^^^^^608^2719000||Full
IN1|1|||AETNA|PO BOX 981107^^EL PASO^TX^79998-1107||(555)555-5555^^^^^555^5555555|EHS 222|EHS EMPLOYER|||||||TEST^TEST|Self|19500606|12 ELM ST.^^AURORA^CO^80015^USA^^^ARAPAHOE||||||YES|||||||||||999121234|||||||M||||BOTH
IN2||999-11-1110|||Coverage||||||||||||||||||||||||||||||||||||||||||||||||||||||||||(303)555-0000^^^^^303^5550000";
        }

        private static string GetSimpleMessage()
        {
            return
                @"MSH|^~\&|EPIC|UCH|||20100513181309|EDIREGO|ADT^A08^ADT_A01|6589|T|2.5|||AL
EVN|A08|201005131813|||^EDI^RAD^OUT^^^^^UCH^^^^^UCHOS
PID|1||E1361^^^^EPI~201174^^^MRN^MRN||TEST^TEST||19500606|M||White|12 ELM ST.^^AURORA^CO^80015^USA^P^^ARAPAHOE|ARAPAHOE|(303)555-0000^P^PH^^^303^5550000|||SINGLE|||999-11-1110|||NON-HISPANIC||||||||N";
        }
    }
}
