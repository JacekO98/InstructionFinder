using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IF.Plugins.EFCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    InstructionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PdfRelativePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.InstructionID);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineDW = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineID);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartID);
                });

            migrationBuilder.CreateTable(
                name: "InstructionMachine",
                columns: table => new
                {
                    InstructionsInstructionID = table.Column<int>(type: "int", nullable: false),
                    MachinesMachineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructionMachine", x => new { x.InstructionsInstructionID, x.MachinesMachineID });
                    table.ForeignKey(
                        name: "FK_InstructionMachine_Instructions_InstructionsInstructionID",
                        column: x => x.InstructionsInstructionID,
                        principalTable: "Instructions",
                        principalColumn: "InstructionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructionMachine_Machines_MachinesMachineID",
                        column: x => x.MachinesMachineID,
                        principalTable: "Machines",
                        principalColumn: "MachineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructionPart",
                columns: table => new
                {
                    InstructionsInstructionID = table.Column<int>(type: "int", nullable: false),
                    PartsPartID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructionPart", x => new { x.InstructionsInstructionID, x.PartsPartID });
                    table.ForeignKey(
                        name: "FK_InstructionPart_Instructions_InstructionsInstructionID",
                        column: x => x.InstructionsInstructionID,
                        principalTable: "Instructions",
                        principalColumn: "InstructionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructionPart_Parts_PartsPartID",
                        column: x => x.PartsPartID,
                        principalTable: "Parts",
                        principalColumn: "PartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructionMachine_MachinesMachineID",
                table: "InstructionMachine",
                column: "MachinesMachineID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructionPart_PartsPartID",
                table: "InstructionPart",
                column: "PartsPartID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructionMachine");

            migrationBuilder.DropTable(
                name: "InstructionPart");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Parts");
        }
    }
}
