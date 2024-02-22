using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Loan_Management_System_API_Task.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AmountRequested = table.Column<decimal>(type: "numeric", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApprovalRejections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoanApplicationId = table.Column<int>(type: "integer", nullable: false),
                    ApproverId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ApprovalRejectionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApprovalRejections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApprovalRejections_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApprovalRejections_Users_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoanApplicationId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanDetails_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanRepayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoanApplicationId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRepayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanRepayments_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRepayments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "Admin", "Admin", "Admin" },
                    { 2, "User", "User", "User" },
                    { 3, "Manager", "Manager", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "LoanApplications",
                columns: new[] { "Id", "AmountRequested", "ApplicationDate", "Purpose", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 200000m, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Personal", 1, 1 },
                    { 2, 100000m, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Business", 2, 2 },
                    { 3, 300000m, new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Education", 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "LoanApprovalRejections",
                columns: new[] { "Id", "ApprovalRejectionDate", "ApproverId", "LoanApplicationId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1, 1 },
                    { 2, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), 2, 2, 2 },
                    { 3, new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), 3, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "LoanDetails",
                columns: new[] { "Id", "LoanApplicationId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "LoanRepayments",
                columns: new[] { "Id", "AmountPaid", "LoanApplicationId", "PaymentDate", "UserId" },
                values: new object[,]
                {
                    { 1, 20000m, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, 10000m, 2, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 3, 30000m, 3, new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_UserId",
                table: "LoanApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApprovalRejections_ApproverId",
                table: "LoanApprovalRejections",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApprovalRejections_LoanApplicationId",
                table: "LoanApprovalRejections",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanDetails_LoanApplicationId",
                table: "LoanDetails",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanDetails_UserId",
                table: "LoanDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRepayments_LoanApplicationId",
                table: "LoanRepayments",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRepayments_UserId",
                table: "LoanRepayments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApprovalRejections");

            migrationBuilder.DropTable(
                name: "LoanDetails");

            migrationBuilder.DropTable(
                name: "LoanRepayments");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
