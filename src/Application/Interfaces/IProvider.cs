namespace BackendBaseProject.Application.Interfaces;

public interface IProvider<TOutput>
{
    Task<TOutput> GetAsync(CancellationToken cancellationToken = default);
}

public interface IProvider<in TInput, TOutput>
{
    Task<TOutput> GetAsync(TInput input, CancellationToken cancellationToken = default);
}
