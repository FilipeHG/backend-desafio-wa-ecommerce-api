using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryPedido : IRepositoryBase<Pedido>
    {
        Task<Pedido> ObterPedidoCompletoPorId(long pedidoId);

        Task<List<Pedido>> ObterPedidosComPaginacao(int page, int limit, string sort);

        Task<int> ObterTotalDeRegistros();
    }
}
