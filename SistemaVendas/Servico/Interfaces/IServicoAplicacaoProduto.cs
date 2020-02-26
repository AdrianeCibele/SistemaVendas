using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Servico.Interfaces
{
    public interface IServicoAplicacaoProduto
    {

        IEnumerable<ProdutoViewModel> Listagem();

        IEnumerable<SelectListItem> ListagemDropDownList();

        void Cadastrar(ProdutoViewModel Produto);

        ProdutoViewModel CarregarRegistro(int codigoProduto);

        void Excluir(int id);


    }
}
