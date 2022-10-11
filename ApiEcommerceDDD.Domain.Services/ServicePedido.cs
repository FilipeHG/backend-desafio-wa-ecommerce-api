using ApiEcommerceDDD.Domain.Core.Interfaces.Repositories;
using ApiEcommerceDDD.Domain.Core.Interfaces.Services;
using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Domain.Services
{
    public class ServicePedido : ServiceBase<Pedido>, IServicePedido
    {
        private readonly IRepositoryPedido _repositoryPedido;

        public ServicePedido(IRepositoryPedido repositoryPedido)
            : base(repositoryPedido)
        {
            this._repositoryPedido = repositoryPedido;
        }

        public async Task<Pedido> ObterPedidoCompletoPorId(long pedidoId)
        {
            return await this._repositoryPedido.ObterPedidoCompletoPorId(pedidoId);
        }

        public async Task<List<Pedido>> ObterPedidosComPaginacao(int page = 1, int limit = 1000, string sort = "")
        {
            return await this._repositoryPedido.ObterPedidosComPaginacao(page, limit, sort);
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            return await this._repositoryPedido.ObterTotalDeRegistros();
        }
    }
}