using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Domain.Core.Interfaces.Services
{
    public interface IServicePedido : IServiceBase<Pedido>
    {
        Task<Pedido> ObterPedidoCompletoPorId(long pedidoId);

        Task<List<Pedido>> ObterPedidosComPaginacao(int page, int limit, string sort);

        Task<int> ObterTotalDeRegistros();
    }
}