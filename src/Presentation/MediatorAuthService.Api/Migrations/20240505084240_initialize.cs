using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendSample.Api.Migrations
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "DeletedDate", "DeletedUserId", "Email", "IsActive", "ModifiedDate", "ModifiedUserId", "Name", "Password", "RefreshToken", "Surname" },
                values: new object[] { new Guid("d0bfa391-a604-4049-a868-359091461e46"), new DateTime(2024, 5, 5, 8, 42, 39, 572, DateTimeKind.Utc).AddTicks(5496), new Guid("d0bfa391-a604-4049-a868-359091461e46"), null, null, "admin@gmail.com", true, null, null, "Admin", "ANQzQQyRUy3LXTVirDxhqL1iHyI+n1WvIGTMh0JWVtCzpZaeINhqS9Wtsp4q0m69Ow==", "ALncGR48Reqz0dQ2GwZ5Z3+j3nkUAeQRYr7jmllEtDiKqBxSbyLldSCCjvd291K3sg==", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
