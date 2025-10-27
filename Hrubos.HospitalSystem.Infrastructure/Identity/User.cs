using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Infrastructure.Identity
{
    public class User : IdentityUser<int>, IUser<int>
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string? BirthNumber { get; set; }
        public virtual int? MaxExaminationPerDay { get; set; }

        [ForeignKey(nameof(Specialization))]
        public virtual int? SpecializationId { get; set; }
        public virtual Specialization? Specialization { get; set; }

        public IList<Examination>? PatientExaminations { get; set; }
        public IList<Examination>? DoctorExaminations { get; set; }

        public IList<Vaccination>? Vaccinations { get; set; }

        public IList<DoctorPatient>? DoctorPatients { get; set; }
        public IList<DoctorPatient>? PatientDoctors { get; set; }
    }
}
