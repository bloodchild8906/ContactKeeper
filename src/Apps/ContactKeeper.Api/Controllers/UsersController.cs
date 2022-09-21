using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContactKeeper.Application.Cities.Commands.Create;
using ContactKeeper.Application.Cities.Commands.Delete;
using ContactKeeper.Application.Cities.Commands.Update;
using ContactKeeper.Application.Cities.Queries.GetCities;
using ContactKeeper.Application.Cities.Queries.GetCityById;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Application.Users.Commands.Create;
using ContactKeeper.Application.Users.Commands.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactKeeper.Api.Controllers;

/// <summary>
/// Users
/// </summary>
public class UsersController : BaseApiController
{
    /// <summary>
    /// Create A User
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ServiceResult<UserDto>>> Create(CreateUserCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    /// <summary>
    /// Update a User
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPut]
    public async Task<ActionResult<ServiceResult<UserDto>>> Update(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }

    /// <summary>
    /// Delete User by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResult<UserDto>>> Delete(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new DeleteCityCommand { Id = id }, cancellationToken));
    }
}