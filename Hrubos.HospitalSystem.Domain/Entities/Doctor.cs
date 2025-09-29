using Hrubos.HospitalSystem.Domain.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    public class Doctor : Entity<int>, IUser<int>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string? BirthNumber { get; set; }

        [ForeignKey(nameof(Specialization))]
        public int SpecializationId { get; set; }
        public Specialization? Specialization { get; set; }

        public IList<Examination>? Examinations { get; set; }
        public IList<DoctorPatient>? DoctorPatients { get; set; }
    }
}
