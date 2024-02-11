﻿// <auto-generated />
using System;
using Loan_Management_System_API_Task.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Loan_Management_System_API_Task.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240211202409_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Loan_Management_System_API_Task.Models.LoanApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AmountRequested")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LoanApplications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountRequested = 200000m,
                            ApplicationDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Purpose = "Personal",
                            Status = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            AmountRequested = 100000m,
                            ApplicationDate = new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                            Purpose = "Business",
                            Status = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            AmountRequested = 300000m,
                            ApplicationDate = new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                            Purpose = "Education",
                            Status = 0,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Loan_Management_System_API_Task.Models.LoanApprovalRejection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ApprovalRejectionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ApproverId")
                        .HasColumnType("integer");

                    b.Property<int>("LoanApplicationId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("LoanApplicationId");

                    b.ToTable("LoanApprovalRejections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApprovalRejectionDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            ApproverId = 1,
                            LoanApplicationId = 1,
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            ApprovalRejectionDate = new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                            ApproverId = 2,
                            LoanApplicationId = 2,
                            Status = 2
                        },
                        new
                        {
                            Id = 3,
                            ApprovalRejectionDate = new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                            ApproverId = 3,
                            LoanApplicationId = 3,
                            Status = 0
                        });
                });

            modelBuilder.Entity("Loan_Management_System_API_Task.Models.LoanDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LoanApplicationId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LoanApplicationId");

                    b.HasIndex("UserId");

                    b.ToTable("LoanDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LoanApplicationId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            LoanApplicationId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            LoanApplicationId = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Loan_Management_System_API_Task.Models.LoanRepayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("numeric");

                    b.Property<int>("LoanApplicationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LoanApplicationId");

                    b.HasIndex("UserId");

                    b.ToTable("LoanRepayments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountPaid = 20000m,
                            LoanApplicationId = 1,
                            PaymentDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            AmountPaid = 10000m,
                            LoanApplicationId = 2,
                            PaymentDate = new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            AmountPaid = 30000m,
                            LoanApplicationId = 3,
                            PaymentDate = new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Loan_Management_System_API_Task.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            Password = "Admin",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User",
                            Password = "User",
                            Role = "User"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Manager",
                            Password = "Manager",
                            Role = "Manager"
                        });
                });

            modelBuilder.Entity("Loan_Management_System_API_Task.Models.LoanApplication", b =>
                {
                    b.HasOne("Loan_Management_System_API_Task.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Loan_Management_System_API_Task.Models.LoanApprovalRejection", b =>
                {
                    b.HasOne("Loan_Management_System_API_Task.Models.User", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Loan_Management_System_API_Task.Models.LoanApplication", "LoanApplication")
                        .WithMany()
                        .HasForeignKey("LoanApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("LoanApplication");
                });

            modelBuilder.Entity("Loan_Management_System_API_Task.Models.LoanDetails", b =>
                {
                    b.HasOne("Loan_Management_System_API_Task.Models.LoanApplication", "LoanApplication")
                        .WithMany()
                        .HasForeignKey("LoanApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Loan_Management_System_API_Task.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoanApplication");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Loan_Management_System_API_Task.Models.LoanRepayment", b =>
                {
                    b.HasOne("Loan_Management_System_API_Task.Models.LoanApplication", "LoanApplication")
                        .WithMany()
                        .HasForeignKey("LoanApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Loan_Management_System_API_Task.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoanApplication");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
