using Hrubos.HospitalSystem.Domain.Entities.Interfaces;
using Hrubos.HospitalSystem.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(Specialization))]
    public class Specialization : Entity<int>
    {
        [Required]
        [StringLength(70)]
        [FirstLetterCapitalized]
        public string Name { get; set; }

        public IList<IUser<int>>? Doctors { get; set; }
    }
}
