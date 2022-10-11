using ApiEcommerceDDD.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Application.Interfaces
{
    public interface IApplicationServiceFrota
    {
        Task<long> Add(FrotaDto frotaDto);

        Task Update(FrotaDto frotaDto);

        Task AtualizarCamposEspecificos(FrotaDto frotaDto);
    }
}