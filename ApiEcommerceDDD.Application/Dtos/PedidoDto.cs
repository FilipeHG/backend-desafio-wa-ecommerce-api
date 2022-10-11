using System;
using System.Collections.Generic;

namespace ApiEcommerceDDD.Application.Dtos
{
    public class PedidoDto
    {
        public long Id { get; set; }

        public long FrotaId { get; set; }

        public FrotaDto Frota { get; set; }

        public List<ProdutoDto> Produtos { get; set; }

        public EnderecoDto EnderecoDeEntrega { get; set; }

        public string Status { get; set; }

        public DateTime? DataEntrega { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public DateTime? DataDelecao { get; set; }
    }
}
