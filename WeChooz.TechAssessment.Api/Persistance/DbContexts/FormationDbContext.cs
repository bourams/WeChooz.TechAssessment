using Microsoft.EntityFrameworkCore;
using WeChooz.TechAssessment.Api.Persistance.Models;

namespace WeChooz.TechAssessment.Api.Persistance.DbContexts;

public class FormationDbContext : DbContext
{
    public FormationDbContext(DbContextOptions<FormationDbContext> options)
        : base(options)
    {
    }

    // DbSets
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<Participant> Participants => Set<Participant>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Mapping de base
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course", "dbo");
            entity.HasKey(c => c.Id);

            entity.HasMany(c => c.Sessions)
                  .WithOne(s => s.Course)
                  .HasForeignKey(s => s.CourseId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.ToTable("Session", "dbo");
            entity.HasKey(s => s.Id);

            entity.HasMany(s => s.Participants)
                  .WithOne(p => p.Session)
                  .HasForeignKey(p => p.SessionId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.ToTable("Participant", "dbo");
            entity.HasKey(p => p.Id);
        });
    }
}