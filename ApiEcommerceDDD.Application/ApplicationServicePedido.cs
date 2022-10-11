using AutoMapper;
using ApiEcommerceDDD.Application.Dtos;
using ApiEcommerceDDD.Application.Interfaces;
using ApiEcommerceDDD.Domain.Core.Interfaces.Services;
using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ApiEcommerceDDD.Application
{
    public class ApplicationServicePedido : IApplicationServicePedido
    {
        private readonly IApplicationServiceFrota _applicationServiceFrota;
        private readonly IApplicationServiceEndereco _applicationServiceEndereco;
        private readonly IApplicationServiceProduto _applicationServiceProduto;

        private readonly IServicePedido _servicePedido;
        private readonly IMapper _mapper;

        public ApplicationServicePedido(
            IApplicationServiceFrota applicationServiceFrota,
            IApplicationServiceEndereco applicationServiceEndereco,
            IApplicationServiceProduto applicationServiceProduto,
            IServicePedido servicePedido,
            IMapper mapper)
        {
            this._applicationServiceFrota = applicationServiceFrota;
            this._applicationServiceEndereco = applicationServiceEndereco;
            this._applicationServiceProduto = applicationServiceProduto;
            this._servicePedido = servicePedido;
            this._mapper = mapper;
        }

        public async Task<long> Add(PedidoDto pedidoDto)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDto);
            pedido.DataCriacao = System.DateTime.Now;
            await this._servicePedido.Add(pedido);

            return pedido.Id;
        }

        public async Task Update(PedidoDto pedidoDto)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDto);
            pedido.DataAtualizacao = System.DateTime.Now;

            try
            {
                await this._servicePedido.Update(pedido);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task Remove(PedidoDto pedidoDto)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDto);
            await this._servicePedido.Remove(pedido);
        }

        public async Task<IEnumerable<PedidoDto>> GetAll()
        {
            var pedidos = await this._servicePedido.GetAll();
            var pedidosDto = _mapper.Map<IEnumerable<PedidoDto>>(pedidos);

            return pedidosDto;
        }

        public async Task<PedidoDto> GetById(long id)
        {
            var pedido = await this._servicePedido.GetById(id);
            var pedidoDto = _mapper.Map<PedidoDto>(pedido);

            return pedidoDto;
        }

        public async Task SoftDelete(PedidoDto pedidoDto)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDto);
            pedido.DataDelecao = System.DateTime.Now;
            await this._servicePedido.Update(pedido);
        }

        public async Task<PedidoDto> ObterPedidoCompletoPorId(long pedidoId)
        {
            var pedido = await this._servicePedido.ObterPedidoCompletoPorId(pedidoId);
            var pedidoDto = _mapper.Map<PedidoDto>(pedido);

            return pedidoDto;
        }

        public async Task<IEnumerable<PedidoDto>> ObterPedidosComPaginacao(int page, int limit, string sort)
        {
            var pedidos = await this._servicePedido.ObterPedidosComPaginacao(page, limit, sort);
            var pedidosDto = _mapper.Map<IEnumerable<PedidoDto>>(pedidos);

            return pedidosDto;
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            var total = await this._servicePedido.ObterTotalDeRegistros();
            return total;
        }
    }
}