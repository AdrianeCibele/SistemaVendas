using Dominios.Interfaces;
using Newtonsoft.Json;
using SistemaVendas.Dominios.Entidades;
using SistemaVendas.Models;
using SistemaVendas.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Servico
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {

        private IServicoVenda ServicoVenda;

        public ServicoAplicacaoVenda(IServicoVenda servicoVenda)
        {
            ServicoVenda = servicoVenda;
       }

        public void Cadastrar(VendaViewModel venda)
        {
            Venda item = new Venda()
            {
                Codigo = venda.Codigo,
                CodigoCliente = (int) venda.CodigoCliente,
                Data = (DateTime)venda.Data,
                Total = venda.Total,
                Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(venda.JsonProdutos)

            };

            ServicoVenda.Cadastrar(item);

        }


        public VendaViewModel CarregarRegistro(int codigoVenda)
        {
            var item = ServicoVenda.CarregarRegistro(codigoVenda);

            VendaViewModel Venda = new VendaViewModel
            {
                Codigo = item.Codigo,
                CodigoCliente = (int)item.CodigoCliente,
                Data = (DateTime)item.Data,
                Total = item.Total
            };

            return Venda;
        }

        public void Excluir(int id)
        {
            ServicoVenda.Excluir(id);
        }

        public IEnumerable<VendaViewModel> Listagem()
        {
            var lista = ServicoVenda.Listagem();
            List<VendaViewModel> listaVenda = new List<VendaViewModel>();

            foreach (var item in lista)
            {

                VendaViewModel Venda = new VendaViewModel
                {
                    Codigo = item.Codigo,
                    CodigoCliente = (int)item.CodigoCliente,
                    Data = (DateTime)item.Data,
                    Total = item.Total

                };

                listaVenda.Add(Venda);
            }

            return listaVenda;
        }

    }
}
