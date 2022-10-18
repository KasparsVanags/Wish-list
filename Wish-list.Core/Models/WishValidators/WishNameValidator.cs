using Wish_list.Core.Interfaces;

namespace Wish_list.Core.Models.WishValidators;

public class WishNameValidator : IWishValidator
{
    public bool IsValid(IWish wish)
    {
        return !string.IsNullOrEmpty(wish.Name);
    }
}