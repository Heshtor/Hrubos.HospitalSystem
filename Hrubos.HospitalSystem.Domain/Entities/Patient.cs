using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(Patient))]
    public class Patient : UserBase
    {
        public IList<Examination>? Examinations { get; set; }
        public IList<Vaccination>? Vaccinations { get; set; }
        public IList<DoctorPatient>? DoctorPatients { get; set; }
    }
}
