using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class ExaminationTypeAppService : IExaminationTypeAppService
    {
        private readonly HospitalSystemDbContext _hospitalSystemDbContext;

        public ExaminationTypeAppService(HospitalSystemDbContext hospitalSystemDbContext)
        {
            _hospitalSystemDbContext = hospitalSystemDbContext;
        }

        public IList<ExaminationType> SelectAll()
        {
            return _hospitalSystemDbContext.ExaminationTypes
                .Include(et => et.Examinations)
                .ToList();
        }

        public void Create(ExaminationType examinationType)
        {
            _hospitalSystemDbContext.ExaminationTypes.Add(examinationType);
            _hospitalSystemDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            var examinationType = GetById(id);

            if (examinationType != null)
            {
                _hospitalSystemDbContext.ExaminationTypes.Remove(examinationType);
                _hospitalSystemDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public bool Edit(int id, ExaminationType newExaminationType)
        {
            var examinationType = GetById(id);

            if (examinationType == null)
            {
                return false;
            }

            _hospitalSystemDbContext.Entry(examinationType).CurrentValues.SetValues(newExaminationType);
            _hospitalSystemDbContext.SaveChanges();

            return true;
        }

        public ExaminationType GetById(int id)
        {
            return _hospitalSystemDbContext.ExaminationTypes.FirstOrDefault(e => e.Id == id);
        }
    }
}
