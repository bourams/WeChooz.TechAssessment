namespace WeChooz.TechAssessment.Api.Persistance.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string? LongDescription { get; set; }
    public int DurationDays { get; set; }
    public string TargetAudience { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string TrainerFirstName { get; set; } = string.Empty;
    public string TrainerLastName { get; set; } = string.Empty;

    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}
