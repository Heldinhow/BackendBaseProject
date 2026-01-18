namespace BackendBaseProject.Core.DomainServices;

public interface IDomainService<in TInput, TOutput>
{
    TOutput Execute(TInput input);
}
