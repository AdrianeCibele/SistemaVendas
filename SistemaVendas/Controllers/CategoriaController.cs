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
    public class CategoriaController : Controller
    {

        readonly IServicoAplicacaoCategoria ServicoAplicacao;

        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacao = servicoAplicacaoCategoria;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacao.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {

            CategoriaViewModel viewModel = new CategoriaViewModel();
            
            if(id != null)
            viewModel = ServicoAplicacao.CarregarRegistro((int)id);

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {

            if (ModelState.IsValid)
            {
                ServicoAplicacao.Cadastrar(entidade);
            }
            else
            {
                return View(entidade);
            }
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Excluir(int id)
        {

            ServicoAplicacao.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}