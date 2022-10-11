using ApiEcommerceDDD.Domain.Core.Interfaces.Repositories;
using ApiEcommerceDDD.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApiEcommerceDDD.Infrastructure.Data.Repositories
{
    public class RepositoryPedido : RepositoryBase<Pedido>, IRepositoryPedido
    {
        private readonly Context context;

        public RepositoryPedido(Context context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            var query = BuildQuery();
            return await query.CountAsync();
        }

        public async Task<List<Pedido>> ObterPedidosComPaginacao(int page, int limit, string sort)
        {
            var startRow = (page - 1) * limit;

            var query = BuildQuery();
            query = query.Skip(startRow);

            if (limit > 0)
                query = query.Take(limit);

            return await query.ToListAsync();
        }

        public async Task<Pedido> ObterPedidoCompletoPorId(long pedidoId)
        {
            var query = BuildQuery(pedidoId);
            return await query.FirstOrDefaultAsync();
        }

        private IQueryable<Pedido> BuildQuery(long? pedidoId = null)
        {
            var query = (from pedido in context.Set<Pedido>()
                         join frota in context.Set<Frota>()
                             on pedido.FrotaId equals frota.Id
                         join endereco in context.Set<Endereco>()
                             on pedido.Id equals endereco.PedidoId
                         join produto in context.Set<Produto>()
                             on pedido.Id equals produto.PedidoId
                         where pedido.DataDelecao == null
                         select new Pedido
                         {
                             Id = pedido.Id,
                             FrotaId = pedido.FrotaId,
                             Frota = frota,
                             EnderecoDeEntrega = endereco,
                             Produtos = new List<Produto> { produto },
                             Status = pedido.Status,
                             DataEntrega = pedido.DataEntrega,
                             DataCriacao = pedido.DataCriacao,
                             DataAtualizacao = pedido.DataAtualizacao,
                             DataDelecao = pedido.DataDelecao
                         });

            if (pedidoId != null && pedidoId > 0)
                query = query.Where(e => e.Id == pedidoId);

            query = query.OrderBy(x => x.DataCriacao);

            return query.AsQueryable();
        }
    }
}
