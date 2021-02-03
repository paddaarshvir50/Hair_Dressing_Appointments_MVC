using Microsoft.EntityFrameworkCore.Migrations;

namespace Hair_Dressing_Appointments_MVC.Migrations.Hair_Dressing_Appointments_DB
{
    public partial class hair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HairDresser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPermanent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairDresser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HairDressingOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Charge = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairDressingOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    HairDresserId = table.Column<int>(type: "int", nullable: false),
                    HairDressingOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_HairDresser_HairDresserId",
                        column: x => x.HairDresserId,
                        principalTable: "HairDresser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_HairDressingOption_HairDressingOptionId",
                        column: x => x.HairDressingOptionId,
                        principalTable: "HairDressingOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ClientId",
                table: "Appointment",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_HairDresserId",
                table: "Appointment",
                column: "HairDresserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_HairDressingOptionId",
                table: "Appointment",
                column: "HairDressingOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "HairDresser");

            migrationBuilder.DropTable(
                name: "HairDressingOption");
        }
    }
}
