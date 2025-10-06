using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class VaccineTypeInit
    {
        public List<VaccineType> GenerateVaccineTypes()
        {
            return new List<VaccineType>()
            {
                new VaccineType {
                    Id = 1,
                    Name = "Chřipka"
                },
                new VaccineType {
                    Id = 2,
                    Name = "Hepatitida B"
                },
                new VaccineType {
                    Id = 3,
                    Name = "Tetanus"
                }
            };
        }
    }
}
