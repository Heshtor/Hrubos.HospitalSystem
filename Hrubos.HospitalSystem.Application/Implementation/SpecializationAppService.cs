using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Infrastructure.Database;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class SpecializationAppService : ISpecializationAppService
    {
        HospitalSystemDbContext _hospitalSystemDbContext;

        public SpecializationAppService(HospitalSystemDbContext hospitalSystemDbContext)
        {
            _hospitalSystemDbContext = hospitalSystemDbContext;
        }

        public IList<Specialization> SelectAll()
        {
            return _hospitalSystemDbContext.Specializations.ToList();
        }
    }
}
