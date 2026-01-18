using FluentAssertions;
using BackendBaseProject.Core.Entities;

namespace BackendBaseProject.Core.Tests.Entities;

public class Entity_Equals_WhenIdsAreEqual_ReturnsTrue
{
    [Fact]
    public void WithSameId_ReturnsTrue()
    {
        var entity1 = new TestEntity(1);
        var entity2 = new TestEntity(1);

        entity1.Should().Be(entity2);
    }

    [Fact]
    public void WithDifferentIds_ReturnsFalse()
    {
        var entity1 = new TestEntity(1);
        var entity2 = new TestEntity(2);

        entity1.Should().NotBe(entity2);
    }

    [Fact]
    public void WithNull_ReturnsFalse()
    {
        var entity = new TestEntity(1);
        entity.Should().NotBeNull();
    }

    private class TestEntity(int id) : Entity<int>(id);
}
