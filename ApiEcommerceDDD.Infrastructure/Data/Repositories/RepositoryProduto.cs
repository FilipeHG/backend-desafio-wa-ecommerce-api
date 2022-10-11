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
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        private readonly Context context;

        public RepositoryProduto(Context context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            var query = BuildQuery();

            return await query.CountAsync();
        }

        public async Task<List<Produto>> ObterProdutosComPaginacao(int page, int limit, string sort)
        {
            var startRow = (page - 1) * limit;

            var query = BuildQuery();
            query = query.Skip(startRow);

            if (limit > 0)
                query = query.Take(limit);

            return await query.ToListAsync();
        }

        private IQueryable<Produto> BuildQuery()
        {
            var query = (from produto in context.Set<Produto>()
                         join pedido in context.Set<Produto>()
                             on produto.PedidoId equals pedido.Id
                         select new Produto { });

            return query.AsQueryable();
        }
    }
}
