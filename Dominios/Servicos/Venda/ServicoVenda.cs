using Dominios.Interfaces;
using Dominios.Repositorio;
using SistemaVendas.Dominios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;


namespace Dominios.Servicos
{
    public class ServicoVenda : IServicoVenda
    {
        IRepositorioVenda RepositorioVenda;


        public ServicoVenda(IRepositorioVenda repositorioVenda)
        {
            RepositorioVenda = repositorioVenda;
        }

        public void Cadastrar(Venda Venda)
        {
            RepositorioVenda.Create(Venda);
        }

        public Venda CarregarRegistro(int id)
        {
            return RepositorioVenda.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioVenda.Delete(id);
        }

        public IEnumerable<Venda> Listagem()
        {
            return RepositorioVenda.Read();
        }
    }
}
