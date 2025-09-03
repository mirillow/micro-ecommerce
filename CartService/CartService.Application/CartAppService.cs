using CartService.Domain;

namespace CartService.Application;

public class CartAppService
{
    private ICartRepository _cartRepository;

    public CartAppService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    // Refactor these methods later and separate the cart from the item
    public async Task<Cart?> GetCartAsync(Guid userId)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId);

        if (cart != default)
            return cart;

        cart = new Cart { UserId = userId };
        await _cartRepository.InsertAsync(cart);

        return cart;
    }

    public async Task<Cart> AddItemAsync(Guid userId, Guid productId, int quantity, decimal price)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId) ?? throw new InvalidOperationException("Cart not found");

        var existingItem = cart.Items!.FirstOrDefault(i => i.ProductId == productId);
        if (existingItem is not null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            cart.Items!.Add(new CartItem { CartId = cart.Id,ProductId = productId, Quantity = quantity, Price = price });
        }

        await _cartRepository.UpdateAsync(cart);
        return cart;
    }

    public async Task RemoveItemAsync(Guid userId, Guid productId)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId)
                   ?? throw new InvalidOperationException("Cart not found");

        var itemToRemove = cart.Items?.First( x=> x.ProductId == productId ) ?? throw new InvalidOperationException("The specified item is not in the cart");
        cart.Items.Remove(itemToRemove);

        await _cartRepository.UpdateAsync(cart);
    }
}