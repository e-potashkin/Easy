using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Easy.Application.Common.Exceptions;
using Easy.Application.Users.V1.Queries;
using Easy.Application.Users.V1.Responses;
using Easy.Domain.Common.Interfaces;
using Easy.Domain.Entities;
using MediatR;

namespace Easy.Application.Users.V1.Handlers
{
    public class GetUserHandler: IRequestHandler<GetUserQuery, UserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepository;

        public GetUserHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(query.Id);
            if (user == null) throw new NotFoundException();

            return _mapper.Map<UserResponse>(user);
        }
    }
}