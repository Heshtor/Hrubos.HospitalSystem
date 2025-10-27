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
                    ProblemDescription = "Vysoký tlak",
                    ExaminationTypeId = 1,
                    PatientId = 6,
                    DoctorId = 2
                },
                new Examination {
                    Id = 2,
                    DateTime = DateTime.Now.AddDays(-5),
                    ProblemDescription = "Krevní test",
                    ExaminationTypeId = 3,
                    PatientId = 7,
                    DoctorId = 3
                },
                new Examination {
                    Id = 3,
                    DateTime = DateTime.Now.AddDays(-2),
                    ProblemDescription = "Bolest kloubů",
                    ExaminationTypeId = 2,
                    PatientId = 8,
                    DoctorId = 4
                },
                new Examination {
                    Id = 4,
                    DateTime = DateTime.Now.AddDays(-8),
                    ProblemDescription = "Bolest zápěstí",
                    ExaminationTypeId = 2,
                    PatientId = 7,
                    DoctorId = 4
                }
            };
        }
    }
}
