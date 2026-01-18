using BackendBaseProject.Core.DomainEvents;
using BackendBaseProject.Core.Entities;

namespace BackendBaseProject.Core.Aggregates;

public abstract class AggregateRoot<TId>(TId id) : Entity<TId>(id)
    where TId : struct
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
