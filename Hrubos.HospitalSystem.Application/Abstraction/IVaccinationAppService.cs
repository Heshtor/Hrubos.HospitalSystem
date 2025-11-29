using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Application.Abstraction
{
    public interface IVaccinationAppService
    {
        IList<Vaccination> SelectAll();
        void Create(Vaccination vaccination);
        bool Delete(int id);
        bool Edit(int id, Vaccination vaccination);
        Vaccination GetById(int id);
    }
}
