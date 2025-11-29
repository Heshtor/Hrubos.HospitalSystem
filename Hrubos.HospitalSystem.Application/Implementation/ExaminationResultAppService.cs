using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Database;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class ExaminationResultAppService : IExaminationResultAppService
    {
        HospitalSystemDbContext _hospitalSystemDbContext;
        IFileUploadService _fileUploadService;

        public ExaminationResultAppService(HospitalSystemDbContext hospitalSystemDbContext, IFileUploadService fileUploadService)
        {
            _hospitalSystemDbContext = hospitalSystemDbContext;
            _fileUploadService = fileUploadService;
        }

        public IList<ExaminationResult> SelectAll()
        {
            return _hospitalSystemDbContext.ExaminationResults.ToList();
        }

        public void Create(ExaminationResult examinationResult)
        {
            if (examinationResult.Attachment != null)
            {
                string attachmentSrc = _fileUploadService.FileUpload(examinationResult.Attachment, Path.Combine("attachments", "examinationResults"));
                examinationResult.AttachmentSrc = attachmentSrc;
            }

            _hospitalSystemDbContext.ExaminationResults.Add(examinationResult);
            _hospitalSystemDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            var examinationResult = GetById(id);

            if (examinationResult != null)
            {
                _hospitalSystemDbContext.ExaminationResults.Remove(examinationResult);
                _hospitalSystemDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public ExaminationResult GetById(int id)
        {
            return _hospitalSystemDbContext.ExaminationResults.FirstOrDefault(e => e.Id == id);
        }

        public bool Edit(int id, ExaminationResult newExaminationResult)
        {
            bool updated = false;

            var examinationResult = GetById(id);

            if (examinationResult != null && newExaminationResult.Attachment != null)
            {
                string attachmentSrc = _fileUploadService.FileUpload(newExaminationResult.Attachment, Path.Combine("attachments", "examinationResults"));
                newExaminationResult.AttachmentSrc = attachmentSrc;

                _hospitalSystemDbContext.Entry(examinationResult).CurrentValues.SetValues(newExaminationResult);
                _hospitalSystemDbContext.SaveChanges();
                updated = true;
            }

            return updated;
        }
    }
}
