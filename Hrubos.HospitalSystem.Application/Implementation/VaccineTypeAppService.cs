using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Database;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class VaccineTypeAppService : IVaccineTypeAppService
    {
        private readonly HospitalSystemDbContext _hospitalSystemDbContext;

        public VaccineTypeAppService(HospitalSystemDbContext hospitalSystemDbContext)
        {
            _hospitalSystemDbContext = hospitalSystemDbContext;
        }

        public IList<VaccineType> SelectAll()
        {
            return _hospitalSystemDbContext.VaccineTypes.ToList();
        }

        public void Create(VaccineType vaccineType)
        {
            _hospitalSystemDbContext.VaccineTypes.Add(vaccineType);
            _hospitalSystemDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            var vaccineType = GetById(id);

            if (vaccineType != null)
            {
                _hospitalSystemDbContext.VaccineTypes.Remove(vaccineType);
                _hospitalSystemDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public bool Edit(int id, VaccineType newVaccineType)
        {
            var vaccineType = GetById(id);

            if (vaccineType == null)
            {
                return false;
            }

            _hospitalSystemDbContext.Entry(vaccineType).CurrentValues.SetValues(newVaccineType);
            _hospitalSystemDbContext.SaveChanges();

            return true;
        }

        public VaccineType GetById(int id)
        {
            return _hospitalSystemDbContext.VaccineTypes.FirstOrDefault(e => e.Id == id);
        }
    }
}
