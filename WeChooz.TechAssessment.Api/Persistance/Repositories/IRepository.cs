using Ardalis.Specification;

namespace WeChooz.TechAssessment.Api.Persistance.Repositories;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
}
