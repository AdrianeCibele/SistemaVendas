using Dominios.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Dominios.Entidades;
using SistemaVendas.Models;
using SistemaVendas.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Servico
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {

        private IServicoProduto ServicoProduto;

        public ServicoAplicacaoProduto(IServicoProduto servicoProduto)
        {
            ServicoProduto = servicoProduto;
       }

        public void Cadastrar(ProdutoViewModel Produto)
        {
            Produto item = new Produto()
            {
                Codigo = Produto.Codigo,
                Descricao = Produto.Descricao,
                Quantidade = Produto.Quantidade,
                Valor = (decimal)Produto.Valor,
                CodigoCategoria = (int)Produto.CodigoCategoria
            };

            ServicoProduto.Cadastrar(item);

        }

        public ProdutoViewModel CarregarRegistro(int codigoProduto)
        {    
            var registro = ServicoProduto.CarregarRegistro(codigoProduto);

            ProdutoViewModel Produto = new ProdutoViewModel
            {
                Codigo = registro.Codigo,
                Descricao = registro.Descricao,
                Quantidade = registro.Quantidade,
                Valor = (decimal)registro.Valor,
                CodigoCategoria = (int)registro.CodigoCategoria
            };

            return Produto;
        }

        public void Excluir(int id)
        {
            ServicoProduto.Excluir(id);
        }

        public IEnumerable<ProdutoViewModel> Listagem()
        {
            var lista = ServicoProduto.Listagem();
            List<ProdutoViewModel> listaProduto = new List<ProdutoViewModel>();

            foreach (var registro in lista)
            {

                ProdutoViewModel Produto = new ProdutoViewModel
                {
                    Codigo = registro.Codigo,
                    Descricao = registro.Descricao,
                    Quantidade = registro.Quantidade,
                    Valor = (decimal)registro.Valor,
                    CodigoCategoria = (int)registro.CodigoCategoria,
                    DescricaoCategoria = registro.Categoria.Descricao

                };

                listaProduto.Add(Produto);
            }

            return listaProduto;
        }


        public IEnumerable<SelectListItem> ListagemDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();

            var lista = this.Listagem();

            foreach (var item in lista)
            {
                SelectListItem categoria = new SelectListItem
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                };

                retorno.Add(categoria);
            }

            return retorno;

        }

    }
}
