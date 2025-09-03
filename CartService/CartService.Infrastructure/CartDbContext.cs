
using CartService.Domain;
using Microsoft.EntityFrameworkCore;

namespace CartService.Infrastructure;

public class CartDbContext : DbContext
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    public CartDbContext(DbContextOptions<CartDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasMany(c => c.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.HasOne(i => i.Cart)
                .WithMany()
                .HasForeignKey(i => i.CartId);
        });
    }
}
