using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StepHR365.Migrations
{
    /// <inheritdoc />
    public partial class initdb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeNo",
                table: "EmployeeInformation",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9788), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9789) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9791), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9793) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9794), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9795) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9596), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9597), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9593), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9605), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9606), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9603), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9607) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9613), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9613), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9611), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9614) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9619), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9620), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9618), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9625), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9626), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9624), new DateTime(2023, 10, 10, 16, 47, 41, 769, DateTimeKind.Local).AddTicks(9627) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail",
                unique: true,
                filter: "[UserEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PresentAddress_UserId",
                table: "PresentAddress",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_UserId",
                table: "PersonalInformation",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDocuments_UserId",
                table: "PersonalDocuments",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JoiningDetails_UserId",
                table: "JoiningDetails",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformation_EmployeeNo",
                table: "EmployeeInformation",
                column: "EmployeeNo",
                unique: true,
                filter: "[EmployeeNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformation_UserId",
                table: "EmployeeInformation",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeIdentity_UserId",
                table: "EmployeeIdentity",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCertificates_UserId",
                table: "EducationCertificates",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Education_UserId",
                table: "Education",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentPosition_UserId",
                table: "CurrentPosition",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserEmail",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_PresentAddress_UserId",
                table: "PresentAddress");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInformation_UserId",
                table: "PersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDocuments_UserId",
                table: "PersonalDocuments");

            migrationBuilder.DropIndex(
                name: "IX_JoiningDetails_UserId",
                table: "JoiningDetails");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeInformation_EmployeeNo",
                table: "EmployeeInformation");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeInformation_UserId",
                table: "EmployeeInformation");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeIdentity_UserId",
                table: "EmployeeIdentity");

            migrationBuilder.DropIndex(
                name: "IX_EducationCertificates_UserId",
                table: "EducationCertificates");

            migrationBuilder.DropIndex(
                name: "IX_Education_UserId",
                table: "Education");

            migrationBuilder.DropIndex(
                name: "IX_CurrentPosition_UserId",
                table: "CurrentPosition");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeNo",
                table: "EmployeeInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7572), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7574) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7576), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7577) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7578), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7579) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7408), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7409), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7405), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7410) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7419), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7420), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7416), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7421) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7427), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7428), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7425), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7428) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7434), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7435), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7433), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7436) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7444), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7444), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7442), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7445) });
        }
    }
}
