using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class VaccinationAppService : IVaccinationAppService
    {
        private readonly HospitalSystemDbContext _hospitalSystemDbContext;

        public VaccinationAppService(HospitalSystemDbContext hospitalSystemDbContext)
        {
            _hospitalSystemDbContext = hospitalSystemDbContext;
        }

        public IList<Vaccination> SelectAll()
        {
            return _hospitalSystemDbContext.Vaccinations
                .Include(v => v.VaccineType)
                .Include(v => v.Patient)
                .ToList();
        }

        public void Create(Vaccination vaccination)
        {
            _hospitalSystemDbContext.Vaccinations.Add(vaccination);
            _hospitalSystemDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            var vaccination = GetById(id);

            if (vaccination != null)
            {
                _hospitalSystemDbContext.Vaccinations.Remove(vaccination);
                _hospitalSystemDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public bool Edit(int id, Vaccination newVaccination)
        {
            var vaccination = GetById(id);

            if (vaccination == null)
            {
                return false;
            }

            _hospitalSystemDbContext.Entry(vaccination).CurrentValues.SetValues(newVaccination);
            _hospitalSystemDbContext.SaveChanges();

            return true;
        }

        public Vaccination GetById(int id)
        {
            return _hospitalSystemDbContext.Vaccinations.FirstOrDefault(e => e.Id == id);
        }
    }
}
