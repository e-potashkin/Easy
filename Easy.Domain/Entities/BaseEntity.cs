using System;

namespace Easy.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public long CreatedAt { get; set; }
    }
}