using Microsoft.AspNetCore.Mvc;
using Wish_list.Extensions;
using Wish_list.Models;

namespace Wish_list.Controllers;

[Route("api/user")]
[ApiController]
public class UserApiController : ControllerBase
{
    [Route("getNames")]
    [HttpPost]
    public IActionResult GetNames(List<User> users)
    {
        return Ok(users.GetNames());
    }
}