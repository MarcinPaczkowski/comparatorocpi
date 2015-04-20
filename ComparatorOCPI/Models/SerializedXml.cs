namespace ComparatorOCPI.Models
{
    public class SerializedXml
    {
        public bool IsTransactionType { get; set; }
        public string DateTime { get; set; }
        public string Name { get; set; }
        public string RecordType { get; set; }
        public string SenderPdm { get; set; }
        public string TracerPdm { get; set; }
        public string PaymentType { get; set; }
        public string Amount { get; set; }
        public string Number { get; set; }
        public bool IsError { get; set; }
    }
}