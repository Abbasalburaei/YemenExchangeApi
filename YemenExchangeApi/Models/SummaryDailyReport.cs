namespace YemenExchangeApi.Models
{
    public class SummaryDailyReport
    {
        public DateTime TransformDate  { get; set; }
        public int TransformCount { get; set; }
        public double? TotalFess { get; set; }
        public double? SentAmountTotal { get; set; }
        public double? ReceivedAmountToatl { get; set; }

    }
}
