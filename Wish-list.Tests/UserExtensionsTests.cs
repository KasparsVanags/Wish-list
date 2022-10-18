using Wish_list.Extensions;
using Wish_list.Models;

namespace Wish_list.Tests;

public class UserExtensionsTests
{
    [Fact]
    public void GetNames_ValidUserList_ReturnsUserNames()
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

        //Assert
        users.GetNames().Should().Be("johnsmith,angelinasmith,adamivanov");
    }
}