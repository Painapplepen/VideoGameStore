using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(int id);
        
        Task CreateAsync(TEntity item);
        
        Task UpdateAsync(TEntity item);
        
        Task<bool> DeleteAsync(int id);
    }
}
