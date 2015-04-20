namespace ComparatorOCPI.Models
{
    public class SerializedCsv
    {
        public string DateTime { get; set; }
        public string Location { get; set; }
        public string RecordType { get; set; }
        public string SenderPdm { get; set; }
        public string TracerPdm { get; set; }
        public string TypeOfPayment { get; set; }
        public string Amount { get; set; }
        public string TicketNumber { get; set; }
    }
}