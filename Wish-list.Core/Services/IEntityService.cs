using Wish_list.Core.Interfaces;

namespace Wish_list.Core.Services;

public interface IEntityService<T> where T : IEntity
{
    void Create(T entity);
    void Delete(T entity);
    void Update(T entity);
    List<T> GetAll();
    T? GetById(int id);
    IQueryable<T> Query();
}