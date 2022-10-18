using Wish_list.Models;

namespace Wish_list.Extensions;

public static class UserExtensions
{
    public static string GetNames(this IEnumerable<User> users)
    {
        return string.Join(',', users.Select(user => user.Name));
    }
}