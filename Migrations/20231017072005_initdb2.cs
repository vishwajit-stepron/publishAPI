using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StepHR365.Migrations
{
    /// <inheritdoc />
    public partial class initdb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(1002), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(1004) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(1006), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(1007) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(1009), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(784), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(788), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(780), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(791) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(799), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(800), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(797), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(801) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(807), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(808), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(806), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(814), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(815), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(813), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified", "JoiningDate", "LastAccess" },
                values: new object[] { new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(821), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(821), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(819), new DateTime(2023, 10, 17, 12, 50, 4, 937, DateTimeKind.Local).AddTicks(822) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
