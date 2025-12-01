using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class DoctorPatientAppService : IDoctorPatientAppService
    {
        private readonly HospitalSystemDbContext _hospitalSystemDbContext;

        public DoctorPatientAppService(HospitalSystemDbContext hospitalSystemDbContext)
        {
            _hospitalSystemDbContext = hospitalSystemDbContext;
        }

        public IList<DoctorPatient> SelectAll()
        {
            return _hospitalSystemDbContext.DoctorPatients
                .Include(dp => dp.Doctor)
                .Include(dp => dp.Patient)
                .ToList();
        }

        public void Create(DoctorPatient doctorPatient)
        {
            _hospitalSystemDbContext.DoctorPatients.Add(doctorPatient);
            _hospitalSystemDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            var doctorPatient = GetById(id);

            if (doctorPatient != null)
            {
                _hospitalSystemDbContext.DoctorPatients.Remove(doctorPatient);
                _hospitalSystemDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public bool Edit(int id, DoctorPatient newDoctorPatient)
        {
            var doctorPatient = GetById(id);

            if (doctorPatient == null)
            {
                return false;
            }

            _hospitalSystemDbContext.Entry(doctorPatient).CurrentValues.SetValues(newDoctorPatient);
            _hospitalSystemDbContext.SaveChanges();

            return true;
        }

        public DoctorPatient GetById(int id)
        {
            return _hospitalSystemDbContext.DoctorPatients.FirstOrDefault(e => e.Id == id);
        }
    }
}
