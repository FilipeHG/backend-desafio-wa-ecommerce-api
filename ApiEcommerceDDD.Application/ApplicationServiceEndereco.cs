using AutoMapper;
using ApiEcommerceDDD.Application.Dtos;
using ApiEcommerceDDD.Application.Interfaces;
using ApiEcommerceDDD.Domain.Core.Interfaces.Services;
using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Application
{
    public class ApplicationServiceEndereco : IApplicationServiceEndereco
    {
        private readonly IServiceEndereco _serviceEndereco;
        private readonly IMapper _mapper;

        public ApplicationServiceEndereco(IServiceEndereco serviceEndereco,
            IMapper mapper)
        {
            this._serviceEndereco = serviceEndereco;
            this._mapper = mapper;
        }

        public async Task<long> Add(EnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            await this._serviceEndereco.Add(endereco);

            return endereco.Id;
        }

        public async Task Update(EnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            await this._serviceEndereco.Update(endereco);
        }
    }
}