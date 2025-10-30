using WeChooz.TechAssessment.Api.Persistance.DbContexts;
using WeChooz.TechAssessment.Api.Persistance.Models;

namespace WeChooz.TechAssessment.Api.Persistance.Repositories;

public class SessionRepository : EfRepository<Session>, ISessionRepository
{
    public SessionRepository(FormationDbContext dbContext) : base(dbContext) { }
}
