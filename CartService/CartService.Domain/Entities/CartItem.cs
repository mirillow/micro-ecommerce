using CartService.Domain;

public class CartItem
{
    public Guid Id { get; private set; }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Cart? Cart { get; set; }
}