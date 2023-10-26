using StepHR365.Model;
using StepHR365.Model.Logical;
using StepHR365.Model.Views;
using StepHR365.Utils;
using StepronEOP.DAL.UsersDAL;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;

namespace StepronEOP.Services.UsersServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository _rep)
        {
            _repository = _rep;
        }

        #region Users

        public async Task<ResponseModel<IEnumerable<User_View1>>> FetchUsers(Search2<User_View1> item)
        {
            var list = await _repository.FetchUsers(item);

            return new ResponseModel<IEnumerable<User_View1>>
            {
                Message = "OK",
                Status = true,
                Data = list.Data,
                NrOfRecords = list.NrOfRecords
            };
        }

        public async Task<ResponseModel<IEnumerable<User1_View1>>> GetUserswithId(int id)
        {
            ResponseModel<IEnumerable<User1_View1>> retObj = new ResponseModel<IEnumerable<User1_View1>>();

            try
            {
                var x = await _repository.GetUserswithId(id);

                retObj.Status = true;
                retObj.Data = x;
                retObj.Message = "OK";
                retObj.NrOfRecords = x.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("UserService->GetUsers", ex);
            }
            return retObj;
        }

        public async Task<ResponseModel<List<User>>> GetAllUsers()
        {
            ResponseModel<List<User>> retObj = new ResponseModel<List<User>>();


            try
            {
                var x = await _repository.GetAllUsers();

                retObj.Status = true;
                retObj.Data = x;
                retObj.Message = "OK";
            }
            catch (Exception ex)
            {
                throw new Exception("UserService->GetUsers", ex);
            }
            return retObj;
        }

        public async Task<ResponseModel<objectSaveHelper>> SaveUsers(SaveHelperObj<objectSaveHelper> objHelper)
        {
            var retList = new ResponseModel<objectSaveHelper>();

            if (objHelper == null || objHelper.SaveList == null)
            {
                retList.Message = "The object received is null !";
                return retList;
            }

            if (objHelper.UserId == null)
            {
                retList.Message = "UserId is missing!";
                return retList;
            }

            foreach (var x in objHelper.SaveList)
            {
                if (x == null)
                    continue;

                retList.Data = x;

                var retmsg = await _repository.SaveUser(x, objHelper.UserId);

                if (retmsg != "OK")
                {
                    retList.Status = false;
                    retList.Message = "EmployeeID or MailId is Already used Please Try Different one !!!! ";
                    return retList;
                }
            }

            retList.Status = true;
            retList.Message = "OK";
            retList.NrOfRecords = objHelper.SaveList.Count;
            return retList;
        }

        public async Task<ResponseModel<User>> LoginUser(LoginModel user)
        {
            ResponseModel<User> retObj = new ResponseModel<User>();

            if (user.Username == null || user.UserEmail == null && user.Password == null)
            {
                retObj.Message = "One of the fields value is missing !";
            }

            string? username = user.Username;
            string? email = user.UserEmail;
            string? password = user.Password;

            if (username == null)
            {
                var retMessage = await _repository.loginsuccess(email, password);
                if (retMessage == "OK")
                {
                    var userExists = await _repository.GetUsersWithUserName(email, password);

                    var data = new User
                    {
                        Id = userExists.Id,
                        UserEmail = userExists.UserEmail,
                        Username = user.Username,
                        IsAdmin = userExists.IsAdmin,
                        CreatedBy = userExists.CreatedBy,
                        DateCreated = userExists.DateCreated,
                        DateModified = userExists.DateModified,
                        DepartmentId = userExists.DepartmentId,
                        IsDeleted = userExists.IsDeleted,
                        JoiningDate = userExists.JoiningDate,
                        LastAccess = userExists.LastAccess,
                        ModifiedBy = userExists.ModifiedBy,
                        ReportingManager = userExists.ReportingManager,
                        Status = userExists.Status
                    };
                    retObj.Data = data;
                    retObj.Status = true;
                    retObj.Message = retMessage;
                }
                else
                {
                    retObj.Status = false;
                    retObj.Message = retMessage;
                }
            }
            else
            {
                string retMessage = await _repository.loginsuccess(username, password);
                if (retMessage == "OK")
                {
                    var userExists = await _repository.GetUsersWithUserName(username, password);

                    var data = new User
                    {
                        Id = userExists.Id,
                        UserEmail = userExists.UserEmail,
                        Username = user.Username,
                        IsAdmin = userExists.IsAdmin,
                        CreatedBy = userExists.CreatedBy,
                        DateCreated = userExists.DateCreated,
                        DateModified = userExists.DateModified,
                        DepartmentId = userExists.DepartmentId,
                        IsDeleted = userExists.IsDeleted,
                        JoiningDate = userExists.JoiningDate,
                        LastAccess = userExists.LastAccess,
                        ModifiedBy = userExists.ModifiedBy,
                        ReportingManager = userExists.ReportingManager,
                        Status = userExists.Status
                    };
                    retObj.Data = data;
                    retObj.Status = true;
                    retObj.Message = "Login Success";
                }
                else
                {
                    retObj.Status = false;
                    retObj.Message = retMessage;
                }
            }
            return retObj;
        }

        public async Task<ResponseModel<IEnumerable<ObjectResponse<User>>>> DeleteUsers(DeleteHelperObj<User> list)
        {
            var retList = new ResponseModel<IEnumerable<ObjectResponse<User>>>();

            if (list == null)
            {
                retList.Message = "The object received is null !";
                return retList;
            }

            if (list.DeleteList == null)
            {
                retList.Message = "The object received is null !";
                return retList;
            }

            if (list.DeleteList.Count() == 0)
            {
                retList.Message = "The list cannot be empty !";
                return retList;
            }

            retList.Status = true;
            retList.Message = "OK";
            var listResp = new List<ObjectResponse<User>>();
            foreach (var x in list.DeleteList)
            {
                if (x == null)
                    continue;

                var msg = await DeleteUser(x);
                if (list.ReturnRecordError == true && msg != "OK")
                {
                    var resp = new ObjectResponse<User>
                    {
                        Message = msg,
                        ObjData = x
                    };

                    listResp.Add(resp);
                }

                if (msg != "OK")
                {
                    retList.Status = false;
                    retList.Message = "One or more errors occurred!";
                }
            }

            retList.Data = listResp;
            return retList;
        }

        private async Task<string> DeleteUser(User obj)
        {
            if (obj.Id == 0)
                return "One or more parameters are missing!";

            return await _repository.DeleteUser(obj);
        }

        public async Task<ResponseModel<User>> ForgotPassword(forgotPassword obj)
        {
            ResponseModel<User> retObj = new ResponseModel<User>();

            if (obj == null)
            {
                retObj.Message = "The object received is null!";
            }

            var userExists = await _repository.GetUserswithEmail(obj.Email);

            if (userExists == null)
            {
                retObj.Message = "User Doesn't Exists";
            }

            string retMessage = await _repository.ForgotPasswordsuccess(userExists.UserEmail, obj.CurrentPassword, obj.NewPassword);
            if (retMessage == "OK")
            {
                retObj.Status = true;
                retObj.Message = retMessage;
            }
            else
            {
                retObj.Status = false;
                retObj.Message = retMessage;
            }

            retObj.Status = true;
            retObj.Message = "Password Changed Successfully" + userExists.Id;

            return retObj;
        }

        #endregion

        #region Departments

        public async Task<ResponseModel<IEnumerable<Departments_View1>>> FetchDepartments(Search2<Departments_View1> item)
        {
            var list = await _repository.FetchDepartments(item);

            return new ResponseModel<IEnumerable<Departments_View1>>
            {
                Message = "OK",
                Status = true,
                Data = list.Data,
                NrOfRecords = list.NrOfRecords
            };
        }

        public async Task<ResponseModel<IEnumerable<ObjectResponse<Departments>>>> SaveDepartments(SaveHelperObj<Departments> objHelper)
        {
            var retList = new ResponseModel<IEnumerable<ObjectResponse<Departments>>>();

            if (objHelper == null)
            {
                retList.Message = "The object received is null !";
                return retList;
            }

            if (objHelper.SaveList == null)
            {
                retList.Message = "The object received is null !";
                return retList;
            }

            if (objHelper.SaveList.Count() == 0)
            {
                retList.Message = "The list cannot be empty !";
                return retList;
            }

            retList.Status = true;
            retList.Message = "OK";

            var listResp = new List<ObjectResponse<Departments>>();
            foreach (var x in objHelper.SaveList)
            {
                if (x == null)
                    continue;

                var msg = await _repository.SaveDepartment(x);
                if (objHelper.ReturnRecordId == true || (objHelper.ReturnRecordError == true && msg != "OK"))
                {
                    var resp = new ObjectResponse<Departments>
                    {
                        Message = msg,
                        ObjData = x
                    };

                    listResp.Add(resp);
                }

                if (msg != "OK")
                {
                    retList.Status = false;
                    retList.Message = "One or more errors occurred!";
                }
            }

            retList.Data = listResp;
            return retList;
        }

        public async Task<ResponseModel<IEnumerable<ObjectResponse<Departments>>>> DeleteDepartments(DeleteHelperObj<Departments> list)
        {
            var retList = new ResponseModel<IEnumerable<ObjectResponse<Departments>>>();

            if (list == null)
            {
                retList.Message = "The object received is null !";
                return retList;
            }


            if (list.DeleteList == null)
            {
                retList.Message = "The object received is null !";
                return retList;
            }

            if (list.DeleteList.Count() == 0)
            {
                retList.Message = "The list cannot be empty !";
                return retList;
            }

            retList.Status = true;
            retList.Message = "OK";
            var listResp = new List<ObjectResponse<Departments>>();
            foreach (var x in list.DeleteList)
            {
                if (x == null)
                    continue;

                var msg = await DeleteDepartments(x);
                if (list.ReturnRecordError == true && msg != "OK")
                {
                    var resp = new ObjectResponse<Departments>
                    {
                        Message = msg,
                        ObjData = x
                    };

                    listResp.Add(resp);
                }

                if (msg != "OK")
                {
                    retList.Status = false;
                    retList.Message = "One or more errors occurred!";
                }
            }

            retList.Data = listResp;
            return retList;
        }

        private async Task<string> DeleteDepartments(Departments obj)
        {
            if (obj.Id == 0)
                return "One or more parameters are missing!";

            return await _repository.DeleteDepartment(obj);
        }



        #endregion

        public static string DriveUploadBasic(string filePath)
        {
            try
            {
                /* Load pre-authorized user credentials from the environment.
                 TODO(developer) - See https://developers.google.com/identity for
                 guides on implementing OAuth2 for your application. */
                GoogleCredential credential = GoogleCredential.GetApplicationDefault()
                    .CreateScoped(DriveService.Scope.Drive);

                // Create Drive API service.
                var service = new DriveService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Drive API Snippets"
                });

                // Upload file photo.jpg on drive.
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = "photo.jpg"
                };
                FilesResource.CreateMediaUpload request;
                // Create a new file on drive.
                using (var stream = new FileStream(filePath,
                           FileMode.Open))
                {
                    // Create a new file, with metadata and stream.
                    request = service.Files.Create(
                        fileMetadata, stream, "image/jpeg");
                    request.Fields = "id";
                    request.Upload();
                }

                var file = request.ResponseBody;
                // Prints the uploaded file id.
                Console.WriteLine("File ID: " + file.Id);
                return file.Id;
            }
            catch (Exception e)
            {
                // TODO(developer) - handle error appropriately
                if (e is AggregateException)
                {
                    Console.WriteLine("Credential Not found");
                }
                else if (e is FileNotFoundException)
                {
                    Console.WriteLine("File not found");
                }
                else
                {
                    throw;
                }
            }
            return null;
        }

    }
}
