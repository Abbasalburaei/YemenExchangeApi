using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemenExchangeApi.Migrations
{
    public partial class createSummarySpecialsReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view SummarySpecialReport as select TransformNo , case done when 1 then cast(cast(RecievedDate as date) as varchar(50)) else cast(cast(sentdate as date) as varchar(50)) end OperationDate  
,c1.FullName SenderName , c2.FullName ReceiverName , RecieverPhoneNumber ReceiverPhoneNumber , SenderPhoneNumber , Done
,case done when 1 then Amount else Total end AmountTotal
from transforms t inner join Customers c1
on t.SenderId = c1.Id inner join Customers c2
on t.RecieverId = c2.Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view SummarySpecialReport");
        }
    }
}
