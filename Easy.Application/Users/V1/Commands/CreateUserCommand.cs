using MediatR;

namespace Easy.Application.Users.V1.Commands
{
    public class CreateUserCommand : IRequest
    {
        /// <summary>
        /// The name of the user
        /// </summary>
        /// <example>Johnny</example>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user
        /// </summary>
        /// <example>Cage</example>
        public string LastName { get; set; }
    }
}