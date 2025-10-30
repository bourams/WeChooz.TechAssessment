using Ardalis.Specification;
using WeChooz.TechAssessment.Api.Persistance.Models;

namespace WeChooz.TechAssessment.Api.Persistance.FiltersSpecifications;

public class SessionFilterSpec : Specification<Session>
{
    public SessionFilterSpec(string? targetAudience = null,
                              string? deliveryMode = null,
                              DateTime? from = null,
                              DateTime? to = null)
    {
        Query.Include(s => s.Course)
             .Include(s => s.Participants);

        if (!string.IsNullOrEmpty(targetAudience))
        {
            Query.Where(s => s.Course.TargetAudience == targetAudience);
        }

        if (!string.IsNullOrEmpty(deliveryMode))
        {
            Query.Where(s => s.DeliveryMode == deliveryMode);
        }

        if (from.HasValue)
        {
            Query.Where(s => s.StartDate >= from.Value);
        }

        if (to.HasValue)
        {
            Query.Where(s => s.StartDate <= to.Value);
        }

        Query.OrderBy(s => s.StartDate);
    }
}

