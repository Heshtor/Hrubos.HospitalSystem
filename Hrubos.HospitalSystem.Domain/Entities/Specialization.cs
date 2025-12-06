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
        [FirstLetterCapitalized]
        [StringLength(50, ErrorMessage = "Pole {0} nesmí obsahovat více než {1} znaků.")]
        public string Name { get; set; }

        public IList<IUser<int>>? Doctors { get; set; }
    }
}
