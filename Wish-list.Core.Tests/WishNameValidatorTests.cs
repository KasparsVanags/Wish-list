using Wish_list.Core.Interfaces;
using Wish_list.Core.Models.WishValidators;

namespace Wish_list.Core.Tests;

public class WishNameValidatorTests
{
    private readonly Mock<IWish> _wishMock;
    private readonly WishNameValidator _wishNameValidator;

    public WishNameValidatorTests()
    {
        _wishMock = new Mock<IWish>();
        _wishNameValidator = new WishNameValidator();
    }

    [Fact]
    public void IsValid_ValidName_ReturnsTrue()
    {
        //arrange
        _wishMock.SetupGet(x => x.Name).Returns("car");
        //assert
        _wishNameValidator.IsValid(_wishMock.Object).Should().BeTrue();
    }

    [Fact]
    public void IsValid_EmptyName_ReturnsFalse()
    {
        //arrange
        _wishMock.SetupGet(x => x.Name).Returns("");
        //assert
        _wishNameValidator.IsValid(_wishMock.Object).Should().BeFalse();
    }

    [Fact]
    public void IsValid_NullName_ReturnsFalse()
    {
        //arrange
        string? nullString = null;
        _wishMock.SetupGet(x => x.Name).Returns(nullString);
        //assert
        _wishNameValidator.IsValid(_wishMock.Object).Should().BeFalse();
    }
}