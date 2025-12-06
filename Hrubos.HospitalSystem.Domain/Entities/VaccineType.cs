using Hrubos.HospitalSystem.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(VaccineType))]
    public class VaccineType : Entity<int>
    {
        [Required]
        [FirstLetterCapitalized]
        [StringLength(50, ErrorMessage = "Pole {0} nesmí obsahovat více než {1} znaků.")]
        public string Name { get; set; }

        public IList<Vaccination>? Vaccinations { get; set; }
    }
}
