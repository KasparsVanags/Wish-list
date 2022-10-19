using Microsoft.AspNetCore.Mvc;
using Wish_list.Controllers;
using Wish_list.Models;

namespace Wish_list.Tests;

public class UserApiControllerTests
{
    private readonly UserApiController _controller;

    public UserApiControllerTests()
    {
        _controller = new UserApiController();
    }

    [Fact]
    public void GetNames_ValidListOfUsers_ReturnsNames()
    {
        //Arrange
        var users = new List<User>
        {
            new()
            {
                Type = "user",

                Id = 150709,

                Name = "johnsmith",

                Email = "jsmith@example.com"
            },
            new()
            {
                Type = "user",

                Id = 150710,

                Name = "angelinasmith",

                Email = "asmith@example.com"
            },
            new()
            {
                Type = "user",

                Id = 150910,

                Name = "adamivanov",

                Email = "aivanov@another.org"
            }
        };

        //Act
        var response = _controller.GetNames(users) as OkObjectResult;

        //Assert
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(200);
        response.Value.Should().Be("johnsmith,angelinasmith,adamivanov");
    }

    [Fact]
    public void GetNames_EmptyList_ReturnsBadRequest()
    {
        //Arrange
        var users = new List<User>();

        //Act
        var response = _controller.GetNames(users) as BadRequestObjectResult;

        //Assert
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(400);
        response.Value.Should().Be("User list can not be empty");
    }
}