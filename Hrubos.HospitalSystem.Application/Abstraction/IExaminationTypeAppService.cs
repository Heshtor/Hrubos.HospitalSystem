using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Application.Abstraction
{
    public interface IExaminationTypeAppService
    {
        IList<ExaminationType> SelectAll();
        void Create(ExaminationType examinationType);
    }
}
