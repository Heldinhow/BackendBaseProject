namespace BackendBaseProject.Core.Specifications;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T candidate);
}
