using Easy.Domain.Common.Interfaces;

namespace Easy.Domain.Entities
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}