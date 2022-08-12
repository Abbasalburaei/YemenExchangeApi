using System.Text.Json.Serialization;

namespace YemenExchangeApi.Models
{
    public class SummarySpecialReport
    {
        public string TransformNo { get; set; }
        public string OperationDate { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public string SenderPhoneNumber { get; set; }
        public bool Done { get; set; }
        public double? AmountTotal { get; set; }
    }
}
