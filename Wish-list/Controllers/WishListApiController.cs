using Microsoft.AspNetCore.Mvc;
using Wish_list.Core.Interfaces;
using Wish_list.Core.Models;
using Wish_list.Core.Services;

namespace Wish_list.Controllers;

[Route("api/wishList/wish")]
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

    [Route("create")]
    [HttpPost]
    public IActionResult CreateWish(Wish wish)
    {
        if (!_wishValidator.IsValid(wish)) return BadRequest();

        _entityService.Create(wish);

        return Created("", wish);
    }

    [Route("update/{id}")]
    [HttpPut]
    public IActionResult UpdateWish(int id, Wish updatedWish)
    {
        if (!_wishValidator.IsValid(updatedWish)) return BadRequest();

        var wish = _entityService.GetById(id);

        if (wish == null) return BadRequest($"Wish id {id} does not exist");

        wish.Name = updatedWish.Name;
        wish.Url = updatedWish.Url;
        wish.Notes = updatedWish.Notes;
        _entityService.Update(wish);

        return Ok(wish);
    }

    [Route("delete/{id}")]
    [HttpDelete]
    public IActionResult DeleteWish(int id)
    {
        var wish = _entityService.GetById(id);

        if (wish == null) return NotFound();

        _entityService.Delete(wish);

        return NoContent();
    }

    [Route("get/{id}")]
    [HttpGet]
    public IActionResult GetWish(int id)
    {
        var wish = _entityService.GetById(id);

        if (wish == null) return NotFound();

        return Ok(wish);
    }

    [Route("getAll")]
    [HttpGet]
    public IActionResult GetAllWishes()
    {
        var wishList = _entityService.GetAll();

        if (wishList.Count == 0) return NoContent();

        return Ok(wishList);
    }
}