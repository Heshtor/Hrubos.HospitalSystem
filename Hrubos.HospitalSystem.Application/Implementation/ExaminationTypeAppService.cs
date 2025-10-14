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
    }
}
