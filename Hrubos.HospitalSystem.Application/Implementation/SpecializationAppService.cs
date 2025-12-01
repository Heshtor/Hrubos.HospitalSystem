using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class SpecializationAppService : ISpecializationAppService
    {
        private readonly HospitalSystemDbContext _hospitalSystemDbContext;

        public SpecializationAppService(HospitalSystemDbContext hospitalSystemDbContext)
        {
            _hospitalSystemDbContext = hospitalSystemDbContext;
        }

        public IList<Specialization> SelectAll()
        {
            return _hospitalSystemDbContext.Specializations
                .Include(s => s.Doctors)
                .ToList();
        }

        public void Create(Specialization specialization)
        {
            _hospitalSystemDbContext.Specializations.Add(specialization);
            _hospitalSystemDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            var specialization = GetById(id);

            if (specialization != null)
            {
                _hospitalSystemDbContext.Specializations.Remove(specialization);
                _hospitalSystemDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public bool Edit(int id, Specialization newSpecialization)
        {
            var specialization = GetById(id);

            if (specialization == null)
            {
                return false;
            }

            _hospitalSystemDbContext.Entry(specialization).CurrentValues.SetValues(newSpecialization);
            _hospitalSystemDbContext.SaveChanges();

            return true;
        }

        public Specialization GetById(int id)
        {
            return _hospitalSystemDbContext.Specializations.FirstOrDefault(e => e.Id == id);
        }
    }
}
