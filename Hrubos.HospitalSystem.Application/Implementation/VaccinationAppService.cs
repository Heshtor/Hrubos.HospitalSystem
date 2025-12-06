using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class VaccinationAppService : IVaccinationAppService
    {
        private readonly HospitalSystemDbContext _hospitalSystemDbContext;
        private readonly ISystemSettingsAppService _systemSettingsAppService;

        public VaccinationAppService(HospitalSystemDbContext hospitalSystemDbContext, ISystemSettingsAppService systemSettingsAppService)
        {
            _hospitalSystemDbContext = hospitalSystemDbContext;
            _systemSettingsAppService = systemSettingsAppService;
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
            // Denní limit očkování
            int maxDailyLimit = _systemSettingsAppService.GetIntValue("MaxVaccinationsPerDay", 20);

            // Počet registrovaných očkování pro daný den
            int currentCount = _hospitalSystemDbContext.Vaccinations.Count(v => v.DateTime.Date == vaccination.DateTime.Date);

            // Kontrola kapacity
            if (currentCount >= maxDailyLimit)
            {
                throw new InvalidOperationException($"Kapacita očkování pro datum {vaccination.DateTime.ToShortDateString()} je již naplněna (Limit: {maxDailyLimit}).");
            }

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

            // Denní limit očkování
            int maxDailyLimit = _systemSettingsAppService.GetIntValue("MaxVaccinationsPerDay", 20);

            // Počet registrovaných očkování pro daný den
            int currentCount = _hospitalSystemDbContext.Vaccinations.Count(v => v.DateTime.Date == newVaccination.DateTime.Date && v.Id != id);

            // Kontrola kapacity
            if (currentCount + 1 > maxDailyLimit)
            {
                throw new InvalidOperationException($"Kapacita očkování pro datum {newVaccination.DateTime.ToShortDateString()} je již naplněna (Limit: {maxDailyLimit}).");
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
