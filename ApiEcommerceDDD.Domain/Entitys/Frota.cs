using System;

namespace ApiEcommerceDDD.Domain.Entitys
{
    public class Frota : Base
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string PlacaVeiculoUtilizado { get; set; }
    }
}
