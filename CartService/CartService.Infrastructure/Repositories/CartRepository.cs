using CartService.Domain;
using CartService.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class CartRepository : ICartRepository
{
    private CartDbContext _context;

    public CartRepository(CartDbContext context)
    {
        _context = context;
    }

    public async Task<Cart?> GetByUserIdAsync(Guid userId)
    {
        return await _context.Carts.Include(i => i.Items).FirstOrDefaultAsync(c => c.UserId == userId);
    }

    public async Task InsertAsync(Cart cart)
    {
        await _context.Carts.AddAsync(cart);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cart cart)
    {
        _context.Carts.Update(cart);
        await _context.SaveChangesAsync();
    }

}