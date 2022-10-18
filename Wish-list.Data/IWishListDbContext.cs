using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Wish_list.Core.Models;

namespace Wish_list.Data;

public interface IWishListDbContext
{
    DbSet<Wish> Wishes { get; set; }
    DbSet<T> Set<T>() where T : class;
    EntityEntry<T> Entry<T>(T entity) where T : class;
    int SaveChanges();
    Task<int> SaveChangesAsync();
}