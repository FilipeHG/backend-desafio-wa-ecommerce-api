using Microsoft.AspNetCore.Mvc;
using ApiEcommerceDDD.Application.Dtos;
using ApiEcommerceDDD.Application.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiEcommerceDDD.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IApplicationServicePedido _applicationServicePedido;
        private readonly ILogger<PedidosController> _logger;

        public PedidosController(IApplicationServicePedido applicationServicePedido
            , ILogger<PedidosController> logger)
        {
            this._applicationServicePedido = applicationServicePedido;
            this._logger = logger;
        }

        /// <summary>
        /// Inserir Pedido.
        /// </summary>
        /// <param name="pedidoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] PedidoDto pedidoDTO)
        {
            try
            {
                if (pedidoDTO == null)
                    return NotFound();

                _applicationServicePedido.Add(pedidoDTO);
                return Ok("Pedido inserido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Alterar Pedido.
        /// </summary>
        /// <param name="pedidoDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put([FromBody] PedidoDto pedidoDTO)
        {
            try
            {
                if (pedidoDTO == null && pedidoDTO.Id > 0)
                    return NotFound();

                var pedidoExistente = _applicationServicePedido.ObterPedidoCompletoPorId(pedidoDTO.Id).Result;
                if (pedidoExistente != null)
                {
                    pedidoDTO.Id = pedidoExistente.Id;
                    pedidoDTO.FrotaId = (pedidoDTO.FrotaId == 0) ? pedidoExistente.FrotaId : pedidoDTO.FrotaId;
                    pedidoDTO.Frota.Id = (pedidoDTO.Frota.Id == 0) ? pedidoExistente.Frota.Id : pedidoDTO.Frota.Id;
                    pedidoDTO.EnderecoDeEntrega.Id = (pedidoDTO.EnderecoDeEntrega.Id == 0) ? pedidoExistente.EnderecoDeEntrega.Id : pedidoDTO.EnderecoDeEntrega.Id;
                    pedidoDTO.EnderecoDeEntrega.PedidoId = pedidoDTO.Id;

                    for (var i = 0; i < pedidoDTO.Produtos?.Count; i++)
                    {
                        if (pedidoExistente.Produtos?.Count > i)
                        {
                            pedidoDTO.Produtos[i].Id = pedidoExistente.Produtos[i].Id;
                            pedidoDTO.Produtos[i].PedidoId = pedidoDTO.Id;
                        }
                    }
                }
                else
                    return NotFound();

                _applicationServicePedido.Update(pedidoDTO);
                return Ok("Pedido atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletar Pedido por route {Id}.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] long id)
        {
            try
            {
                var registroDTO = _applicationServicePedido.GetById(id);

                if (registroDTO == null || registroDTO.Result == null)
                    return NotFound();

                // REMOÇÃO FÍSICA
                //_applicationServicePedido.Remove(registroDTO.Result);

                // REMOÇÃO LÓGICA
                _applicationServicePedido.SoftDelete(registroDTO.Result);

                return Ok("Pedido removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obter Pedidos com Paginação.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<PedidoDto>> Get([FromQuery] int page, [FromQuery] int limit, [FromQuery] string sort)
        {
            var result = _applicationServicePedido.ObterPedidosComPaginacao(page, limit, sort).Result;
            var totalDeRegistros = _applicationServicePedido.ObterTotalDeRegistros().Result;

            var paginationResult = new PaginationDto<PedidoDto>(result, totalDeRegistros, page, limit);

            return Ok(paginationResult);
        }

        /// <summary>
        /// Obter Pedido por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<PedidoDto> GetById([FromRoute] long id)
        {
            return Ok(_applicationServicePedido.GetById(id).Result);
        }
    }
}