using ApiEcommerceDDD.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        Task<long> Add(ProdutoDto produtoDto);

        Task Update(ProdutoDto produtoDto);

        Task Remove(ProdutoDto produtoDto);

        Task AtualizarCamposEspecificos(ProdutoDto produtoDto);
    }
}