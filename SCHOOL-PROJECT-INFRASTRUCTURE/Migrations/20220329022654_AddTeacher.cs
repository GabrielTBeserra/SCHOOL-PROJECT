using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Migrations
{
    public partial class AddTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "log_time",
                table: "Log",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 28, 23, 26, 54, 158, DateTimeKind.Local).AddTicks(1958),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 3, 28, 21, 25, 58, 681, DateTimeKind.Local).AddTicks(5612));

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.code);
                    table.ForeignKey(
                        name: "FK_Teacher_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_user_id",
                table: "Teacher",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.AlterColumn<DateTime>(
                name: "log_time",
                table: "Log",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 28, 21, 25, 58, 681, DateTimeKind.Local).AddTicks(5612),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 3, 28, 23, 26, 54, 158, DateTimeKind.Local).AddTicks(1958));
        }
    }
}
