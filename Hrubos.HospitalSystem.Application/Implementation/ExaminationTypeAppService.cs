using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Database;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class ExaminationTypeAppService : IExaminationTypeAppService
    {
        HospitalSystemDbContext _hospitalSystemDbContext;

        public ExaminationTypeAppService(HospitalSystemDbContext hospitalSystemDbContext)
        {
            _hospitalSystemDbContext = hospitalSystemDbContext;
        }

        public IList<ExaminationType> SelectAll()
        {
            return _hospitalSystemDbContext.ExaminationTypes.ToList();
        }

        public void Create(ExaminationType examinationType)
        {
            _hospitalSystemDbContext.ExaminationTypes.Add(examinationType);
            _hospitalSystemDbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            var examinationType = _hospitalSystemDbContext.ExaminationTypes.FirstOrDefault(e => e.Id == id);

            if (examinationType != null)
            {
                _hospitalSystemDbContext.ExaminationTypes.Remove(examinationType);
                _hospitalSystemDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }
    }
}
