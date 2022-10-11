using ApiEcommerceDDD.Domain.Core.Interfaces.Repositories;
using ApiEcommerceDDD.Domain.Core.Interfaces.Services;
using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Domain.Services
{
    public class ServiceEndereco : ServiceBase<Endereco>, IServiceEndereco
    {
        private readonly IRepositoryEndereco _repositoryEndereco;

        public ServiceEndereco(IRepositoryEndereco repositoryEndereco)
            : base(repositoryEndereco)
        {
            this._repositoryEndereco = repositoryEndereco;
        }

        public async Task<List<Endereco>> ObterEnderecosComPaginacao(int page = 1, int limit = 1000, string sort = "")
        {
            return await this._repositoryEndereco.ObterEnderecosComPaginacao(page, limit, sort);
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            return await this._repositoryEndereco.ObterTotalDeRegistros();
        }
    }
}