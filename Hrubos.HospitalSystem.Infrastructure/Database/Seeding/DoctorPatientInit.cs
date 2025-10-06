using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class DoctorPatientInit
    {
        public List<DoctorPatient> GenerateDoctorPatients()
        {
            return new List<DoctorPatient>()
            {
                new DoctorPatient {
                    Id = 1,
                    DoctorId = 1,
                    PatientId = 1
                },
                new DoctorPatient {
                    Id = 2,
                    DoctorId = 2,
                    PatientId = 2
                },
                new DoctorPatient {
                    Id = 3,
                    DoctorId = 3,
                    PatientId = 3
                },
                new DoctorPatient {
                    Id = 4,
                    DoctorId = 1,
                    PatientId = 3
                },
                new DoctorPatient {
                    Id = 5,
                    DoctorId = 4,
                    PatientId = 2
                }
            };
        }
    }
}
