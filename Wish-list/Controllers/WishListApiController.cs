using Microsoft.AspNetCore.Mvc;
using Wish_list.Core.Interfaces;
using Wish_list.Core.Models;
using Wish_list.Core.Services;

namespace Wish_list.Controllers;

[Route("api/wishList")]
[ApiController]
public class WishListApiController : ControllerBase
{
    private readonly IEntityService<Wish> _entityService;
    private readonly IWishValidator _wishValidator;

    public WishListApiController(IEntityService<Wish> entityService, IWishValidator wishValidator)
    {
        _entityService = entityService;
        _wishValidator = wishValidator;
    }

    [Route("addWish")]
    [HttpPost]
    public IActionResult AddWish(Wish wish)
    {
        if (!_wishValidator.IsValid(wish)) return BadRequest();

        _entityService.Create(wish);

        return Created("", wish);
    }

    [Route("updateWish/{id}")]
    [HttpPut]
    public IActionResult UpdateWish(int id, Wish updatedWish)
    {
        if (!_wishValidator.IsValid(updatedWish)) return BadRequest();

        var wish = _entityService.GetById(id);

        if (wish == null) return BadRequest($"Wish id {id} does not exist");

        wish.Name = updatedWish.Name;
        wish.Url = updatedWish.Url;
        _entityService.Update(wish);

        return Ok(wish);
    }

    [Route("deleteWish/{id}")]
    [HttpDelete]
    public IActionResult DeleteWish(int id)
    {
        var wish = _entityService.GetById(id);

        if (wish != null) _entityService.Delete(wish);

        return Ok();
    }

    [Route("getWishById/{id}")]
    [HttpGet]
    public IActionResult GetWish(int id)
    {
        var wish = _entityService.GetById(id);

        if (wish == null) return NotFound();

        return Ok(wish);
    }

    [Route("getAll")]
    [HttpGet]
    public IActionResult GetWishList()
    {
        return Ok(_entityService.GetAll());
    }
}