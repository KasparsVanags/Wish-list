using Microsoft.EntityFrameworkCore;
using Wish_list.Core.Models;
using Wish_list.Data;

namespace Wish_list.Services.Tests;

public class EntityServiceTests
{
    private readonly Mock<Entity> _entityMock;
    private readonly EntityService<Entity> _entityService;
    private readonly Mock<IWishListDbContext> _wishListDbContextMock;

    public EntityServiceTests()
    {
        _entityMock = new Mock<Entity>();
        _wishListDbContextMock = new Mock<IWishListDbContext>();
        _entityService = new EntityService<Entity>(_wishListDbContextMock.Object);
    }

    [Fact]
    public void Create_CreateEntity_CallsAdd()
    {
        //Arrange
        _wishListDbContextMock.Setup(x => x.Set<Entity>().Add(_entityMock.Object));

        //Act
        _entityService.Create(_entityMock.Object);

        //Assert
        _wishListDbContextMock.Verify(x => x.Set<Entity>().Add(_entityMock.Object), Times.Once);
    }

    [Fact]
    public void Create_CreateEntity_SavesChanges()
    {
        //Arrange
        _wishListDbContextMock.Setup(x => x.Set<Entity>().Add(_entityMock.Object));
        _wishListDbContextMock.Setup(x => x.SaveChanges());

        //Act
        _entityService.Create(_entityMock.Object);

        //Assert
        _wishListDbContextMock.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Fact]
    public void Delete_DeleteEntity_CallsRemove()
    {
        //Arrange
        _wishListDbContextMock.Setup(x => x.Set<Entity>().Remove(_entityMock.Object));

        //Act
        _entityService.Delete(_entityMock.Object);

        //Assert
        _wishListDbContextMock.Verify(x => x.Set<Entity>().Remove(_entityMock.Object), Times.Once);
    }

    [Fact]
    public void Delete_DeleteEntity_SavesChanges()
    {
        //Arrange
        _wishListDbContextMock.Setup(x => x.Set<Entity>().Remove(_entityMock.Object));
        _wishListDbContextMock.Setup(x => x.SaveChanges());

        //Act
        _entityService.Delete(_entityMock.Object);

        //Assert
        _wishListDbContextMock.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Fact]
    public void GetAll_GetsAllEntries()
    {
        //Arrange
        var entities = new List<Entity>
        {
            _entityMock.Object,
            _entityMock.Object
        };

        var dbSetMock = new Mock<DbSet<Entity>>();
        dbSetMock.As<IQueryable<Entity>>()
            .Setup(x => x.GetEnumerator()).Returns(entities.GetEnumerator());
        _wishListDbContextMock.Setup(x => x.Set<Entity>()).Returns(dbSetMock.Object);

        //Act
        var result = _entityService.GetAll();

        //Assert
        _wishListDbContextMock.Verify(x => x.Set<Entity>(), Times.Once);
        result.Should().Contain(_entityMock.Object);
    }

    [Fact]
    public void Query_GetsEntriesAsQueryable()
    {
        //Arrange
        var entities = new List<Entity>
        {
            _entityMock.Object,
            _entityMock.Object
        };

        var dbSetMock = new Mock<DbSet<Entity>>();
        dbSetMock.As<IQueryable<Entity>>()
            .Setup(x => x.GetEnumerator()).Returns(entities.GetEnumerator());
        _wishListDbContextMock.Setup(x => x.Set<Entity>()).Returns(dbSetMock.Object);

        //Act
        var result = _entityService.Query();

        //Assert
        _wishListDbContextMock.Verify(x => x.Set<Entity>(), Times.Once);
        result.Should().BeOfType(typeof(EnumerableQuery<Entity>));
    }
}