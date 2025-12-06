using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Domain.Entities.Interfaces;
using Hrubos.HospitalSystem.Domain.Validations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Infrastructure.Identity
{
    public class User : IdentityUser<int>, IUser<int>
    {
        [Required]
        public override string? UserName { get; set; }

        [FirstLetterCapitalized]
        public virtual string? FirstName { get; set; }

        [FirstLetterCapitalized]
        public virtual string? LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Zadaný formát e-mailové adresy není platný.")]
        public override string? Email { get; set; }

        [Phone(ErrorMessage = "Zadaný formát telefonního čísla není platný.")]
        public override string? PhoneNumber { get; set; }

        [BirthNumber]
        public virtual string? BirthNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Maximální počet vyšetření na den nesmí být záporný.")]
        public virtual int? MaxExaminationPerDay { get; set; } = 0;

        [ForeignKey(nameof(Specialization))]
        public virtual int? SpecializationId { get; set; }
        public virtual Specialization? Specialization { get; set; }

        [NotMapped]
        public string? RoleName { get; set; }

        public IList<Examination>? PatientExaminations { get; set; }
        public IList<Examination>? DoctorExaminations { get; set; }

        public IList<Vaccination>? Vaccinations { get; set; }

        public IList<DoctorPatient>? DoctorPatients { get; set; }
        public IList<DoctorPatient>? PatientDoctors { get; set; }
    }
}
