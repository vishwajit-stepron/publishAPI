using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using FluentFTP;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using StepHR365.Model.ResponseModel;
using StepHR365.Utils;

namespace StepHR365.DAL.FileUpload
{
    public class FileUploadServices : IFileuploadService
    {
        private readonly static string _ftpServer = "stephr365.com";
        private readonly static string _ftpUsername = "UploadFileAccess";
        private readonly static string _ftpPassword = "Stepron@123";
        private readonly static string _remoteDirectory = "/UploadFile";

        public async Task<UploadResponse<string>> UploadToRemote(IFormFileCollection uploadedFiles, string EmployeeID = "E101")
        {
            try
            {
                UploadResponse<string> responseModel = new UploadResponse<string>();

                int passcount = 0;int errorcount = 0;

                List<string> uploadList = new List<string>();

                foreach (IFormFile source in uploadedFiles)
                {
                    string remoteBasePath = "/Document";
                    string employeePath = $"{remoteBasePath}/{EmployeeID}";
                    string filename = source.FileName;
                    string imagepath = $"{employeePath}/{filename}";

                    // Document Folder 
                    FtpWebRequest createDirectoriesRequest = (FtpWebRequest)WebRequest.Create(new Uri($"ftp://{_ftpServer}/{remoteBasePath}"));
                    createDirectoriesRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                    createDirectoriesRequest.Credentials = new NetworkCredential(_ftpUsername, _ftpPassword);

                    try
                    {
                        FtpWebResponse createDirectoriesResponse = (FtpWebResponse)await createDirectoriesRequest.GetResponseAsync();
                        createDirectoriesResponse.Close();
                    }
                    catch (WebException ex)
                    {
                        if (!((FtpWebResponse)ex.Response).StatusCode.Equals(FtpStatusCode.ActionNotTakenFileUnavailable))
                        {
                            errorcount++;
                            throw;
                        }
                    }

                    // Employee Based Folder 
                    FtpWebRequest createEmployeeDirectoryRequest = (FtpWebRequest)WebRequest.Create(new Uri($"ftp://{_ftpServer}/{employeePath}"));
                    createEmployeeDirectoryRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                    createEmployeeDirectoryRequest.Credentials = new NetworkCredential(_ftpUsername, _ftpPassword);

                    try
                    {
                        FtpWebResponse createEmployeeDirectoryResponse = (FtpWebResponse)await createEmployeeDirectoryRequest.GetResponseAsync();
                        createEmployeeDirectoryResponse.Close();
                    }
                    catch (WebException ex)
                    {
                        if (!((FtpWebResponse)ex.Response).StatusCode.Equals(FtpStatusCode.ActionNotTakenFileUnavailable))
                        {
                            errorcount++;
                            throw;
                        }
                    }

                    // Upload the image
                    FtpWebRequest uploadRequest = (FtpWebRequest)WebRequest.Create(new Uri($"ftp://{_ftpServer}/{imagepath}"));
                    uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
                    uploadRequest.Credentials = new NetworkCredential(_ftpUsername, _ftpPassword);
                    uploadRequest.UsePassive = true;
                    uploadRequest.UseBinary = true;
                    uploadRequest.KeepAlive = false;

                    using (Stream requestStream = await uploadRequest.GetRequestStreamAsync())
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        await source.CopyToAsync(memoryStream);
                        memoryStream.Seek(0, SeekOrigin.Begin); // Reset the stream position
                        await memoryStream.CopyToAsync(requestStream);
                    }

                    using (FtpWebResponse response = (FtpWebResponse)await uploadRequest.GetResponseAsync())
                    {
                        Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
                        passcount++;
                    }

                    uploadList.Add(filename);
                }


                responseModel.ErrorCount = errorcount;
                responseModel.SuccessCount = passcount;
                responseModel.Status = true;

                if(passcount <= 1) {
                responseModel.FirstFile = uploadList[0];
                }

                responseModel.ListData = uploadList;
                return responseModel;
            }
            catch (WebException ex)
            {
                // Handle FTP-related exceptions here
                Console.WriteLine($"FTP Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Handle other exceptions here
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<List<string>> GetUploadFilesFromRemote(string EmployeeID)
        {
            List<string> fileList = new List<string>();

            try
            {
                string remoteBasePath = "/Document";
                string employeePath = $"{remoteBasePath}/{EmployeeID}";

                // Create an FTP request to list directory details
                FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(new Uri($"ftp://{_ftpServer}/{employeePath}"));
                listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                listRequest.Credentials = new NetworkCredential(_ftpUsername, _ftpPassword);

                // Get the response and read the directory listing
                FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse();
                using (Stream responseStream = listResponse.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        // Extract the file name from the directory listing
                        string fileName = line.Substring(line.LastIndexOf(' ') + 1).Trim();
                        fileList.Add(fileName);
                    }
                }
                listResponse.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return fileList;
        }
        public async Task<UploadResponse<string>> DeleteRemoteFile(string EmployeeID, List<string> fileNames)
        {
            try
            {
                UploadResponse<string> responseModel = new UploadResponse<string>();

                int passcount = 0; int errorcount = 0;

                List<string> deletelist = new List<string>();

                foreach (var fileName in fileNames)
                {

                    string remoteBasePath = "/Document";
                    string employeePath = $"{remoteBasePath}/{EmployeeID}";
                    string filePath = $"{employeePath}/{fileName}";

                    // Create an FTP request to delete the file
                    FtpWebRequest deleteFileRequest = (FtpWebRequest)WebRequest.Create(new Uri($"ftp://{_ftpServer}/{filePath}"));
                    deleteFileRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                    deleteFileRequest.Credentials = new NetworkCredential(_ftpUsername, _ftpPassword);

                    Console.WriteLine($"FTP URI: ftp://{_ftpServer}/{filePath}");

                    // Get the response and check the status
                    FtpWebResponse deleteFileResponse = (FtpWebResponse)await deleteFileRequest.GetResponseAsync();
                    deleteFileResponse.Close();

                    // Check if the file was deleted successfully (status code 250)
                    if (deleteFileResponse.StatusCode == FtpStatusCode.FileActionOK)
                    {
                        passcount++;
                    }
                    else
                    {
                        errorcount++;
                    }
                    deletelist.Add(fileName);
                }
                responseModel.Status = true;
                responseModel.ErrorCount = errorcount;
                responseModel.SuccessCount = passcount;
                responseModel.ListData = deletelist;
                responseModel.Message = "Successfully Deleted";
                return responseModel; 
            }
            catch (WebException ex)
            {
                // Handle FTP-related exceptions here
                Console.WriteLine($"FTP Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Handle other exceptions here
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> DownloadFileFromRemote(string EmployeeID, string fileName, string localFilePath)
        {
            try
            {
                string remoteBasePath = "/Document";
                string employeePath = $"{remoteBasePath}/{EmployeeID}";
                string remoteFilePath = $"{employeePath}/{fileName}";

                // Create an FTP request to download the file
                FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(new Uri($"ftp://{_ftpServer}/{remoteFilePath}"));
                downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                downloadRequest.Credentials = new NetworkCredential(_ftpUsername, _ftpPassword);

                // Get the response and download the file
                FtpWebResponse downloadResponse = (FtpWebResponse)await downloadRequest.GetResponseAsync();

                // Check if the download was successful (Status code 226 indicates a successful transfer)
                if (downloadResponse.StatusCode == FtpStatusCode.ClosingData)
                {
                    using (Stream responseStream = downloadResponse.GetResponseStream())
                    {
                        if (!File.Exists(localFilePath))
                        {
                            using (FileStream localFileStream = new FileStream(localFilePath, FileMode.CreateNew))
                            {
                                byte[] buffer = new byte[8192];
                                int bytesRead;
                                while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    localFileStream.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                    }

                    downloadResponse.Close();
                    return true; // File downloaded successfully
                }
                else
                {
                    Console.WriteLine($"FTP Error: {downloadResponse.StatusDescription}");
                    downloadResponse.Close();
                    return false; // File download failed
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine($"FTP Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<ResponseModel<string>> uploadToLocal(List<IFormFile> imageFiles, string uploadsFolder)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>()
            {
                Message = string.Empty,
            };

            var results = new List<string>();

            foreach (var imageFile in imageFiles)
            {

                if (imageFile == null || imageFile.Length == 0)
                {
                    results.Add("No file uploaded.");
                    continue; // Skip to the next file
                }

                uploadsFolder = "D:\\ImageUploadFiles";

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                results.Add("Image uploaded successfully!");
            }

            responseModel.Status = true;
            responseModel.Message = "Image uploaded successfully!";
            responseModel.ListData = results;
            return responseModel;
        }

  
        private Stream ConvertFormFileToStream(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null; 

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return memoryStream;
            }
        }
    }
}