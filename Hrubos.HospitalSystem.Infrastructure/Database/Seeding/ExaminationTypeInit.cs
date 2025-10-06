using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class ExaminationTypeInit
    {
        public List<ExaminationType> GenerateExaminationTypes()
        {
            return new List<ExaminationType>()
            {
                new ExaminationType {
                    Id = 1,
                    Name = "Obvodní vyšetření"
                },
                new ExaminationType {
                    Id = 2,
                    Name = "Specialistické vyšetření"
                },
                new ExaminationType {
                    Id = 3,
                    Name = "Laboratorní test"
                }
            };
        }
    }
}
