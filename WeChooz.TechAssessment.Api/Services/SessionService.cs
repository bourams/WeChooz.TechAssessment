using AutoMapper;
using WeChooz.TechAssessment.Api.Dtos;
using WeChooz.TechAssessment.Api.Dtos.Filters;
using WeChooz.TechAssessment.Api.Persistance.FiltersSpecifications;
using WeChooz.TechAssessment.Api.Persistance.Repositories;

namespace WeChooz.TechAssessment.Api.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IMapper _mapper;

    public SessionService(ISessionRepository sessionRepository, IMapper mapper)
    {
        _sessionRepository = sessionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SessionListDto>> GetSessionWithFiltersAsync(SessionFilter sessionFilters,
                                                                              CancellationToken ct = default)
    {
        var spec = _mapper.Map<SessionFilterSpec>(sessionFilters);

        //TODO: Add pagination
        var sessions = await _sessionRepository.ListAsync(spec, ct);
        
        return _mapper.Map<IEnumerable<SessionListDto>>(sessions);
    }
}
