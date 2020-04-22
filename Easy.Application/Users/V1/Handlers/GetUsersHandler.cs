using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Easy.Application.Common.Exceptions;
using Easy.Application.Specifications;
using Easy.Application.Users.V1.Queries;
using Easy.Application.Users.V1.Responses;
using Easy.Domain.Common.Interfaces;
using Easy.Domain.Entities;
using MediatR;

namespace Easy.Application.Users.V1.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IReadOnlyCollection<UserResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepository;

        public GetUsersHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyCollection<UserResponse>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            var paginationSpec = new PaginatedSpecification(query.PageIndex, query.PageSize);
            var users = await _userRepository.GetAllAsync(paginationSpec);

            if (users.Count == 0) throw new NotFoundException();

            return _mapper.Map<IReadOnlyCollection<UserResponse>>(users);
        }
    }
}