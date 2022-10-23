using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One_Time_Password_Generator.Data.Migrations
{
    public partial class RenamedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OTP_DateTime_Created",
                table: "Users",
                newName: "Activated_DateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Activated_DateTime",
                table: "Users",
                newName: "OTP_DateTime_Created");
        }
    }
}
