using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemenExchangeApi.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "صنعاء" },
                    { 2, "تعز" },
                    { 3, "الحديدة" },
                    { 4, "عدن" },
                    { 5, "إب" },
                    { 6, "ذمار" },
                    { 7, "المكلا" },
                    { 8, "سيئون" },
                    { 9, "سيان" },
                    { 10, "الشحر" },
                    { 11, "زبيد" },
                    { 12, "حجة" },
                    { 13, "باجل" },
                    { 14, "رداع" },
                    { 15, "سقطرى" },
                    { 16, "بيت الفقية" },
                    { 17, "يريم" },
                    { 18, "البيضاء" },
                    { 19, "لحج" },
                    { 20, "عبس" },
                    { 21, "حرض" },
                    { 22, "مديرية المحابشة" },
                    { 23, "مأرب" },
                    { 24, "عمران" },
                    { 25, "المخا" },
                    { 26, "المحويت" }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
        }
    }
}
