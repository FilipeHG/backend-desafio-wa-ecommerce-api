using ApiEcommerceDDD.Domain.Core.Interfaces.Repositories;
using ApiEcommerceDDD.Domain.Core.Interfaces.Services;
using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Domain.Services
{
    public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
    {
        private readonly IRepositoryProduto _repositoryProduto;

        public ServiceProduto(IRepositoryProduto repositoryProduto)
            : base(repositoryProduto)
        {
            this._repositoryProduto = repositoryProduto;
        }

        public async Task<List<Produto>> ObterProdutosComPaginacao(int page = 1, int limit = 1000, string sort = "")
        {
            return await this._repositoryProduto.ObterProdutosComPaginacao(page, limit, sort);
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            return await this._repositoryProduto.ObterTotalDeRegistros();
        }
    }
}