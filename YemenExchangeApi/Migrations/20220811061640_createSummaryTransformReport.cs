using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemenExchangeApi.Migrations
{
    public partial class createSummaryTransformReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
SELECT        t.TransformNo, c.Description AS CityName, co.Description AS CompanyName, a.Description AS AreaName, u.FullName AS ByWho, cs1.FullName AS ReceiverName, t.RecieverPhoneNumber AS ReceiverPhoneNumber, 
                         t.IdentityCardPath AS ReceiverIdentityCardPath, cs2.FullName AS SenderName, t.SenderPhoneNumber, format(t.SentDate, 'yyyy-MM-dd hh:mm:ss tt') AS SentDate, format(t.RecievedDate, 'yyyy-MM-dd hh:mm:ss tt') 
                         AS ReceivedDate, t.Amount, t.Fees, t.Total, t.Note, t.Done
FROM            dbo.Transforms AS t INNER JOIN
                         dbo.Cities AS c ON c.Id = t.CityId INNER JOIN
                         dbo.Areas AS a ON a.Id = t.AreaId INNER JOIN
                         dbo.Users AS u ON u.Id = t.UserId INNER JOIN
                         dbo.Customers AS cs1 ON cs1.Id = t.RecieverId INNER JOIN
                         dbo.Customers AS cs2 ON cs2.Id = t.SenderId INNER JOIN
                         dbo.Companies AS co ON co.Id = t.CompanyId
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view SummaryTransformReport");
        }
    }
}
