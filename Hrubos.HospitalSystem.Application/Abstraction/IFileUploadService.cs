using Microsoft.AspNetCore.Http;

namespace Hrubos.HospitalSystem.Application.Abstraction
{
    public interface IFileUploadService
    {
        string FileUpload(IFormFile fileToUpload, string folderNameOnServer);
        void DeleteFile(string path);
    }
}
