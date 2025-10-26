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
                    DoctorId = 2,
                    PatientId = 6
                },
                new DoctorPatient {
                    Id = 2,
                    DoctorId = 3,
                    PatientId = 7
                },
                new DoctorPatient {
                    Id = 3,
                    DoctorId = 4,
                    PatientId = 8
                },
                new DoctorPatient {
                    Id = 4,
                    DoctorId = 2,
                    PatientId = 8
                },
                new DoctorPatient {
                    Id = 5,
                    DoctorId = 5,
                    PatientId = 7
                }
            };
        }
    }
}
