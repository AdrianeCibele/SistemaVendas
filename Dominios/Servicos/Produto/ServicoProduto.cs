using Dominios.Interfaces;
using Dominios.Repositorio;
using SistemaVendas.Dominios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;


namespace Dominios.Servicos
{
    public class ServicoProduto : IServicoProduto
    {
        IRepositorioProduto RepositorioProduto;


        public ServicoProduto(IRepositorioProduto repositorioProduto)
        {
            RepositorioProduto = repositorioProduto;
        }

        public void Cadastrar(Produto Produto)
        {
            RepositorioProduto.Create(Produto);
        }

        public Produto CarregarRegistro(int id)
        {
            return RepositorioProduto.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioProduto.Delete(id);
        }

        public IEnumerable<Produto> Listagem()
        {
            return RepositorioProduto.Read();
        }
    }
}
