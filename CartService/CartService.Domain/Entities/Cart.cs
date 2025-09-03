using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CartService.Domain;

public class Cart
{
    public Guid Id { get; private set; }
    public Guid UserId { get; set; }
    public List<CartItem>? Items { get; set; }
}
