using Microsoft.AspNetCore.Mvc;
using Wish_list.Extensions;
using Wish_list.Models;

namespace Wish_list.Controllers;

[Route("api/users")]
[ApiController]
public class UserApiController : ControllerBase
{
    [Route("getNames")]
    [HttpPost]
    public IActionResult GetNames(UserListRequest userList)
    {
        if (userList.Users.Count == 0) return BadRequest("User list can not be empty");

        return Ok(userList.Users.GetNames());
    }
}