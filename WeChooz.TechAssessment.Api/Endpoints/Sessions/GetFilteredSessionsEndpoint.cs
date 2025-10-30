using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using WeChooz.TechAssessment.Api.Dtos;
using WeChooz.TechAssessment.Api.Dtos.Filters;
using WeChooz.TechAssessment.Api.Services;

namespace WeChooz.TechAssessment.Api.Endpoints.Sessions;

public class GetFilteredSessionsEndpoint : EndpointBaseAsync.WithRequest<SessionFilter>
                                                            .WithActionResult<IEnumerable<SessionListDto>>
{
    private readonly ISessionService _service;

    public GetFilteredSessionsEndpoint(ISessionService service)
    {
        _service = service;
    }

    [HttpGet("api/sessions")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SessionListDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<ActionResult<IEnumerable<SessionListDto>>> HandleAsync([FromQuery] SessionFilter filter,
                                                                                      CancellationToken cancellationToken = default)
    {
        var result = await _service.GetSessionWithFiltersAsync(filter, cancellationToken);

        return Ok(result);
    }
}