namespace BackendBaseProject.Core.Entities;

public abstract class Entity<TId>(TId id) where TId : struct
{
    public TId Id { get; } = id;

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other) return false;
        return EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<TId>.Default.GetHashCode(Id);
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return EqualityComparer<Entity<TId>>.Default.Equals(left, right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }
}
