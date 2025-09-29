using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    public class DoctorPatient
    {
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
