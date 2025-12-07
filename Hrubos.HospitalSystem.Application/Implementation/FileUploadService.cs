using Hrubos.HospitalSystem.Application.Abstraction;
using Microsoft.AspNetCore.Http;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class FileUploadService : IFileUploadService
    {
        public string RootPath { get; set; }

        public FileUploadService(string rootPath)
        {
            this.RootPath = rootPath;
        }

        public string FileUpload(IFormFile fileToUpload, string folderNameOnServer)
        {
            string filePathOutput = String.Empty;

            var fileExtension = Path.GetExtension(fileToUpload.FileName);
            var fileNameGenerated = Guid.NewGuid().ToString();

            var fileRelative = Path.Combine(folderNameOnServer, fileNameGenerated + fileExtension);
            var filePath = Path.Combine(this.RootPath, fileRelative);

            Directory.CreateDirectory(Path.Combine(this.RootPath, folderNameOnServer));
            using (Stream stream = new FileStream(filePath, FileMode.Create))
            {
                fileToUpload.CopyTo(stream);
            }

            filePathOutput = Path.DirectorySeparatorChar + fileRelative;

            return filePathOutput;
        }

        public void DeleteFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return;

            var relativePath = path.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            var fullPath = Path.Combine(this.RootPath, relativePath);

            if (File.Exists(fullPath))
            {
                try
                {
                    File.Delete(fullPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Chyba při mazání souboru: {ex.Message}");
                }
            }
        }
    }
}
