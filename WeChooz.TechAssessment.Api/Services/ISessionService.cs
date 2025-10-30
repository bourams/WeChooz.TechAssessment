using WeChooz.TechAssessment.Api.Dtos;
using WeChooz.TechAssessment.Api.Dtos.Filters;

namespace WeChooz.TechAssessment.Api.Services;

public interface ISessionService
{
    Task<IEnumerable<SessionListDto>> GetSessionWithFiltersAsync(SessionFilter sessionFilters,
                                                                 CancellationToken ct = default);
}
