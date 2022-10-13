using ApiEcommerceDDD.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Application.Interfaces
{
    public interface IApplicationServicePedido
    {
        Task<long> Add(PedidoDto pedidoDto);

        Task Update(PedidoDto pedidoDto);

        Task Remove(PedidoDto pedidoDto);

        Task<IEnumerable<PedidoDto>> GetAll();

        Task<PedidoDto> GetById(long id);

        Task SoftDelete(PedidoDto pedidoDto);

        Task AtualizarCamposEspecificos(PedidoDto pedidoDto);

        Task<IEnumerable<PedidoDto>> ObterPedidoCompletoPorId(long pedidoId);

        Task<IEnumerable<PedidoDto>> ObterPedidosComPaginacao(int page, int limit, string sort);

        Task<int> ObterTotalDeRegistros();
    }
}