namespace WeChooz.TechAssessment.Api.Dtos.Filters;

public record SessionFilter(string? TargetAudience = null,
                             string? DeliveryMode = null,
                             DateTime? From = null,
                             DateTime? To = null);
