using StepHR365.Model;
using StepHR365.Model.Logical;
using StepHR365.Model.Views;
using StepHR365.Utils;

namespace StepronEOP.Services.UsersServices
{
    public interface IUserService
    {
        Task<ResponseModel<IEnumerable<User_View1>>> FetchUsers(Search2<User_View1> item);
        Task<ResponseModel<IEnumerable<User1_View1>>> GetUserswithId(int id);
        Task<ResponseModel<List<User>>> GetAllUsers();
        Task<ResponseModel<objectSaveHelper>> SaveUsers(SaveHelperObj<objectSaveHelper> objHelper);
        Task<ResponseModel<User>> LoginUser(LoginModel user);
        Task<ResponseModel<IEnumerable<ObjectResponse<User>>>> DeleteUsers(DeleteHelperObj<User> list);
        Task<ResponseModel<User>> ForgotPassword(forgotPassword list);
        Task<ResponseModel<IEnumerable<Departments_View1>>> FetchDepartments(Search2<Departments_View1> item);
        Task<ResponseModel<IEnumerable<ObjectResponse<Departments>>>> SaveDepartments(SaveHelperObj<Departments> list);
        Task<ResponseModel<IEnumerable<ObjectResponse<Departments>>>> DeleteDepartments(DeleteHelperObj<Departments> list);

    }
}
