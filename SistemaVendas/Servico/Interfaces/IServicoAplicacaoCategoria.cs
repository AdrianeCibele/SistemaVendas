using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Servico.Interfaces
{
    public interface IServicoAplicacaoCategoria
    {

        IEnumerable<CategoriaViewModel> Listagem();

        IEnumerable<SelectListItem> ListagemDropDownList();

        void Cadastrar(CategoriaViewModel categoria);

        CategoriaViewModel CarregarRegistro(int codigoCategoria);

        void Excluir(int id);


    }
}
