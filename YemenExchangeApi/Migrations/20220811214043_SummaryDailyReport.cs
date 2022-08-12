using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemenExchangeApi.Migrations
{
    public partial class SummaryDailyReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
SELECT        CAST(t1.SentDate AS date) AS TransformDate, COUNT(*) AS TransformCount, SUM(t1.Fees) AS TotalFess, SUM(t1.Total) AS SentAmountTotal, SUM(CASE t2.Done WHEN 1 THEN t2.Amount ELSE 0 END) 
                         AS ReceivedAmountToatl
FROM            dbo.Transforms AS t1 LEFT OUTER JOIN
                         dbo.Transforms AS t2 ON t1.TransformNo = t2.TransformNo
GROUP BY CAST(t1.SentDate AS date)

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view SummaryDailyReport");
        }
    }
}
