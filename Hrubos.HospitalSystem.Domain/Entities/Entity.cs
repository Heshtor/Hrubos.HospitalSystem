using Hrubos.HospitalSystem.Domain.Entities.Interfaces;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
