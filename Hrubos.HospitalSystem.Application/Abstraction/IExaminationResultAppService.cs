using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Application.Abstraction
{
    public interface IExaminationResultAppService
    {
        IList<ExaminationResult> SelectAll();
        IList<ExaminationResult> SelectForExamination(int examinationId);
        IList<Examination> SelectAllExaminations();
        void Create(ExaminationResult examinationResult);
        bool Delete(int id);
        bool Edit(int id, ExaminationResult examinationResult);
        ExaminationResult GetById(int id);
    }
}
