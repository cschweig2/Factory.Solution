using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class ChangeCertToLicense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CertReqd",
                table: "Machines",
                newName: "LicenseReqd");

            migrationBuilder.RenameColumn(
                name: "Certification",
                table: "Engineers",
                newName: "License");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LicenseReqd",
                table: "Machines",
                newName: "CertReqd");

            migrationBuilder.RenameColumn(
                name: "License",
                table: "Engineers",
                newName: "Certification");
        }
    }
}
