using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Servico.Interfaces
{
    public interface IServicoAplicacaoCliente
    {

        IEnumerable<ClienteViewModel> Listagem();

        IEnumerable<SelectListItem> ListagemDropDownList();

        void Cadastrar(ClienteViewModel Cliente);

        ClienteViewModel CarregarRegistro(int codigoCliente);

        void Excluir(int id);


    }
}
