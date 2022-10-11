using ApiEcommerceDDD.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Application.Interfaces
{
    public interface IApplicationServiceEndereco
    {
        Task<long> Add(EnderecoDto enderecoDto);

        Task Update(EnderecoDto enderecoDto);

        Task AtualizarCamposEspecificos(EnderecoDto enderecoDto);
    }
}