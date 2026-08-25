using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using IF.Plugins.EFCoreSqlServer;

#nullable disable

namespace IF.Plugins.EFCoreSqlServer.Migrations
{
    [DbContext(typeof(IFContext))]
    [Migration("20260824000000_RemoveInstructionNumber")]
    public partial class RemoveInstructionNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructionNumber",
                table: "Instructions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstructionNumber",
                table: "Instructions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
