using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Database;

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
            return _hospitalSystemDbContext.Examinations.ToList();
        }

        public void Create(Examination examination)
        {
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

            _hospitalSystemDbContext.Entry(examination).CurrentValues.SetValues(newExamination);
            _hospitalSystemDbContext.SaveChanges();

            return true;
        }

        public Examination GetById(int id)
        {
            return _hospitalSystemDbContext.Examinations.FirstOrDefault(e => e.Id == id);
        }
    }
}
