using Hrubos.HospitalSystem.Domain.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(DoctorPatient))]
    public class DoctorPatient : Entity<int>
    {
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public IUser<int>? Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public IUser<int>? Patient { get; set; }
    }
}
