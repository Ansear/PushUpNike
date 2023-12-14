using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int Id);
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T Entity);
    void AddRange(IEnumerable<T> Entities);
    void Remove(T Entity);
    void RemoveRange(IEnumerable<T> Entities);
    void Update(T Entity);

}