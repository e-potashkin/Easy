using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Easy.Application.Users.V1.Commands;
using Easy.Application.Users.V1.Queries;
using Easy.Application.Users.V1.Responses;
using Easy.WebApi.Configuration;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Easy.WebApi.Controllers.V1
{
    [ApiVersion(Api.V1)]
    [Route(Api.Template)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// Retrieves a list of users
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Users found</response>
        /// <response code="400">Query has missing/invalid values</response>
        /// <response code="404">Users not found</response>
        /// <response code="500">Oops! Can't retrieve user right now</response>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<UserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] int pageIndex, int pageSize)
        {
            var result = await _mediator.Send(new GetUsersQuery(pageIndex, pageSize));

            return Ok(result);
        }

        /// <summary>
        /// Retrieves user by id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">User found</response>
        /// <response code="400">Query has missing/invalid values</response>
        /// <response code="404">User not found</response>
        /// <response code="500">Oops! Can't retrieve user right now</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetUserQuery(id));

            return Ok(result);
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="204">User created</response>
        /// <response code="400">User has missing/invalid values</response>
        /// <response code="500">Oops! Can't create user right now</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}