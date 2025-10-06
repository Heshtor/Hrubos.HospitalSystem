using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class ExaminationInit
    {
        public List<Examination> GenerateExaminations()
        {
            return new List<Examination>()
            {
                new Examination {
                    Id = 1,
                    DateTime = DateTime.Now.AddDays(-10),
                    Notes = "Kontrola tlaku",
                    ExaminationTypeId = 1,
                    PatientId = 1,
                    DoctorId = 1
                },
                new Examination {
                    Id = 2,
                    DateTime = DateTime.Now.AddDays(-5),
                    Notes = "Krevní test",
                    ExaminationTypeId = 3,
                    PatientId = 2,
                    DoctorId = 2
                },
                new Examination {
                    Id = 3,
                    DateTime = DateTime.Now.AddDays(-2),
                    Notes = "Vyšetření kloubů",
                    ExaminationTypeId = 2,
                    PatientId = 3,
                    DoctorId = 3
                },
                new Examination {
                    Id = 4,
                    DateTime = DateTime.Now.AddDays(-8),
                    Notes = "Vyšetření ruky",
                    ExaminationTypeId = 2,
                    PatientId = 2,
                    DoctorId = 3
                }
            };
        }
    }
}
