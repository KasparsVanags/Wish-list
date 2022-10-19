using Microsoft.AspNetCore.Mvc;
using Moq;
using Wish_list.Controllers;
using Wish_list.Core.Interfaces;
using Wish_list.Core.Models;
using Wish_list.Core.Services;

namespace Wish_list.Tests;

public class WishListApiControllerTests
{
    private readonly WishListApiController _controller;
    private readonly Mock<IEntityService<Wish>> _entityServiceMock;
    private readonly Mock<Wish> _wishMock;
    private readonly Mock<IWishValidator> _wishValidatorMock;

    public WishListApiControllerTests()
    {
        _wishValidatorMock = new Mock<IWishValidator>();
        _wishMock = new Mock<Wish>();
        _entityServiceMock = new Mock<IEntityService<Wish>>();
        _controller = new WishListApiController(_entityServiceMock.Object, _wishValidatorMock.Object);
    }

    [Fact]
    public void CreateWish_ValidWish_CallsCreateMethod()
    {
        //Arrange
        _wishValidatorMock.Setup(x => x.IsValid(_wishMock.Object)).Returns(true);
        _entityServiceMock.Setup(x => x.Create(_wishMock.Object));

        //Act
        var response = _controller.CreateWish(_wishMock.Object) as CreatedResult;

        //Assert
        _entityServiceMock.Verify(x => x.Create(_wishMock.Object), Times.Once());
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(201);
    }

    [Fact]
    public void CreateWish_InValidWish_ReturnsBadRequest()
    {
        //Arrange
        _wishValidatorMock.Setup(x => x.IsValid(_wishMock.Object)).Returns(false);
        _entityServiceMock.Setup(x => x.Create(_wishMock.Object));

        //Act
        var response = _controller.CreateWish(_wishMock.Object) as BadRequestResult;

        //Assert
        _entityServiceMock.Verify(x => x.Create(_wishMock.Object), Times.Never());
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(400);
    }

    [Fact]
    public void UpdateWish_ValidWish_CallsUpdateMethod()
    {
        //Arrange
        _wishValidatorMock.Setup(x => x.IsValid(_wishMock.Object)).Returns(true);
        _entityServiceMock.Setup(x => x.GetById(1)).Returns(_wishMock.Object);
        _entityServiceMock.Setup(x => x.Update(_wishMock.Object));

        //Act
        var response = _controller.UpdateWish(1, _wishMock.Object) as OkObjectResult;

        //Assert
        _entityServiceMock.Verify(x => x.Update(_wishMock.Object), Times.Once());
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(200);
    }

    [Fact]
    public void UpdateWish_InValidWish_ReturnsBadRequest()
    {
        //Arrange
        _wishValidatorMock.Setup(x => x.IsValid(_wishMock.Object)).Returns(false);
        _entityServiceMock.Setup(x => x.GetById(1)).Returns(_wishMock.Object);
        _entityServiceMock.Setup(x => x.Update(_wishMock.Object));

        //Act
        var response = _controller.UpdateWish(1, _wishMock.Object) as BadRequestResult;

        //Assert
        _entityServiceMock.Verify(x => x.Update(_wishMock.Object), Times.Never());
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(400);
    }

    [Fact]
    public void UpdateWish_WishDoesNotExistInDatabase_ReturnsBadRequest()
    {
        //Arrange
        _wishValidatorMock.Setup(x => x.IsValid(_wishMock.Object)).Returns(true);
        _entityServiceMock.Setup(x => x.GetById(1)).Returns((Wish?)null);
        _entityServiceMock.Setup(x => x.Update(_wishMock.Object));

        //Act
        var response = _controller.UpdateWish(1, _wishMock.Object) as BadRequestObjectResult;

        //Assert
        _entityServiceMock.Verify(x => x.Update(_wishMock.Object), Times.Never());
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(400);
        response.Value.Should().Be("Wish id 1 does not exist");
    }

    [Fact]
    public void DeleteWish_WishExists_CallsDeleteMethod()
    {
        //Arrange
        _entityServiceMock.Setup(x => x.GetById(1)).Returns(_wishMock.Object);
        _entityServiceMock.Setup(x => x.Delete(_wishMock.Object));

        //Act
        var response = _controller.DeleteWish(1) as NoContentResult;

        //Assert
        _entityServiceMock.Verify(x => x.Delete(_wishMock.Object), Times.Once());
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(204);
    }

    [Fact]
    public void DeleteWish_WishDoesntExist_ReturnsNotFound()
    {
        //Arrange
        _entityServiceMock.Setup(x => x.GetById(1)).Returns((Wish?)null);
        _entityServiceMock.Setup(x => x.Delete(_wishMock.Object));

        //Act
        var response = _controller.DeleteWish(1) as NotFoundResult;

        //Assert
        _entityServiceMock.Verify(x => x.Delete(_wishMock.Object), Times.Never());
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(404);
    }

    [Fact]
    public void GetWish_WishExists_ReturnsWish()
    {
        //Arrange
        _entityServiceMock.Setup(x => x.GetById(1)).Returns(_wishMock.Object);

        //Act
        var response = _controller.GetWish(1) as OkObjectResult;

        //Assert
        _entityServiceMock.Verify(x => x.GetById(1), Times.Once());
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(200);
        var wish = response.Value as Wish;
        wish.Should().NotBeNull();
      
    }

    [Fact]
    public void GetWish_WishDoesntExist_ReturnsNotFoundResult()
    {
        //Arrange
        _entityServiceMock.Setup(x => x.GetById(1)).Returns((Wish?)null);

        //Act
        var response = _controller.GetWish(1) as NotFoundResult;

        //Assert
        _entityServiceMock.Verify(x => x.GetById(1), Times.Once());
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(404);
    }

    [Fact]
    public void GetAll_WishListNotEmpty_ReturnsWishList()
    {
        //Arrange
        var wishList = new List<Wish>
        {
            _wishMock.Object
        };

        _entityServiceMock.Setup(x => x.GetAll()).Returns(wishList);

        //Act
        var response = _controller.GetAllWishes() as OkObjectResult;

        //Assert
        _entityServiceMock.Verify(x => x.GetAll(), Times.Once());
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(200);
    }

    [Fact]
    public void GetAll_WishListEmpty_ReturnsNoContent()
    {
        //Arrange
        var wishList = new List<Wish>();
        _entityServiceMock.Setup(x => x.GetAll()).Returns(wishList);

        //Act
        var response = _controller.GetAllWishes() as NoContentResult;

        //Assert
        _entityServiceMock.Verify(x => x.GetAll(), Times.Once());
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(204);
    }
}