using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Easy.Application.Users.V1.Commands;
using Easy.Domain.Common.Interfaces;
using Easy.Domain.Entities;
using MediatR;

namespace Easy.Application.Users.V1.Handlers
{
    public class CreateUserHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepository;

        public CreateUserHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        protected override async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(command);
            user.CreatedAt = DateTime.UtcNow.Ticks;
            
            await _userRepository.AddAsync(user);
        }
    }
}