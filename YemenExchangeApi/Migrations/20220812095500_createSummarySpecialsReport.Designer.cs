﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YemenExchangeApi.Services;

#nullable disable

namespace YemenExchangeApi.Migrations
{
    [DbContext(typeof(ExchangeDbContext))]
    [Migration("20220812095500_createSummarySpecialsReport")]
    partial class createSummarySpecialsReport
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("YemenExchangeApi.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Address")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("IdentityCardPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.SummaryDailyReport", b =>
                {
                    b.Property<double?>("ReceivedAmountToatl")
                        .HasColumnType("float");

                    b.Property<double?>("SentAmountTotal")
                        .HasColumnType("float");

                    b.Property<double?>("TotalFess")
                        .HasColumnType("float");

                    b.Property<int>("TransformCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransformDate")
                        .HasColumnType("datetime2");

                    b.ToView("SummaryDailyReport");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.SummaryTransformReport", b =>
                {
                    b.Property<string>("TransformNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ByWho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Done")
                        .HasColumnType("bit");

                    b.Property<double?>("Fees")
                        .HasColumnType("float");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceivedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverIdentityCardPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SentDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Total")
                        .HasColumnType("float");

                    b.HasKey("TransformNo");

                    b.ToView("SummaryTransformReport");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.Transform", b =>
                {
                    b.Property<string>("TransformNo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<double>("Fees")
                        .HasColumnType("float");

                    b.Property<string>("IdentityCardPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("RecievedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("RecieverId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("RecieverPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("SenderPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("SentDate")
                        .HasColumnType("datetime");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("TransformNo");

                    b.HasIndex("AreaId");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RecieverId");

                    b.HasIndex("SenderId");

                    b.HasIndex("UserId");

                    b.ToTable("Transforms");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Address")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreatedAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("LastModify")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProfilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.Area", b =>
                {
                    b.HasOne("YemenExchangeApi.Models.City", "City")
                        .WithMany("Areas")
                        .HasForeignKey("CityId")
                        .IsRequired()
                        .HasConstraintName("FK_Cities_Areas_Id");

                    b.Navigation("City");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.Transform", b =>
                {
                    b.HasOne("YemenExchangeApi.Models.Area", "Area")
                        .WithMany("Transforms")
                        .HasForeignKey("AreaId")
                        .IsRequired()
                        .HasConstraintName("FK_Transforms_Areas_Id");

                    b.HasOne("YemenExchangeApi.Models.City", "City")
                        .WithMany("Transforms")
                        .HasForeignKey("CityId")
                        .IsRequired()
                        .HasConstraintName("FK_Transforms_Cities_Id");

                    b.HasOne("YemenExchangeApi.Models.Company", "Company")
                        .WithMany("Transforms")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK_Transforms_Companies_Id");

                    b.HasOne("YemenExchangeApi.Models.Customer", "Reciever")
                        .WithMany("TransformRecievers")
                        .HasForeignKey("RecieverId")
                        .IsRequired();

                    b.HasOne("YemenExchangeApi.Models.Customer", "Sender")
                        .WithMany("TransformSenders")
                        .HasForeignKey("SenderId")
                        .IsRequired();

                    b.HasOne("YemenExchangeApi.Models.User", "User")
                        .WithMany("Transforms")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Transforms_Users_Id");

                    b.Navigation("Area");

                    b.Navigation("City");

                    b.Navigation("Company");

                    b.Navigation("Reciever");

                    b.Navigation("Sender");

                    b.Navigation("User");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.Area", b =>
                {
                    b.Navigation("Transforms");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.City", b =>
                {
                    b.Navigation("Areas");

                    b.Navigation("Transforms");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.Company", b =>
                {
                    b.Navigation("Transforms");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.Customer", b =>
                {
                    b.Navigation("TransformRecievers");

                    b.Navigation("TransformSenders");
                });

            modelBuilder.Entity("YemenExchangeApi.Models.User", b =>
                {
                    b.Navigation("Transforms");
                });
#pragma warning restore 612, 618
        }
    }
}
