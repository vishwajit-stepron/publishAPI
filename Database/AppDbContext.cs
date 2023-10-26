using Microsoft.EntityFrameworkCore;
using StepHR365.Model;
using StepHR365.Model.Views;

namespace StepronEOP.Database
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CurrentPosition>()
            .HasIndex(e => e.UserId) // Property to be indexed
            .IsUnique(); // Specify that it should be a unique index

            modelBuilder.Entity<Education>()
           .HasIndex(e => e.UserId)
           .IsUnique();

            modelBuilder.Entity<EducationCertificates>()
          .HasIndex(e => e.UserId)
          .IsUnique();

            modelBuilder.Entity<EmployeeIdentity>()
          .HasIndex(e => e.UserId)
          .IsUnique();

            modelBuilder.Entity<EmployeeInformation>()
          .HasIndex(e => e.UserId)
          .IsUnique();

            modelBuilder.Entity<JoiningDetails>()
          .HasIndex(e => e.UserId)
          .IsUnique();

            modelBuilder.Entity<PersonalDocuments>()
          .HasIndex(e => e.UserId)
          .IsUnique();

            modelBuilder.Entity<PersonalInformation>()
          .HasIndex(e => e.UserId)
          .IsUnique();

            modelBuilder.Entity<PresentAddress>()
          .HasIndex(e => e.UserId)
          .IsUnique();

            modelBuilder.Entity<User>()
        .HasIndex(e => e.UserEmail)
        .IsUnique();

            modelBuilder.Entity<EmployeeInformation>()
       .HasIndex(e => e.EmployeeNo)
       .IsUnique();


            modelBuilder.Entity<Departments_View1>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("Departments_View1");
            });

            modelBuilder.Entity<User_View1>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("User_View1");
            });

            modelBuilder.Entity<User1_View1>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("User1_View1");
            });

            // Seed the User entity
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    DepartmentId = 1,
                    UserEmail = "stepron.sjoshi@gmail.com",
                    Username = "Sanket",
                    Password = "Sanket@123",
                    ReportingManager = "manager1",
                    JoiningDate = DateTime.Now,
                    Status = true,
                    IsAdmin = true,
                    IsDeleted = false,
                    CreatedBy = 1,
                    DateCreated = DateTime.Now,
                    ModifiedBy = 1,
                    DateModified = DateTime.Now,
                    LastAccess = DateTime.Now
                },
                 new User
                 {
                     Id = 2,
                     DepartmentId = 1,
                     UserEmail = "stepron.amolpatil@gmail.com",
                     Username = "Amol",
                     Password = "Amol@123",
                     ReportingManager = "manager1",
                     JoiningDate = DateTime.Now,
                     Status = true,
                     IsAdmin = true,
                     IsDeleted = false,
                     CreatedBy = 1,
                     DateCreated = DateTime.Now,
                     ModifiedBy = 1,
                     DateModified = DateTime.Now,
                     LastAccess = DateTime.Now
                 },
                  new User
                  {
                      Id = 3,
                      DepartmentId = 1,
                      UserEmail = "stepron.bshinde@gmail.com",
                      Username = "Bhaveshree",
                      Password = "Bhaveshree@123",
                      ReportingManager = "manager1",
                      JoiningDate = DateTime.Now,
                      Status = true,
                      IsAdmin = true,
                      IsDeleted = false,
                      CreatedBy = 1,
                      DateCreated = DateTime.Now,
                      ModifiedBy = 1,
                      DateModified = DateTime.Now,
                      LastAccess = DateTime.Now
                  },
                   new User
                   {
                       Id = 4,
                       DepartmentId = 1,
                       UserEmail = "stepron.sgaikwad@gmail.com",
                       Username = "Sujit",
                       Password = "Sujit@123",
                       ReportingManager = "manager1",
                       JoiningDate = DateTime.Now,
                       Status = true,
                       IsAdmin = true,
                       IsDeleted = false,
                       CreatedBy = 1,
                       DateCreated = DateTime.Now,
                       ModifiedBy = 1,
                       DateModified = DateTime.Now,
                       LastAccess = DateTime.Now
                   },
                   new User
                   {
                       Id = 5,
                       DepartmentId = 1,
                       UserEmail = "stepron.pshauraya@gmail.com",
                       Username = "Pratteek",
                       Password = "Pratteek@123",
                       ReportingManager = "manager1",
                       JoiningDate = DateTime.Now,
                       Status = true,
                       IsAdmin = true,
                       IsDeleted = false,
                       CreatedBy = 1,
                       DateCreated = DateTime.Now,
                       ModifiedBy = 1,
                       DateModified = DateTime.Now,
                       LastAccess = DateTime.Now
                   }
            );

            modelBuilder.Entity<Departments>().HasData(
                new Departments
                {
                    Id = 1,
                    Name = "Administrative",
                    CreatedBy = 1,
                    DateCreated = DateTime.Now,
                    ModifiedBy = 1,
                    DateModified = DateTime.Now,
                },
                 new Departments
                 {
                     Id = 2,
                     Name = "IT",
                     CreatedBy = 1,
                     DateCreated = DateTime.Now,
                     ModifiedBy = 1,
                     DateModified = DateTime.Now,
                 },
                  new Departments
                  {
                      Id = 3,
                      Name = "Design",
                      CreatedBy = 1,
                      DateCreated = DateTime.Now,
                      ModifiedBy = 1,
                      DateModified = DateTime.Now,
                  }
            );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<EmployeeInformation> EmployeeInformation { get; set; }
        public DbSet<PersonalInformation> PersonalInformation { get; set; }
        public DbSet<PresentAddress> PresentAddress { get; set; }
        public DbSet<PermanentAddress> PermanentAddress { get; set; }
        public DbSet<EmployeeIdentity> EmployeeIdentity { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<PersonalDocuments> PersonalDocuments { get; set; }
        public DbSet<JoiningDetails> JoiningDetails { get; set; }
        public DbSet<CurrentPosition> CurrentPosition { get; set; }
        public DbSet<ProfessionalDocuments> ProfessionalDocuments { get; set; }
        public DbSet<LastThreeSalarySlips> LastThreeSalarySlips { get; set; }
        public DbSet<EducationCertificates> EducationCertificates { get; set; }
        public DbSet<User_View1> User_View1 { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Departments_View1> Departments_View1 { get; set; }
        public DbSet<User1_View1> User1_View1 { get; set; }
    }
}
