using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Migrations
{
    public partial class RelacaoEntreProfessorEEscola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "log_time",
                table: "Log",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 29, 20, 20, 17, 962, DateTimeKind.Local).AddTicks(5961),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 3, 28, 23, 26, 54, 158, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.CreateTable(
                name: "SchoolTeacher",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    school_id = table.Column<int>(type: "int", nullable: false),
                    teacher_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTeacher", x => x.id);
                    table.ForeignKey(
                        name: "FK_SchoolTeacher_School_school_id",
                        column: x => x.school_id,
                        principalTable: "School",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolTeacher_Teacher_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "Teacher",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeacher_school_id",
                table: "SchoolTeacher",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeacher_teacher_id",
                table: "SchoolTeacher",
                column: "teacher_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolTeacher");

            migrationBuilder.AlterColumn<DateTime>(
                name: "log_time",
                table: "Log",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 28, 23, 26, 54, 158, DateTimeKind.Local).AddTicks(1958),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 3, 29, 20, 20, 17, 962, DateTimeKind.Local).AddTicks(5961));
        }
    }
}
