using AutoMapper;
using ApiEcommerceDDD.Application.Dtos;
using ApiEcommerceDDD.Application.Interfaces;
using ApiEcommerceDDD.Domain.Core.Interfaces.Services;
using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ApiEcommerceDDD.Application
{
    public class ApplicationServiceFrota : IApplicationServiceFrota
    {
        private readonly IServiceFrota _serviceFrota;
        private readonly IMapper _mapper;

        public ApplicationServiceFrota(IServiceFrota serviceFrota,
            IMapper mapper)
        {
            this._serviceFrota = serviceFrota;
            this._mapper = mapper;
        }

        public async Task<long> Add(FrotaDto frotaDto)
        {
            try
            {
                var frota = _mapper.Map<Frota>(frotaDto);
                await this._serviceFrota.Add(frota);

                return frota.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(FrotaDto frotaDto)
        {
            try
            {
                var frota = _mapper.Map<Frota>(frotaDto);
                await this._serviceFrota.Update(frota);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AtualizarCamposEspecificos(FrotaDto frotaDto)
        {
            try
            {
                var frota = this._serviceFrota.GetById(frotaDto.Id).Result;
                frota.Nome = frotaDto.Nome;
                frota.Descricao = frotaDto.Descricao;
                frota.PlacaVeiculoUtilizado = frotaDto.PlacaVeiculoUtilizado;

                await this._serviceFrota.Update(frota);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}