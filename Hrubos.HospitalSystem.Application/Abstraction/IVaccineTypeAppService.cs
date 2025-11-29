using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Application.Abstraction
{
    public interface IVaccineTypeAppService
    {
        IList<VaccineType> SelectAll();
        void Create(VaccineType vaccineType);
        bool Delete(int id);
        bool Edit(int id, VaccineType vaccineType);
        VaccineType GetById(int id);
    }
}
