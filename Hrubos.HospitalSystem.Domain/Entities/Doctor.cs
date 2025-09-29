using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(Doctor))]
    public class Doctor : UserBase
    {
        [ForeignKey(nameof(Specialization))]
        public int SpecializationId { get; set; }
        public Specialization? Specialization { get; set; }

        public IList<Examination>? Examinations { get; set; }
        public IList<DoctorPatient>? DoctorPatients { get; set; }
    }
}
