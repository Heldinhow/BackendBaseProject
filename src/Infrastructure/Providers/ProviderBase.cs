using System.Text.Json;
using BackendBaseProject.Application.Interfaces;

namespace BackendBaseProject.Infrastructure.Providers;

public abstract class ProviderBase<TOutput>(HttpClient httpClient) : IProvider<TOutput>
{
    protected readonly HttpClient _httpClient = httpClient;

    public virtual async Task<TOutput> GetAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("", cancellationToken);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<TOutput>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
}

public abstract class ProviderBase<TInput, TOutput>(HttpClient httpClient) : IProvider<TInput, TOutput>
{
    protected readonly HttpClient _httpClient = httpClient;

    public virtual async Task<TOutput> GetAsync(TInput input, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(input?.ToString(), cancellationToken);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<TOutput>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
}
