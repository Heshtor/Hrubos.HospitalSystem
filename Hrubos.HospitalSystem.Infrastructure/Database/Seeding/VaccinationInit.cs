using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class VaccinationInit
    {
        public List<Vaccination> GenerateVaccinations()
        {
            return new List<Vaccination>()
            {
                new Vaccination {
                    Id = 1,
                    DateTime = DateTime.Now.AddMonths(-12),
                    PatientId = 6,
                    VaccineTypeId = 1
                },
                new Vaccination {
                    Id = 2,
                    DateTime = DateTime.Now.AddMonths(-8),
                    PatientId = 7,
                    VaccineTypeId = 2
                },
                new Vaccination {
                    Id = 3,
                    DateTime = DateTime.Now.AddMonths(-6),
                    PatientId = 8,
                    VaccineTypeId = 3
                },
                new Vaccination {
                    Id = 4,
                    DateTime = DateTime.Now.AddMonths(-3),
                    PatientId = 6,
                    VaccineTypeId = 2
                }
            };
        }
    }
}
