namespace YemenExchangeApi.Models
{
    public class SummaryTransformReport
    {
        public string TransformNo { get; set; }
        public string CityName { get; set; }
        public string AreaName { get; set; }
        public string ByWho { get; set; }
        public string SenderName { get; set; }
        public string SenderPhoneNumber { get; set; }
        public string SentDate { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string? ReceivedDate { get; set; }
        public string? ReceiverIdentityCardPath { get; set; }
        public string? Note { get; set; }
        public double? Amount { get; set; }
        public double? Fees { get; set; }
        public double? Total { get; set; }
        public bool? Done { get; set; }
    }
}
