using AutoMapper;
using ApiEcommerceDDD.Application.Dtos;
using ApiEcommerceDDD.Domain.Entitys;

namespace ApiEcommerceDDD.Application.Mappers
{
    public class ModelToDtoMappingProduto : Profile
    {
        public ModelToDtoMappingProduto()
        {
            ProdutoDtoMap();
        }

        private void ProdutoDtoMap()
        {
            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.PedidoId, opt => opt.MapFrom(x => x.PedidoId))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(x => x.Descricao))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(x => x.Valor));
        }
    }
}
