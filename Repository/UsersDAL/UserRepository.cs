using Microsoft.EntityFrameworkCore;
using StepHR365.Model;
using StepHR365.Model.Views;
using StepHR365.Utils;
using StepronEOP.Database;
using StepronEOP.Utils;
using System.Linq.Expressions;
using System.Reflection;

namespace StepronEOP.DAL.UsersDAL
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly int maxRecPerPage = 100;

        public UserRepository(AppDbContext ctx)
        {
            _context = ctx;
        }

        #region Users

        public async Task<DALFetchResponseModel<IEnumerable<User_View1>>> FetchUsers(Search2<User_View1> item)
        {
            IQueryable<User_View1> retObjList = _context.User_View1.AsNoTracking();

            return await DbUtil.GenericFetch(item, retObjList, "Id", maxRecPerPage);
        }

        public async Task<IEnumerable<User1_View1>> GetUserswithId(int id)
        {
            return await _context.User1_View1.AsNoTracking().Where(p => p.Id == id).ToListAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserswithEmail(string userEmail)
        {
            return await _context.Users.AsNoTracking().Where(p => p.UserEmail == userEmail).FirstOrDefaultAsync();
        }

        public async Task<User> GetUsersWithUserName(string userName, string password)
        {
            return await _context.Users.AsNoTracking().Where(x => x.UserEmail == userName || x.Username == userName && x.Password == password).FirstOrDefaultAsync();
        }

        public async Task<string> ForgotPasswordsuccess(string email, string CurrentPassword, string NewPassword)
        {
            var userExists = await GetUsersWithUserName(email, CurrentPassword);

            if (userExists == null)
            {
                return "User Doesn't Exists";
            }

            if (userExists.Id > 0)
            {
                userExists.Password = NewPassword;
                userExists.LastAccess = DateTime.Now;
                _context.SaveChanges();
                return "Password Changed" + " " + email;
            }
            return "Failed to Change Password !!!!";
        }

        public async Task<string> loginsuccess(string userNameEmail, string Password)
        {
            var userExists = await GetUsersWithUserName(userNameEmail, Password);

            if (userExists.Password != Password)
            {
                return "Incorrect Details";
            }

            if (userExists == null)
            {
                return "User Doesn't Exists";
            }

            if (userExists.Id > 0)
            {
                userExists.LastAccess = DateTime.Now;
                _context.SaveChanges();
                return "OK";
            }
            else
                return "Failed to Login";
        }

        private async Task<string> SaveUserByAdmin(objectSaveHelper? obj, int? UserId) // if user not exists
        {
            if (obj.User.Id == 0)
            {
                obj.User.Username = obj.EmployeeInformation.EmployeeNo;
                obj.User.UserEmail = obj.PersonalInformation.PersonalEmail;
                obj.User.ReportingManager = obj.CurrentPosition.ReportingTo;
                obj.User.JoiningDate = obj.JoiningDetails.JoinedOn;
                obj.User.Status = true;
                obj.User.IsAdmin = false;
                obj.User.IsDeleted = false;
                obj.User.CreatedBy = UserId;
                obj.User.ModifiedBy = UserId;
                obj.User.DateCreated = DateTime.Now;
                obj.User.DateModified = DateTime.Now;
                obj.User.LastAccess = DateTime.Now;

                string currentDate = DateTime.Now.ToString();

                string generatekey = Guid.NewGuid().ToString();

                obj.User.Password = generatekey;  // Employee Default Password 

                await AddEntity<User>(obj.User);
            }
            else
                return "User Already Exists Try for update with correct Employee ID & Email ID !!!";

            var userAdded = _context.Users.Where(x => x.Username == obj.User.Username || x.UserEmail == obj.User.UserEmail).FirstOrDefault();

            if (userAdded != null)
            {
                obj.EmployeeInformation.UserId = userAdded.Id; // Create record entry in each table 
                obj.PersonalInformation.UserId = userAdded.Id;
                obj.PresentAddress.UserId = userAdded.Id;
                obj.PermanentAddress.UserId = userAdded.Id;
                obj.EmployeeIdentity.UserId = userAdded.Id;
                obj.Education.UserId = userAdded.Id;
                obj.PersonalDocuments.UserId = userAdded.Id;
                obj.JoiningDetails.UserId = userAdded.Id;
                obj.CurrentPosition.UserId = userAdded.Id;
            }

            if (obj.EmployeeInformation != null)
            {
                if (obj.EmployeeInformation.Id == 0)
                    await AddEntity<EmployeeInformation>(obj.EmployeeInformation);
                else
                    await UpdateEntity<EmployeeInformation>(obj.EmployeeInformation);
            }

            if (obj.PersonalInformation != null)
            {
                if (obj.PersonalInformation.Id == 0)
                    await AddEntity<PersonalInformation>(obj.PersonalInformation);
                else
                    await UpdateEntity<PersonalInformation>(obj.PersonalInformation);
            }

            if (obj.PresentAddress != null)
            {
                if (obj.PresentAddress.Id == 0)
                    await AddEntity<PresentAddress>(obj.PresentAddress);
                else
                    await UpdateEntity<PresentAddress>(obj.PresentAddress);
            }

            if (obj.PermanentAddress != null)
            {
                if (obj.PermanentAddress.Id == 0)
                    await AddEntity<PermanentAddress>(obj.PermanentAddress);
                else
                    await UpdateEntity<PermanentAddress>(obj.PermanentAddress);
            }

            if (obj.EmployeeIdentity != null)
            {
                if (obj.EmployeeIdentity.Id == 0)
                    await AddEntity<EmployeeIdentity>(obj.EmployeeIdentity);
                else
                    await UpdateEntity<EmployeeIdentity>(obj.EmployeeIdentity);
            }

            if (obj.Education != null)
            {
                if (obj.Education.Id == 0)
                    await AddEntity<Education>(obj.Education);
                else
                    await UpdateEntity<Education>(obj.Education);
            }

            if (obj.PersonalDocuments != null)
            {
                if (obj.PersonalDocuments.Id == 0)
                    await AddEntity<PersonalDocuments>(obj.PersonalDocuments);
                else
                    await UpdateEntity<PersonalDocuments>(obj.PersonalDocuments);
            }

            if (obj.JoiningDetails != null)
            {
                if (obj.JoiningDetails.Id == 0)
                    await AddEntity<JoiningDetails>(obj.JoiningDetails);
                else
                    await UpdateEntity<JoiningDetails>(obj.JoiningDetails);
            }

            if (obj.CurrentPosition != null)
            {
                if (obj.CurrentPosition.Id == 0)
                    await AddEntity<CurrentPosition>(obj.CurrentPosition);
                else
                    await UpdateEntity<CurrentPosition>(obj.CurrentPosition);
            }

            if (obj.Department != null)
            {
                if (obj.Department.Id == 0)
                    await AddEntity<Departments>(obj.Department);
                else
                    await UpdateEntity<Departments>(obj.Department);
            }

            await _context.SaveChangesAsync();

            return "OK";
        }

        public async Task<string> SaveUser(objectSaveHelper? obj, int? UserId)
        {
            try
            {
                if (UserId == null)
                {
                    return "UserId is Missing";
                }
                var login_user = _context.Users.FirstOrDefault(x => x.Id == UserId);

                // Search for Employee is it present already 
                var user_exits = _context.Users.Where(x => x.Username == obj.User.Username || x.UserEmail == obj.User.UserEmail).FirstOrDefault();

                if (user_exits != null)  // Employee ALready Present -- UPDATE
                {
                    if (obj.User.Id != 0 && login_user.IsAdmin == true) // Only Execute if User is Admin 
                    {
                        user_exits.UserEmail = obj.User.UserEmail ?? user_exits.UserEmail;
                        user_exits.Password = obj.User.Password ?? user_exits.Password;
                        user_exits.ReportingManager = obj.User.ReportingManager ?? user_exits.ReportingManager;
                        user_exits.JoiningDate = obj.User.JoiningDate ?? user_exits.JoiningDate;
                        user_exits.Status = obj.User.Status ?? user_exits.Status;
                        user_exits.IsDeleted = obj.User.IsDeleted ?? user_exits.IsDeleted;
                        user_exits.DateModified = DateTime.Now;
                        user_exits.ModifiedBy = UserId;

                        await _context.SaveChangesAsync();
                    }

                    if (obj.EmployeeInformation != null)
                    {
                        if (obj.EmployeeInformation.Id == 0)
                            await AddEntity<EmployeeInformation>(obj.EmployeeInformation);
                        else
                        {
                            var entity = _context.EmployeeInformation.Where(x => x.Id == obj.EmployeeInformation.Id).FirstOrDefault();

                            if (entity != null)
                            {
                                entity.ProfessionalEmail = obj.EmployeeInformation.ProfessionalEmail;
                                entity.ProfessionalMobile = obj.EmployeeInformation.ProfessionalMobile;
                                await _context.SaveChangesAsync();
                            }
                        }
                    
                    }

                    if (obj.PersonalInformation != null)
                    {
                        if (obj.PersonalInformation.Id == 0)
                        {
                            await AddEntity<PersonalInformation>(obj.PersonalInformation);
                        }
                        else
                        {
                            var entity = _context.PersonalInformation.Where(x => x.Id == obj.PersonalInformation.Id).FirstOrDefault();
                            if (entity != null)
                            {
                                entity.ProfileImage = obj.PersonalInformation.ProfileImage;
                                entity.DOB = obj.PersonalInformation.DOB;
                                entity.Birthday = obj.PersonalInformation.Birthday;
                                entity.BloodGroup = obj.PersonalInformation.BloodGroup;
                                entity.PersonalEmail = obj.PersonalInformation.PersonalEmail;
                                entity.PersonalMobileNumber = obj.PersonalInformation.PersonalMobileNumber;
                                entity.EmergencyNumber = obj.PersonalInformation.EmergencyNumber;
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                   

                    if (obj.PresentAddress != null)
                    {
                        if (obj.PresentAddress.Id == 0)
                            await AddEntity<PresentAddress>(obj.PresentAddress);
                        else
                        {
                            var entity = _context.PresentAddress.Where(x => x.Id == obj.PresentAddress.Id).FirstOrDefault();

                            if (entity != null)
                            {
                                entity.Street = obj.PresentAddress.Street;
                                entity.City = obj.PresentAddress.City;
                                entity.State = obj.PresentAddress.State;
                                entity.Country = obj.PresentAddress.Country;
                                entity.PinCode = obj.PresentAddress.PinCode;
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    
                    if (obj.PermanentAddress != null)
                    {
                        if (obj.PermanentAddress.Id == 0)
                            await AddEntity<PermanentAddress>(obj.PermanentAddress);
                        else
                        {
                            var entity = _context.PermanentAddress.Where(x => x.Id == obj.PermanentAddress.Id).FirstOrDefault();

                            if (entity != null)
                            {
                                entity.Street = obj.PermanentAddress.Street;
                                entity.City = obj.PermanentAddress.City;
                                entity.State = obj.PermanentAddress.State;
                                entity.Country = obj.PermanentAddress.Country;
                                entity.PinCode = obj.PermanentAddress.PinCode;
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    
                    if (obj.PersonalDocuments != null)
                    {
                        if (obj.PersonalDocuments.Id == 0)
                            await AddEntity<PersonalDocuments>(obj.PersonalDocuments);
                        else
                        {
                            var entity = _context.PersonalDocuments.Where(x => x.Id == obj.PersonalDocuments.Id).FirstOrDefault();

                            if (entity != null)
                            {
                                entity.RecentPhotographs = obj.PersonalDocuments.RecentPhotographs;
                                entity.IDProofPanCard = obj.PersonalDocuments.IDProofPanCard;
                                entity.AddressProof = obj.PersonalDocuments.AddressProof;
                                entity.AadharCard = obj.PersonalDocuments.AadharCard;
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    

                    if (obj.Education != null)
                    {
                        if (obj.Education.Id == 0)
                            await AddEntity<Education>(obj.Education);
                        else
                        {
                            var entity = _context.Education.Where(x => x.Id == obj.Education.Id).FirstOrDefault();

                            if (entity != null)
                            {
                                entity.Qualification = obj.Education.Qualification;
                                entity.From = obj.Education.From;
                                entity.To = obj.Education.To;
                                entity.Institute = obj.Education.Institute;
                                entity.Grade = obj.Education.Grade;
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    

                    if (obj.EmployeeIdentity != null)
                    {
                        if (obj.EmployeeIdentity.Id == 0)
                            await AddEntity<EmployeeIdentity>(obj.EmployeeIdentity);
                        else
                        {
                            var entity = _context.EmployeeIdentity.Where(x => x.Id == obj.EmployeeIdentity.Id).FirstOrDefault();

                            if (entity != null)
                            {
                                entity.AadhaarNumber = obj.EmployeeIdentity.AadhaarNumber;
                                entity.NameInAadhaar = obj.EmployeeIdentity.NameInAadhaar;
                                entity.PANNumber = obj.EmployeeIdentity.PANNumber;
                                entity.NameInPAN = obj.EmployeeIdentity.NameInPAN;
                                await _context.SaveChangesAsync();
                            }
                        }
                    }

                    if (obj.JoiningDetails != null && login_user.IsAdmin == true)
                    {
                        if (obj.JoiningDetails.Id == 0)
                            await AddEntity<JoiningDetails>(obj.JoiningDetails);
                        else
                        {
                            var entity = _context.JoiningDetails.Where(x => x.Id == obj.JoiningDetails.Id).FirstOrDefault();

                            if (entity != null)
                            {
                                entity.JoinedOn = obj.JoiningDetails.JoinedOn;
                                entity.ConfirmationDate = obj.JoiningDetails.ConfirmationDate;
                                entity.Status = obj.JoiningDetails.Status;
                                entity.ProbationPeriod = obj.JoiningDetails.ProbationPeriod;
                                entity.NoticePeriod = obj.JoiningDetails.NoticePeriod;
                                await _context.SaveChangesAsync();
                            }
                        }
                    }

                    if (obj.CurrentPosition != null && login_user.IsAdmin == true)
                    {
                        if (obj.CurrentPosition.Id == 0)
                            await AddEntity<CurrentPosition>(obj.CurrentPosition);
                        else
                        {
                            var entity = _context.CurrentPosition.Where(x => x.Id == obj.CurrentPosition.Id).FirstOrDefault();

                            if (entity != null)
                            {
                                entity.Location = obj.CurrentPosition.Location;
                                entity.Designation = obj.CurrentPosition.Designation;
                                entity.ReportingTo = obj.CurrentPosition.ReportingTo;
                                entity.WeekOff = obj.CurrentPosition.WeekOff;
                                entity.GeoTracking = obj.CurrentPosition.GeoTracking;
                                await _context.SaveChangesAsync();
                            }
                        }
                    }

                }
                else // Employee not present (NEW Employee)
                {
                    if (login_user.IsAdmin == true)
                    {
                        var userAdded = await SaveUserByAdmin(obj, UserId);

                        if (userAdded == "OK")
                            return "OK";
                    }
                }

                await _context.SaveChangesAsync();
                return "OK";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<string> AddEntity<TEntity>(TEntity obj) where TEntity : class
        {
            // Create a new entity of the specified type
            TEntity entity = Activator.CreateInstance<TEntity>();

            // Get the type of the entity
            Type entityType = typeof(TEntity);

            // Loop through all the properties in the entity class
            foreach (PropertyInfo propertyInfo in entityType.GetProperties())
            {
                // Check if the property exists in the incoming object (obj)
                PropertyInfo objProperty = obj.GetType().GetProperty(propertyInfo.Name);

                if (objProperty != null && objProperty.GetValue(obj) != null)
                {
                    // Set the property value from the incoming object to the entity
                    propertyInfo.SetValue(entity, objProperty.GetValue(obj));
                }
            }

            // Add the new entity to the appropriate DbSet in the context
            _context.Set<TEntity>().Add(entity);

            // Save the changes to the database
            await _context.SaveChangesAsync();

            return $"{typeof(TEntity).Name} added successfully.";
        }

        private async Task<string> UpdateEntity<TEntity>(TEntity obj) where TEntity : class
        {
            // Check if the entity is already tracked by the context
            if (!_context.ChangeTracker.Entries<TEntity>().Any(e => e.Entity == obj))
            {
                // If it's not tracked, attach the entity to the context
                _context.Attach(obj);
            }

            // Get the entry for the entity
            var entry = _context.Entry(obj);

            // Check which properties have been modified
            var modifiedProperties = entry.OriginalValues.Properties
                .Where(p => !object.Equals(entry.OriginalValues[p], entry.CurrentValues[p]))
                .Select(p => p.Name);

            // Set the state to modified for only the modified properties
            foreach (var propertyName in modifiedProperties)
            {
                entry.Property(propertyName).IsModified = true;
            }

            // Save the changes to the database
            await _context.SaveChangesAsync();

            return $"{typeof(TEntity).Name} updated successfully.";
        }



        //private async Task<string> UpdateUser(User obj)
        //{
        //    // Find the entity to update by Id
        //    User entity = await _context.Users.FindAsync(obj.Id);

        //    if (entity == null)
        //    {
        //        return "The record cannot be found. It might be deleted by another user!";
        //    }

        //    // Get the type of the User entity
        //    Type userType = typeof(User);

        //    // Loop through all the properties in the User class except 'Id'
        //    foreach (PropertyInfo propertyInfo in userType.GetProperties())
        //    {
        //        if (propertyInfo.Name != "Id") // Exclude the 'Id' property
        //        {
        //            // Check if the property exists in the incoming object (obj)
        //            PropertyInfo objProperty = obj.GetType().GetProperty(propertyInfo.Name);

        //            if (objProperty != null && objProperty.GetValue(obj) != null)
        //            {
        //                // Set the property value from the incoming object to the entity
        //                propertyInfo.SetValue(entity, objProperty.GetValue(obj));
        //            }
        //        }
        //    }

        //    // Save the changes to the database
        //    await _context.SaveChangesAsync();

        //    return "User updated successfully.";
        //}

        public async Task<string> DeleteUser(User obj)
        {
            if (obj == null)
                return "Item object is null or empty !";

            if (obj.Id == 0)
                return "Id cannot be zero!";

            EmployeeInformation EmployeeInformation = _context.EmployeeInformation.Where(p => p.UserId == obj.Id).FirstOrDefault();
            _context.EmployeeInformation.Remove(EmployeeInformation);

            PersonalInformation PersonalInformation = _context.PersonalInformation.Where(p => p.UserId == obj.Id).FirstOrDefault();
            _context.PersonalInformation.Remove(PersonalInformation);

            PresentAddress PresentAddress = _context.PresentAddress.Where(p => p.UserId == obj.Id).FirstOrDefault(); ;
            _context.PresentAddress.Remove(PresentAddress);

            PermanentAddress PermanentAddress = _context.PermanentAddress.Where(p => p.UserId == obj.Id).FirstOrDefault(); ;
            _context.PermanentAddress.Remove(PermanentAddress);

            Education Education = _context.Education.Where(p => p.UserId == obj.Id).FirstOrDefault(); ;
            _context.Education.Remove(Education);

            PersonalDocuments PersonalDocuments = _context.PersonalDocuments.Where(p => p.UserId == obj.Id).FirstOrDefault(); ;
            _context.PersonalDocuments.Remove(PersonalDocuments);

            EmployeeIdentity EmployeeIdentity = _context.EmployeeIdentity.Where(p => p.UserId == obj.Id).FirstOrDefault(); ;
            _context.EmployeeIdentity.Remove(EmployeeIdentity);

            JoiningDetails JoiningDetails = _context.JoiningDetails.Where(p => p.UserId == obj.Id).FirstOrDefault(); ;
            _context.JoiningDetails.Remove(JoiningDetails);

            CurrentPosition CurrentPosition = _context.CurrentPosition.Where(p => p.UserId == obj.Id).FirstOrDefault(); ;
            _context.CurrentPosition.Remove(CurrentPosition);

            User User = _context.Users.Where(p => p.Id == obj.Id).FirstOrDefault();
            _context.Users.Remove(User);

            await _context.SaveChangesAsync();

            return "OK";
        }

        #endregion

        #region Departments

        public async Task<DALFetchResponseModel<IEnumerable<Departments_View1>>> FetchDepartments(Search2<Departments_View1> item)
        {
            IQueryable<Departments_View1> retObjList = _context.Departments_View1.AsNoTracking();

            return await DbUtil.GenericFetch(item, retObjList, "Id", maxRecPerPage);
        }

        public async Task<string> SaveDepartment(Departments obj)
        {
            if (obj == null)
                return "The object is null or empty!";

            obj.CreatedBy = 1;
            obj.ModifiedBy = 1;
            obj.DateCreated = DateTime.Now;
            obj.DateModified = DateTime.Now;

            if (obj.Id == 0)
                return await AddDepartment(obj);
            else
            {
                obj.ModifiedBy = 2;
                obj.DateModified = DateTime.Now;
                return await UpdateDepartment(obj);
            }
        }

        private async Task<string> AddDepartment(Departments obj)
        {
            await _context.Departments.AddAsync(obj);
            await _context.SaveChangesAsync();

            return "OK";
        }

        private async Task<string> UpdateDepartment(Departments obj)
        {
            Departments entity = await _context.Departments.FindAsync(obj.Id);

            if (entity == null)
                return "The record cannot be found. It might be deleted by other user!";

            entity.Name = obj.Name;
            entity.ModifiedBy = obj.ModifiedBy;
            entity.DateModified = obj.DateModified;

            await _context.SaveChangesAsync();
            return "OK";
        }

        public async Task<string> DeleteDepartment(Departments obj)
        {
            if (obj == null)
                return "Item object is null or empty !";

            if (obj.Id == 0)
                return "Id cannot be zero!";

            _context.Departments.Remove(obj);
            await _context.SaveChangesAsync();

            return "OK";
        }



        #endregion

    }
}
