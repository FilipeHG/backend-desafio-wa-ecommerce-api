using System;

namespace ApiEcommerceDDD.Domain.Entitys
{
    public class Produto : Base
    {
        public long PedidoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }
    }
}
