using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StepHR365.Model;
using StepHR365.Model.Logical;
using StepHR365.Model.Views;
using StepHR365.Utils;
using StepronEOP.Services.UsersServices;
using StepronEOP.Utils;

namespace StepronEOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserService _service;
        private readonly string ControllerName = "User";

        public UsersController(ILogger<UsersController> logger, IUserService srv)
        {
            _service = srv;
            _logger = logger;
        }

        #region Login

        [HttpPost]
        [Route("LoginUser"), AllowAnonymous]
        public async Task<ActionResult> LoginUser(LoginModel user)
        {
            try
            {
                var obj = await _service.LoginUser(user);

                if (obj.Status == true)
                    return StatusCode(201, obj);
                else
                    return Unauthorized(obj);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        #endregion


        #region Users

        [HttpPost]
        [Route("FetchUsers")]
        public async Task<IActionResult> FetchUsers([FromBody] Search2<User_View1> obj)
        {
            try
            {
                var xx = await _service.FetchUsers(obj);
                return Ok(xx);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        [HttpGet]
        [Route("GetUserswithId/{id}")]
        public async Task<IActionResult> GetUserswithId(int id)
        {
            try
            {
                var xx = await _service.GetUserswithId(id);
                if (xx.Status == true)
                    return Ok(xx);

                return NotFound(xx);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var xx = await _service.GetAllUsers();
                return Ok(xx);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        [HttpPost]
        [Route("SaveUsers")]
        public async Task<ActionResult> SaveUsers([FromBody] SaveHelperObj<objectSaveHelper> list)
        {
            try
            {
                var obj = await _service.SaveUsers(list);
                return StatusCode(201, obj);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        [HttpPost]
        [Route("DeleteUsers")]
        public async Task<ActionResult> DeleteUsers([FromBody] DeleteHelperObj<User> list)
        {
            try
            {
                var obj = await _service.DeleteUsers(list);
                return StatusCode(201, obj);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(forgotPassword list)
        {
            try
            {
                var obj = await _service.ForgotPassword(list);
                return StatusCode(201, obj);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        #endregion

        #region Departments

        [HttpPost]
        [Route("FetchDepartments")]
        public async Task<IActionResult> FetchDepartments([FromBody] Search2<Departments_View1> obj)
        {
            try
            {
                var xx = await _service.FetchDepartments(obj);
                return Ok(xx);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        [HttpPost]
        [Route("SaveDepartments")]
        public async Task<ActionResult> SaveDepartments([FromBody] SaveHelperObj<Departments> list)
        {
            try
            {
                var obj = await _service.SaveDepartments(list);
                return StatusCode(201, obj);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        [HttpPost]
        [Route("DeleteDepartments")]
        public async Task<ActionResult> DeleteDepartments([FromBody] DeleteHelperObj<Departments> list)
        {
            try
            {
                var obj = await _service.DeleteDepartments(list);
                return StatusCode(201, obj);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        #endregion

    }
}
