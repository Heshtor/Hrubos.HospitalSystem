using System.ComponentModel.DataAnnotations;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    public class VaccineType : Entity<int>
    {
        [Required]
        public string Name { get; set; }

        public IList<Vaccination>? Vaccinations { get; set; }
    }
}
