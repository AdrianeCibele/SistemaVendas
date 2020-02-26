using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Entidades;
using SistemaVendas.Models;
using SistemaVendas.Servico.Interfaces;

namespace SistemaVendas.Controllers
{
    public class VendaController : Controller
    {

        readonly IServicoAplicacaoVenda ServicoAplicacaoVenda;
        readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;
        readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;

        public VendaController(IServicoAplicacaoVenda servicoAplicacaoVenda,
            IServicoAplicacaoProduto servicoAplicacaoProduto,
            IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            ServicoAplicacaoVenda = servicoAplicacaoVenda;
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacaoVenda.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {

            VendaViewModel viewModel = new VendaViewModel();           

            if (id != null)
            {
                viewModel = ServicoAplicacaoVenda.CarregarRegistro((int)id);
            }

            viewModel.ListaClientes = ServicoAplicacaoCliente.ListagemDropDownList();
            viewModel.ListaProdutos = ServicoAplicacaoProduto.ListagemDropDownList();

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {

            if (ModelState.IsValid)
            {
               
                ServicoAplicacaoVenda.Cadastrar(entidade);
            }
            else
            {
                entidade.ListaClientes = ServicoAplicacaoCliente.ListagemDropDownList();
                entidade.ListaProdutos = ServicoAplicacaoProduto.ListagemDropDownList();
                return View(entidade);
            }
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Excluir(int id)
        {

            ServicoAplicacaoVenda.Excluir(id);

            return RedirectToAction("Index");
        }

        [HttpGet("LerValorProduto/{CodigoProduto}")]
        public decimal LerValorProduto(int CodigoProduto)
        {
            return (decimal)ServicoAplicacaoProduto.CarregarRegistro(CodigoProduto).Valor;

        }


    }
}