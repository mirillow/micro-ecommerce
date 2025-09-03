using CartService.Domain;

public interface ICartRepository
{
    Task<Cart?> GetByUserIdAsync(Guid userId);
    Task InsertAsync(Cart cart);
    Task UpdateAsync(Cart cart);
}