using AutoMapper;
using ApiEcommerceDDD.Application.Dtos;
using ApiEcommerceDDD.Domain.Entitys;

namespace ApiEcommerceDDD.Application.Mappers
{
    public class ModelToDtoMappingEndereco : Profile
    {
        public ModelToDtoMappingEndereco()
        {
            EnderecoDtoMap();
        }

        private void EnderecoDtoMap()
        {
            CreateMap<Endereco, EnderecoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.PedidoId, opt => opt.MapFrom(x => x.PedidoId))
                .ForMember(dest => dest.CEP, opt => opt.MapFrom(x => x.CEP))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(x => x.Logradouro))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(x => x.Numero))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(x => x.Complemento))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(x => x.Bairro))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(x => x.Cidade))
                .ForMember(dest => dest.UF, opt => opt.MapFrom(x => x.UF));
        }
    }
}
