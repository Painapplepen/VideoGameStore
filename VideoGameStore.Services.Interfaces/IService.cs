using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Services.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(int id);

        Task<bool> CreateAsync(TEntity item);

        Task<bool> UpdateAsync(TEntity item);

        Task<bool> DeleteAsync(int id);
    }
}
