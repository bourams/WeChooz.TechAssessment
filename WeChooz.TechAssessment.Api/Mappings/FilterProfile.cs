using AutoMapper;
using WeChooz.TechAssessment.Api.Dtos.Filters;
using WeChooz.TechAssessment.Api.Persistance.FiltersSpecifications;

namespace WeChooz.TechAssessment.Api.Mappings;

public class FilterProfile : Profile
{
    public FilterProfile()
    {
        // Mappe le DTO de filtre API vers la spécification
        CreateMap<SessionFilter, SessionFilterSpec>()
            .ConstructUsing(src => new SessionFilterSpec(src.TargetAudience, src.DeliveryMode, src.From, src.To));
    }
}