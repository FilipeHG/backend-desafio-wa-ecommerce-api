using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryEndereco : IRepositoryBase<Endereco>
    {
        Task<List<Endereco>> ObterEnderecosComPaginacao(int page, int limit, string sort);

        Task<int> ObterTotalDeRegistros();
    }
}
