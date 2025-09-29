using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(ExaminationType))]
    public class ExaminationType : Entity<int>
    {
        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        public IList<Examination>? Examinations { get; set; }
    }
}
