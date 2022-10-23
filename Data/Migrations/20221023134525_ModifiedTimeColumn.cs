using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace One_Time_Password_Generator.Data.Migrations
{
    public partial class ModifiedTimeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Users",
                newName: "OTP_DateTime_Created");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OTP_DateTime_Created",
                table: "Users",
                newName: "TimeStamp");
        }
    }
}
