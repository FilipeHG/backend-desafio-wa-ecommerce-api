using AutoMapper;
using ApiEcommerceDDD.Application.Dtos;
using ApiEcommerceDDD.Domain.Entitys;

namespace ApiEcommerceDDD.Application.Mappers
{
    public class DtoToModelMappingFrota : Profile
    {
        public DtoToModelMappingFrota()
        {
            FrotaMap();
        }

        private void FrotaMap()
        {
            CreateMap<FrotaDto, Frota>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(x => x.Descricao))
                .ForMember(dest => dest.PlacaVeiculoUtilizado, opt => opt.MapFrom(x => x.PlacaVeiculoUtilizado));
        }
    }
}
