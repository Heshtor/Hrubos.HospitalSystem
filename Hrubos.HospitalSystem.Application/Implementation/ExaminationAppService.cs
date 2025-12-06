using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class ExaminationAppService : IExaminationAppService
    {
        private readonly HospitalSystemDbContext _hospitalSystemDbContext;

        public ExaminationAppService(HospitalSystemDbContext hospitalSystemDbContext)
        {
            _hospitalSystemDbContext = hospitalSystemDbContext;
        }

        public IList<Examination> SelectAll()
        {
            return _hospitalSystemDbContext.Examinations
                .Include(e => e.ExaminationType)
                .Include(e => e.Result)
                .Include(e => e.Patient)
                .Include(e => e.Doctor)
                .ToList();
        }

        public void Create(Examination examination)
        {
            MaxCapacityReached(examination.DoctorId, examination.DateTime, null);

            _hospitalSystemDbContext.Examinations.Add(examination);
            _hospitalSystemDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            var examination = GetById(id);

            if (examination != null)
            {
                _hospitalSystemDbContext.Examinations.Remove(examination);
                _hospitalSystemDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public bool Edit(int id, Examination newExamination)
        {
            var examination = GetById(id);

            if (examination == null)
            {
                return false;
            }

            bool isSameDoctor = examination.DoctorId == newExamination.DoctorId;
            bool isSameDay = examination.DateTime.Date == newExamination.DateTime.Date;

            if (!isSameDoctor || !isSameDay) // pokud se mění doktor nebo den
            {
                MaxCapacityReached(newExamination.DoctorId, newExamination.DateTime, id);
            }

            _hospitalSystemDbContext.Entry(examination).CurrentValues.SetValues(newExamination);
            _hospitalSystemDbContext.SaveChanges();

            return true;
        }

        public Examination GetById(int id)
        {
            return _hospitalSystemDbContext.Examinations.FirstOrDefault(e => e.Id == id);
        }

        private void MaxCapacityReached(int? doctorId, DateTime date, int? excludeExaminationId)
        {
            // Pokud vyšetření nemá přiřazeného doktora, limit nekontrolujeme
            if (doctorId == null) return;

            var doctor = _hospitalSystemDbContext.Users.FirstOrDefault(u => u.Id == doctorId);

            if (doctor == null) return;

            // Maximální počet vyšetření za den pro daného doktora
            int maxLimit = doctor.MaxExaminationPerDay ?? 0;

            DateTime dayStart = date.Date;
            DateTime dayEnd = dayStart.AddDays(1);

            // Počet registrovaných vyšetření pro daný den u doktora
            var query = _hospitalSystemDbContext.Examinations.Where(e => e.DoctorId == doctorId && e.DateTime >= dayStart && e.DateTime < dayEnd);

            // Pokud je prováděna editace, musím odečíst sám sebe z počtu
            if (excludeExaminationId.HasValue)
            {
                query = query.Where(e => e.Id != excludeExaminationId.Value);
            }

            int currentCount = query.Count();

            if (currentCount >= maxLimit)
            {
                throw new InvalidOperationException($"Kapacita vyšetření pro doktora {doctor.UserName} na den {date.ToShortDateString()} je již naplněna (Limit: {maxLimit}).");
            }
        }
    }
}
