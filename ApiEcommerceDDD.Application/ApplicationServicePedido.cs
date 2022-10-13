using AutoMapper;
using ApiEcommerceDDD.Application.Dtos;
using ApiEcommerceDDD.Application.Interfaces;
using ApiEcommerceDDD.Domain.Core.Interfaces.Services;
using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

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
            try
            {
                var pedido = _mapper.Map<Pedido>(pedidoDto);
                pedido.DataCriacao = System.DateTime.UtcNow;
                await this._servicePedido.Add(pedido);

                return pedido.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(PedidoDto pedidoDto)
        {
            try
            {
                var pedido = _mapper.Map<Pedido>(pedidoDto);
                pedido.DataAtualizacao = System.DateTime.UtcNow;

                await this._servicePedido.Update(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Remove(PedidoDto pedidoDto)
        {
            try
            {
                var pedido = _mapper.Map<Pedido>(pedidoDto);
                await this._servicePedido.Remove(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PedidoDto>> GetAll()
        {
            try
            {
                var pedidos = await this._servicePedido.GetAll();
                var pedidosDto = _mapper.Map<IEnumerable<PedidoDto>>(pedidos);

                return pedidosDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PedidoDto> GetById(long id)
        {
            try
            {
                var pedido = await this._servicePedido.GetById(id);
                var pedidoDto = _mapper.Map<PedidoDto>(pedido);

                return pedidoDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SoftDelete(PedidoDto pedidoDto)
        {
            try
            {
                var pedido = this._servicePedido.GetById(pedidoDto.Id).Result;
                pedido.DataDelecao = System.DateTime.UtcNow;

                await this._servicePedido.Update(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AtualizarCamposEspecificos(PedidoDto pedidoDto)
        {
            try
            {
                var pedido = this._servicePedido.GetById(pedidoDto.Id).Result;
                ComplementarPayloadCamposRelacionais(pedido, pedidoDto);

                pedido.DataAtualizacao = System.DateTime.UtcNow;
                pedido.Status = pedidoDto.Status;
                pedido.DataEntrega = pedidoDto.DataEntrega;

                await this._servicePedido.Update(pedido);

                await this._applicationServiceFrota.AtualizarCamposEspecificos(pedidoDto.Frota);
                await this._applicationServiceEndereco.AtualizarCamposEspecificos(pedidoDto.EnderecoDeEntrega);

                foreach (var produto in pedidoDto.Produtos)
                {
                    if (produto.Id > 0)
                        await this._applicationServiceProduto.AtualizarCamposEspecificos(produto);
                    else
                        await this._applicationServiceProduto.Add(produto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PedidoDto>> ObterPedidoCompletoPorId(long pedidoId)
        {
            try
            {
                var pedido = await this._servicePedido.ObterPedidoCompletoPorId(pedidoId);
                var pedidoDto = _mapper.Map<PedidoDto>(pedido);

                List<PedidoDto> pedidoDtoToAray = new List<PedidoDto> { pedidoDto };

                return pedidoDtoToAray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PedidoDto>> ObterPedidosComPaginacao(int page, int limit, string sort)
        {
            try
            {
                var pedidos = await this._servicePedido.ObterPedidosComPaginacao(page, limit, sort);
                var pedidosDto = _mapper.Map<IEnumerable<PedidoDto>>(pedidos);

                return pedidosDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            try
            {
                var total = await this._servicePedido.ObterTotalDeRegistros();
                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ComplementarPayloadCamposRelacionais(Pedido pedidoExistente, PedidoDto pedidoDto)
        {
            long frotaId = (pedidoDto.FrotaId > 0) ? pedidoDto.FrotaId : (pedidoDto.Frota.Id > 0 ? pedidoDto.Frota.Id : pedidoExistente.FrotaId);
            pedidoDto.FrotaId = frotaId;
            pedidoDto.Frota.Id = frotaId;
            pedidoDto.EnderecoDeEntrega.Id = (pedidoDto.EnderecoDeEntrega.Id == 0) ? pedidoExistente.EnderecoDeEntrega.Id : pedidoDto.EnderecoDeEntrega.Id;
            pedidoDto.EnderecoDeEntrega.PedidoId = pedidoDto.Id;

            for (var i = 0; i < pedidoDto.Produtos?.Count; i++)
            {
                if (pedidoExistente.Produtos?.Count > i)
                    pedidoDto.Produtos[i].Id = pedidoExistente.Produtos[i].Id;

                pedidoDto.Produtos[i].PedidoId = pedidoDto.Id;
            }
        }
    }
}
