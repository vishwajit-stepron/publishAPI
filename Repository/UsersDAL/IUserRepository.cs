using StepHR365.Model;
using StepHR365.Model.Views;
using StepHR365.Utils;

namespace StepronEOP.DAL.UsersDAL
{
    public interface IUserRepository
    {
        Task<DALFetchResponseModel<IEnumerable<User_View1>>> FetchUsers(Search2<User_View1> item);
        Task<IEnumerable<User1_View1>> GetUserswithId(int id);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserswithEmail(string userEmail);
        Task<User> GetUsersWithUserName(string userName, string password);
        Task<string> SaveUser(objectSaveHelper? obj,int? UserId);
        Task<string> DeleteUser(User obj);
        Task<string> loginsuccess(string userNameEmail, string Password);
        Task<string> ForgotPasswordsuccess(string email, string CurrentPassword, string NewPassword);
        Task<DALFetchResponseModel<IEnumerable<Departments_View1>>> FetchDepartments(Search2<Departments_View1> item);
        Task<string> SaveDepartment(Departments obj);
        Task<string> DeleteDepartment(Departments obj);

    }
}
