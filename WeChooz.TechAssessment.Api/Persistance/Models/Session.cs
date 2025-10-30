using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChooz.TechAssessment.Api.Persistance.Models;

public class Session
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public string DeliveryMode { get; set; } = string.Empty; // "présentiel" ou "distance"

    // Calculé : nombre de places restantes
    [NotMapped]
    public int RemainingSeats => Math.Max(0, Course.Capacity - Participants.Count);

    // Navigation
    public ICollection<Participant> Participants { get; set; } = new List<Participant>();

}
