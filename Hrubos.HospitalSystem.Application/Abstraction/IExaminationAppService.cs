using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Application.Abstraction
{
    public interface IExaminationAppService
    {
        IList<Examination> SelectAll();
        void Create(Examination examination);
        bool Delete(int id);
        bool Edit(int id, Examination examination);
        Examination GetById(int id);
    }
}
