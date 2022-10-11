using System;

namespace ApiEcommerceDDD.Application.Dtos
{
    public class EnderecoDto
    {
        public long Id { get; set; }

        public long PedidoId { get; set; }

        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }
    }
}
