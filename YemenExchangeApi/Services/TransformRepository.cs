using YemenExchangeApi.Models;
namespace YemenExchangeApi.Services
{
    public class TransformRepository : Repository<Transform>
    {
        private readonly ExchangeDbContext dbContext;

        public TransformRepository(ExchangeDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public int SentTransformCount { 
            get {

            return GetAll().Where(e=> e.Done == false).Count();

           }
        }

        public int ReceiveTransformCount
        {
            get
            {

                return GetAll().Where(e => e.Done == true).Count();

            }
        }

        public double SentAmountTotal
        {
            get
            {

                return GetAll().Sum(e=> e.Total);
            }
        }

        public double ReceiveAmountTotal
        {
            get
            {

                return GetAll().Where(e=>e.Done == true).Sum(e=>e.Amount);
            }
        }

        public string GenerateTransformCode(string prefix)
        {
            int prefixLength = prefix.Length;
            var result = FindAll(e => e.TransformNo.ToLower().StartsWith(prefix.ToLower())).Select(e => Convert.ToInt64(e.TransformNo.Trim().Substring(prefixLength))).ToList();
            if (result.Count != 0)
                return String.Concat(prefix,(1 + result.Max()));

            return String.Concat(prefix,1);
        }

        public SummaryTransformReport? SummaryReport(string code)
        {
            return dbContext.SummaryTransformReport.FirstOrDefault(e => e.TransformNo == code);
        }

        public IEnumerable<SummaryTransformReport> GetAllSummaryReports()
        {
            return dbContext.SummaryTransformReport.ToList();
        }

        public IEnumerable<SummaryDailyReport> GetDailyReports(DateTime startDate , DateTime endDate)
        {
            return from rep in dbContext.SummaryDailyReport
                   where rep.TransformDate >= startDate.Date && rep.TransformDate <= endDate.Date
                   select rep;
        }

        public IEnumerable<SummarySpecialReport> GetSpecialReports(string search)
        {
            return dbContext.SummarySpecialReport.Where(e=> e.SenderName.ToLower().Contains(search) || 
            e.ReceiverName.ToLower().Contains(search) || e.SenderPhoneNumber.ToLower().Contains(search) 
            || e.ReceiverPhoneNumber.ToLower().Contains(search)).ToList();
        }

        public IEnumerable<SummarySpecialReport> GetSpecialReports(DateTime date)
        {
            return dbContext.SummarySpecialReport.Where(e => e.OperationDate == date.ToString("yyyy-MM-d")).ToList();
        }
    }
}
