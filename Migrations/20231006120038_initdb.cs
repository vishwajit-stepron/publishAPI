using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StepHR365.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekOff = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeoTracking = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From = table.Column<DateTime>(type: "datetime2", nullable: true),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Institute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionalDocumentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationCertificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeIdentity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    AadhaarNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameInAadhaar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PANNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameInPAN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeIdentity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    EmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionalMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionalEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JoiningDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    JoinedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProbationPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoticePeriod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoiningDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LastThreeSalarySlips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionalDocumentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastThreeSalarySlips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermanentAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermanentAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RecentPhotographs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDProofPanCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressProof = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AadharCard = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PresentAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalDocuments",
                columns: table => new
                {
                    ProfessionalDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResignationTerminationLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousOrganizationAppointmentLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousOrganizationExperienceCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousOrganizationRelievingLetter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalDocuments", x => x.ProfessionalDocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccess = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7572), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7574), 1, "Administrative" },
                    { 2, 1, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7576), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7577), 1, "IT" },
                    { 3, 1, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7578), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7579), 1, "Design" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "DepartmentId", "IsAdmin", "IsDeleted", "JoiningDate", "LastAccess", "ModifiedBy", "Password", "ReportingManager", "Status", "UserEmail", "Username" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7408), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7409), 1, true, false, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7405), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7410), 1, "Sanket@123", "manager1", true, "stepron.sjoshi@gmail.com", "Sanket" },
                    { 2, 1, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7419), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7420), 1, true, false, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7416), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7421), 1, "Amol@123", "manager1", true, "stepron.amolpatil@gmail.com", "Amol" },
                    { 3, 1, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7427), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7428), 1, true, false, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7425), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7428), 1, "Bhaveshree@123", "manager1", true, "stepron.bshinde@gmail.com", "Bhaveshree" },
                    { 4, 1, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7434), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7435), 1, true, false, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7433), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7436), 1, "Sujit@123", "manager1", true, "stepron.sgaikwad@gmail.com", "Sujit" },
                    { 5, 1, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7444), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7444), 1, true, false, new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7442), new DateTime(2023, 10, 6, 17, 30, 38, 444, DateTimeKind.Local).AddTicks(7445), 1, "Pratteek@123", "manager1", true, "stepron.pshauraya@gmail.com", "Pratteek" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentPosition");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "EducationCertificates");

            migrationBuilder.DropTable(
                name: "EmployeeIdentity");

            migrationBuilder.DropTable(
                name: "EmployeeInformation");

            migrationBuilder.DropTable(
                name: "JoiningDetails");

            migrationBuilder.DropTable(
                name: "LastThreeSalarySlips");

            migrationBuilder.DropTable(
                name: "PermanentAddress");

            migrationBuilder.DropTable(
                name: "PersonalDocuments");

            migrationBuilder.DropTable(
                name: "PersonalInformation");

            migrationBuilder.DropTable(
                name: "PresentAddress");

            migrationBuilder.DropTable(
                name: "ProfessionalDocuments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
