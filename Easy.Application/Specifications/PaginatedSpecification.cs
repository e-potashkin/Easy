using Easy.Domain.Entities;

namespace Easy.Application.Specifications
{
    public sealed class PaginatedSpecification : BaseSpecification<User>
    {
        public PaginatedSpecification(int pageIndex, int totalPages) : base(null)
        {
            ApplyPaging(pageIndex, totalPages);
        }
    }
}