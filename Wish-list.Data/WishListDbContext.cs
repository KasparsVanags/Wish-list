using Microsoft.EntityFrameworkCore;
using Wish_list.Core.Models;

namespace Wish_list.Data;

public class WishListDbContext : DbContext, IWishListDbContext
{
    public WishListDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Wish> Wishes { get; set; }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}