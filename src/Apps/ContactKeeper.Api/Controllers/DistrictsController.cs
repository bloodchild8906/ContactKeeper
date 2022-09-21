using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Districts.Commands.Create;
using ContactKeeper.Application.Districts.Queries;
using ContactKeeper.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContactKeeper.Api.Controllers;

/// <summary>
/// District
/// </summary>
[Authorize]
public class DistrictsController: BaseApiController
{
    /// <summary>
    /// Get district by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<FileResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var vm = await Mediator.Send(new ExportDistrictsQuery { CityId = id }, cancellationToken);

        return File(vm.Content, vm.ContentType, vm.FileName);
    }

    /// <summary>
    /// Create district
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ServiceResult<DistrictDto>>> Create(CreateDistrictCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }
}
