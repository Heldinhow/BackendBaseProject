using Ardalis.Specification;

namespace BackendBaseProject.Core.Specifications;

public interface IRepository<T> : IRepositoryBase<T> where T : class;
