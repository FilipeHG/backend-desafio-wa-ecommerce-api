using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);

        Task Update(TEntity obj);

        Task Remove(TEntity obj);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(long id);
    }
}