using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Application.Abstraction
{
    public interface ISpecializationAppService
    {
        IList<Specialization> SelectAll();
        void Create(Specialization specialization);
        bool Delete(int id);
        bool Edit(int id, Specialization specialization);
        Specialization GetById(int id);
    }
}
