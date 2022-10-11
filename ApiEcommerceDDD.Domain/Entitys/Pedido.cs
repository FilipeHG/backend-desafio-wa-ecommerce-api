using System;
using System.Collections.Generic;

namespace ApiEcommerceDDD.Domain.Entitys
{
    public class Pedido : Base
    {
        public long FrotaId { get; set; }

        public Frota Frota { get; set; }

        public List<Produto> Produtos { get; set; }

        public Endereco EnderecoDeEntrega { get; set; }

        public string Status { get; set; }

        public DateTime? DataEntrega { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public DateTime? DataDelecao { get; set; }
    }
}
