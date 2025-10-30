using Ardalis.Specification.EntityFrameworkCore;
using WeChooz.TechAssessment.Api.Persistance.DbContexts;

namespace WeChooz.TechAssessment.Api.Persistance.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    public EfRepository(FormationDbContext dbContext) : base(dbContext) { }
}
