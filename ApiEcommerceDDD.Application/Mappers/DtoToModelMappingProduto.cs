using AutoMapper;
using ApiEcommerceDDD.Application.Dtos;
using ApiEcommerceDDD.Domain.Entitys;

namespace ApiEcommerceDDD.Application.Mappers
{
    public class DtoToModelMappingProduto : Profile
    {
        public DtoToModelMappingProduto()
        {
            ProdutoMap();
        }

        private void ProdutoMap()
        {
            CreateMap<ProdutoDto, Produto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.PedidoId, opt => opt.MapFrom(x => x.PedidoId))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(x => x.Descricao))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(x => x.Valor));
        }
    }
}
