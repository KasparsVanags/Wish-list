using Microsoft.EntityFrameworkCore;
using Wish_list.Core.Models;
using Wish_list.Core.Services;
using Wish_list.Data;

namespace Wish_list.Services;

public class EntityService<T> : IEntityService<T> where T : Entity
{
    private readonly IWishListDbContext _context;

    public EntityService(IWishListDbContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().SingleOrDefault(e => e.Id == id);
    }

    public IQueryable<T> Query()
    {
        return _context.Set<T>().AsQueryable();
    }
}