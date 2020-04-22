using System;
using Easy.Application.Users.V1.Responses;
using MediatR;

namespace Easy.Application.Users.V1.Queries
{
    public class GetUserQuery : IRequest<UserResponse>
    {
        public Guid Id { get; }

        public GetUserQuery(Guid id)
        {
            Id = id;
        }
    }
}