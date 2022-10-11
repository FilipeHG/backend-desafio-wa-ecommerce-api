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
    public class RepositoryEndereco : RepositoryBase<Endereco>, IRepositoryEndereco
    {
        private readonly Context context;

        public RepositoryEndereco(Context context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            var query = BuildQuery();

            return await query.CountAsync();
        }

        public async Task<List<Endereco>> ObterEnderecosComPaginacao(int page, int limit, string sort)
        {
            var startRow = (page - 1) * limit;

            var query = BuildQuery();
            query = query.Skip(startRow);

            if (limit > 0)
                query = query.Take(limit);

            return await query.ToListAsync();
        }

        private IQueryable<Endereco> BuildQuery()
        {
            var query = (from endereco in context.Set<Endereco>()
                         join pedido in context.Set<Endereco>()
                             on endereco.PedidoId equals pedido.Id
                         select new Endereco { });

            return query.AsQueryable();
        }
    }
}
