namespace NHapi.Model.V251.Table
{
    /// <summary>
    /// HL7 Table 0155. Accept/application acknowledgment condition 
    /// http://www.copra-snippets.de/start/item/12-hl7-tables.html
    /// </summary>
    public static class ApplicationAcknowledgementConditions
    {
        public static readonly string Always = "AL";
        public static readonly string Error = "ER";
        public static readonly string Never = "NE";
        public static readonly string Successful = "SU";
    }
}