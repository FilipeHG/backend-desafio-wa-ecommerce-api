using AutoMapper;
using ApiEcommerceDDD.Application.Dtos;
using ApiEcommerceDDD.Application.Interfaces;
using ApiEcommerceDDD.Domain.Core.Interfaces.Services;
using ApiEcommerceDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEcommerceDDD.Application
{
    public class ApplicationServiceProduto : IApplicationServiceProduto
    {
        private readonly IServiceProduto _serviceProduto;
        private readonly IMapper _mapper;

        public ApplicationServiceProduto(IServiceProduto serviceProduto,
            IMapper mapper)
        {
            this._serviceProduto = serviceProduto;
            this._mapper = mapper;
        }

        public async Task<long> Add(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            await this._serviceProduto.Add(produto);

            return produto.Id;
        }

        public async Task Update(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            await this._serviceProduto.Update(produto);
        }

        public async Task Remove(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            await this._serviceProduto.Remove(produto);
        }

        public async Task AtualizarCamposEspecificos(ProdutoDto produtoDto)
        {
            var produto = this._serviceProduto.GetById(produtoDto.Id).Result;
            produto.Nome = produtoDto.Nome;
            produto.Descricao = produtoDto.Descricao;
            produto.Valor = produtoDto.Valor;

            await this._serviceProduto.Update(produto);
        }
    }
}