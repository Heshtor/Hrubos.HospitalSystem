using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(VaccineType))]
    public class VaccineType : Entity<int>
    {
        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        public IList<Vaccination>? Vaccinations { get; set; }
    }
}
