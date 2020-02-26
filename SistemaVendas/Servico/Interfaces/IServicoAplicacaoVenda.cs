using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Servico.Interfaces
{
    public interface IServicoAplicacaoVenda
    {

        IEnumerable<VendaViewModel> Listagem();

        void Cadastrar(VendaViewModel Venda);

        VendaViewModel CarregarRegistro(int codigoVenda);

        void Excluir(int id);


    }
}
