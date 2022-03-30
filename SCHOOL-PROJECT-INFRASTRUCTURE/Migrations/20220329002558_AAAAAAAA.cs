using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Migrations
{
    public partial class AAAAAAAA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "log_time",
                table: "Log",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 28, 21, 25, 58, 681, DateTimeKind.Local).AddTicks(5612),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 3, 18, 17, 50, 50, 0, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    registration = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                    table.ForeignKey(
                        name: "FK_Student_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Student_user_id",
                table: "Student",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.AlterColumn<DateTime>(
                name: "log_time",
                table: "Log",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 18, 17, 50, 50, 0, DateTimeKind.Local).AddTicks(6575),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 3, 28, 21, 25, 58, 681, DateTimeKind.Local).AddTicks(5612));
        }
    }
}
