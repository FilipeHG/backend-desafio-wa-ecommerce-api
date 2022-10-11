using ApiEcommerceDDD.Domain.Core.Interfaces.Repositories;
using ApiEcommerceDDD.Domain.Core.Interfaces.Services;
using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Domain.Services
{
    public class ServiceFrota : ServiceBase<Frota>, IServiceFrota
    {
        private readonly IRepositoryFrota _repositoryFrota;

        public ServiceFrota(IRepositoryFrota repositoryFrota)
            : base(repositoryFrota)
        {
            this._repositoryFrota = repositoryFrota;
        }

        public async Task<List<Frota>> ObterFrotasComPaginacao(int page = 1, int limit = 1000, string sort = "")
        {
            return await this._repositoryFrota.ObterFrotasComPaginacao(page, limit, sort);
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            return await this._repositoryFrota.ObterTotalDeRegistros();
        }
    }
}