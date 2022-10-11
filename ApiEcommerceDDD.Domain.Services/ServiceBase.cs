using ApiEcommerceDDD.Domain.Core.Interfaces.Repositories;
using ApiEcommerceDDD.Domain.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this._repository = repository;
        }

        public async Task Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<TEntity> GetById(long id)
        {
            return _repository.GetById(id);
        }

        public async Task Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public async Task Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}
