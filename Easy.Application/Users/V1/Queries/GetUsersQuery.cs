using System.Collections.Generic;
using Easy.Application.Users.V1.Responses;
using MediatR;

namespace Easy.Application.Users.V1.Queries
{
    public class GetUsersQuery : IRequest<IReadOnlyCollection<UserResponse>>
    {
        public int PageIndex { get; }
        public int PageSize { get; }

        public GetUsersQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}