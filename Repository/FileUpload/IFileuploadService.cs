using StepHR365.Model.ResponseModel;
using StepHR365.Utils;

namespace StepHR365.DAL.FileUpload
{
    public interface IFileuploadService
    {
        // REMOTE 
        Task<UploadResponse<string>> UploadToRemote(IFormFileCollection uploadedFiles, string EmployeeID);
        Task<List<string>> GetUploadFilesFromRemote(string EmployeeID);
        Task<UploadResponse<string>> DeleteRemoteFile(string EmployeeID , List<string> fileNames);
        Task<bool> DownloadFileFromRemote(string EmployeeID, string fileName, string localFilePath);

        // LOCAL 
        Task<ResponseModel<string>> uploadToLocal(List<IFormFile> imageFiles, string uploadsFolder);
    }
}
