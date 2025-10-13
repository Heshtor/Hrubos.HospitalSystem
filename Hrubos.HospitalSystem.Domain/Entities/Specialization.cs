using Hrubos.HospitalSystem.Domain.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(Specialization))]
    public class Specialization : Entity<int>
    {
        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        public IUser<int>? Doctors { get; set; }
    }
}
