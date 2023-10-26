using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using StepHR365.DAL.FileUpload;
using StepHR365.Model.Views;
using StepHR365.Utils;
using StepronEOP.Controllers;
using StepronEOP.Services.UsersServices;
using StepronEOP.Utils;

namespace StepHR365.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IFileuploadService _service;
        private readonly string ControllerName = "FileUpload";
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploadController(ILogger<UsersController> logger, IFileuploadService srv, IWebHostEnvironment webHostEnvironment)
        {
            _service = srv;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        #region Test 

        [HttpPost]
        [Route("UploadToRemote")]
        public async Task<IActionResult> UploadToRemote(IFormFileCollection file, [FromQuery] string EmployeeID)
        {
            try
            { 
                var uploadedFiles = Request.Form.Files;
                var data = await _service.UploadToRemote(uploadedFiles, EmployeeID);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        [HttpGet]
        [Route("GetUploadFilesFromRemote")]
        public async Task<IActionResult> GetUploadFilesFromRemote([FromQuery] string EmployeeID)
        {
            try
            {
                var data = await _service.GetUploadFilesFromRemote(EmployeeID);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        [HttpDelete]
        [Route("DeleteRemoteFile")]
        public async Task<IActionResult> DeleteRemoteFile([FromQuery] string EmployeeID, List<string> fileNames)
        {
            try
            {
                var data = await _service.DeleteRemoteFile(EmployeeID, fileNames);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? String.Empty, ex.Message, String.Empty));
            }
        }

        [HttpGet]
        [Route("/files/download/{EmployeeID}/{fileName}")]
        public async Task<IActionResult> DownloadFile(string EmployeeID, string fileName, string localFilePath)
        {
            try
            {
                var data = await _service.DownloadFileFromRemote(EmployeeID, fileName, localFilePath);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(this.ControllerName + $"=>{this.GetMethodName()}" + (String.IsNullOrEmpty(ex.InnerException?.Message ?? String.Empty) ? ex.Message : ex.InnerException.Message));
                return BadRequest(MiscUtil.HandleControllerError(ex.InnerException?.Message ?? string.Empty, ex.Message, String.Empty));
            }
        }

        [HttpPost("UploadToLocal")]
        public async Task<IActionResult> UploadToLocal(List<IFormFile> imageFiles)
        {
            if (imageFiles == null || imageFiles.Count == 0)
            {
                return BadRequest("No files uploaded.");
            }

            string uploadsFolder = "";

            var result = await _service.uploadToLocal(imageFiles, uploadsFolder);
            return Ok(result);
        }

        #endregion


        [HttpPost("MultiUploadToLocal")]
        public async Task<IActionResult> MultiUploadToLocal(IFormFileCollection file, string EmployeeID)
        {
            var uploadedFiles = Request.Form.Files;
            foreach (IFormFile source in uploadedFiles)
            {
                string filename = source.FileName;
                //string filetype = Path.GetExtension(filename);
                string filepath = _webHostEnvironment.WebRootPath + "\\Upload\\EmployeeDocument" + "\\" + EmployeeID;
                if (!System.IO.Directory.Exists(filepath))
                {
                    System.IO.Directory.CreateDirectory(filepath);
                }

                string imagepath = filepath + "\\" + EmployeeID + filename;
                if (System.IO.File.Exists(imagepath))
                {
                    System.IO.File.Delete(imagepath);
                }

                using (FileStream stream = System.IO.File.Create(imagepath))
                {
                    await source.CopyToAsync(stream);
                }
            }
            return Ok("Uploaded");
        }

    }
}
