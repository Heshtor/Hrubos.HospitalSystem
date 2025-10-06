using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class SpecializationInit
    {
        public List<Specialization> GenerateSpecializations()
        {
            return new List<Specialization>()
            {
                new Specialization {
                    Id = 1,
                    Name = "Oftalmologie"
                },
                new Specialization {
                    Id = 2,
                    Name = "Chirurgie"
                },
                new Specialization {
                    Id = 3,
                    Name = "Pediatrie"
                },
                new Specialization {
                    Id = 4,
                    Name = "Kardiologie"
                },
                new Specialization {
                    Id = 5,
                    Name = "Pneumologie"
                }
            };
        }
    }
}
