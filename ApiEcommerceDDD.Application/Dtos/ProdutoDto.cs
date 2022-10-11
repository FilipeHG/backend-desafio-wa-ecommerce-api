using System;

namespace ApiEcommerceDDD.Application.Dtos
{
    public class ProdutoDto
    {
        public long Id { get; set; }

        public long PedidoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }
    }
}
