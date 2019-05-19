using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trucks.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Chassis = table.Column<string>(maxLength: 17, nullable: false),
                    Model = table.Column<int>(nullable: false),
                    ModelComplement = table.Column<string>(maxLength: 100, nullable: true),
                    Year = table.Column<int>(nullable: false),
                    ModelYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "Id", "Chassis", "Model", "ModelComplement", "ModelYear", "Year" },
                values: new object[] { 1001, "2HNYD28507H001989", 1, "540 GLOBETROTTER 6x4 2p (diesel)", 2010, 2010 });

            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "Id", "Chassis", "Model", "ModelComplement", "ModelYear", "Year" },
                values: new object[] { 1002, "JH4DC4466SS977227", 2, null, 2020, 2019 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trucks");
        }
    }
}
