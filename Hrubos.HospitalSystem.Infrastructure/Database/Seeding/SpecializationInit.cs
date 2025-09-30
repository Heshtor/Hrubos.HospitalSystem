using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class SpecializationInit
    {
        public List<Specialization> GenerateSpecializations3()
        {
            List<Specialization> specializations = new List<Specialization>();

            var spec1 = new Specialization()
            {
                Id = 1,
                Name = "Blabla1"
            };

            var spec2 = new Specialization()
            {
                Id = 2,
                Name = "Blabla2"
            };

            var spec3 = new Specialization()
            {
                Id = 3,
                Name = "Blabla3"
            };

            specializations.Add(spec1);
            specializations.Add(spec2);
            specializations.Add(spec3);

            return specializations;
        }
    }
}
