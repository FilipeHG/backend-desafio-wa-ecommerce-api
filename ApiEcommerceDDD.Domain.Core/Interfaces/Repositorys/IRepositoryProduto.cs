using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryProduto : IRepositoryBase<Produto>
    {
        Task<List<Produto>> ObterProdutosComPaginacao(int page, int limit, string sort);

        Task<int> ObterTotalDeRegistros();
    }
}
