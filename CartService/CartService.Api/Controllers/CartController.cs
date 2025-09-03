using AutoMapper;
using CartService.Api.Dtos;
using CartService.Application;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private CartAppService _cartService;
    private IMapper _mapper;

    public CartController(CartAppService cartService, IMapper mapper)
    {
        _cartService = cartService;
        _mapper = mapper;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<CartDto>> GetCart(Guid userId)
    {
        var cart = await _cartService.GetCartAsync(userId);
        var cartDto = _mapper.Map<CartDto>(cart);
        return Ok(cartDto);
    }

    // Change this so that you act on cartId instead of the user
    [HttpPost("{userId}/items")]
    public async Task<ActionResult<CartDto>> AddItem(Guid userId, [FromBody] AddItemDto dto)
    {
        var cart = await _cartService.AddItemAsync(userId, dto.ProductId, dto.Quantity, dto.Price);
        var cartDto = _mapper.Map<CartDto>(cart);
        return Ok(cartDto);
    }

    [HttpDelete("{userId}/items/{productId}")]
    public async Task<IActionResult> RemoveItem(Guid userId, Guid productId)
    {
        await _cartService.RemoveItemAsync(userId, productId);
        return NoContent();
    }
}


