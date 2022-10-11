using AutoMapper;
using ApiEcommerceDDD.Application.Dtos;
using ApiEcommerceDDD.Domain.Entitys;

namespace ApiEcommerceDDD.Application.Mappers
{
    public class ModelToDtoMappingPedido : Profile
    {
        public ModelToDtoMappingPedido()
        {
            PedidoDtoMap();
        }

        private void PedidoDtoMap()
        {
            CreateMap<Pedido, PedidoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.FrotaId, opt => opt.MapFrom(x => x.FrotaId))
                .ForMember(dest => dest.Frota, opt => opt.MapFrom(x => x.Frota))
                .ForMember(dest => dest.EnderecoDeEntrega, opt => opt.MapFrom(x => x.EnderecoDeEntrega))
                .ForMember(dest => dest.Produtos, opt => opt.MapFrom(x => x.Produtos))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(x => x.Status))
                .ForMember(dest => dest.DataEntrega, opt => opt.MapFrom(x => x.DataEntrega))
                .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(x => x.DataCriacao))
                .ForMember(dest => dest.DataAtualizacao, opt => opt.MapFrom(x => x.DataAtualizacao))
                .ForMember(dest => dest.DataDelecao, opt => opt.MapFrom(x => x.DataDelecao));
        }
    }
}
