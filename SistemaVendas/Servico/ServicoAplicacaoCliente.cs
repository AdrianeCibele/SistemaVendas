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
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {

        private IServicoCliente ServicoCliente;

        public ServicoAplicacaoCliente(IServicoCliente servicoCliente)
        {
            ServicoCliente = servicoCliente;
        }

        public void Cadastrar(ClienteViewModel Cliente)
        {
            Cliente item = new Cliente()
            {
                Codigo = Cliente.Codigo,
                Nome = Cliente.Nome,
                Celular = Cliente.Celular,
                CNPJ_CPF = Cliente.CNPJ_CPF,
                Email = Cliente.Email
            };

            ServicoCliente.Cadastrar(item);

        }


        public ClienteViewModel CarregarRegistro(int codigoCliente)
        {
            var item = ServicoCliente.CarregarRegistro(codigoCliente);

            ClienteViewModel Cliente = new ClienteViewModel
            {
                Codigo = item.Codigo,
                Nome = item.Nome,
                Celular = item.Celular,
                CNPJ_CPF = item.CNPJ_CPF,
                Email = item.Email
            };

            return Cliente;
        }

        public void Excluir(int id)
        {
            ServicoCliente.Excluir(id);
        }

        public IEnumerable<ClienteViewModel> Listagem()
        {
            var lista = ServicoCliente.Listagem();
            List<ClienteViewModel> listaCliente = new List<ClienteViewModel>();

            foreach (var item in lista)
            {

                ClienteViewModel Cliente = new ClienteViewModel
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    Celular = item.Celular,
                    CNPJ_CPF = item.CNPJ_CPF,
                    Email = item.Email

                };

                listaCliente.Add(Cliente);
            }

            return listaCliente;
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
                    Text = item.Nome
                };

                retorno.Add(categoria);
            }

            return retorno;

        }


    }
}
