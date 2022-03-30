using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Migrations
{
    public partial class AdicionadoTabelaDeTipoDeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "log_time",
                table: "Log",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 29, 21, 59, 8, 809, DateTimeKind.Local).AddTicks(635),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 3, 29, 20, 20, 17, 962, DateTimeKind.Local).AddTicks(5961));

            migrationBuilder.CreateTable(
                name: "EntityType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityType_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EntityType_user_id",
                table: "EntityType",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityType");

            migrationBuilder.AlterColumn<DateTime>(
                name: "log_time",
                table: "Log",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 29, 20, 20, 17, 962, DateTimeKind.Local).AddTicks(5961),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 3, 29, 21, 59, 8, 809, DateTimeKind.Local).AddTicks(635));
        }
    }
}
