namespace WeChooz.TechAssessment.Api.Persistance.Models;

public class Participant
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public int SessionId { get; set; }

    // Navigation
    public Session Session { get; set; } = null!;
}
