using BackendBaseProject.Core.DomainEvents;

namespace BackendBaseProject.Application.Interfaces;

public interface IEventPublisher
{
    Task PublishAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
}
