using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryFrota : IRepositoryBase<Frota>
    {
        Task<List<Frota>> ObterFrotasComPaginacao(int page, int limit, string sort);

        Task<int> ObterTotalDeRegistros();
    }
}
