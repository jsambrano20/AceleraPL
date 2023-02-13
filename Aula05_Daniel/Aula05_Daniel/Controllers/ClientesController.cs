using Aula05_Daniel.Dados;
using Aula05_Daniel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula05_Daniel.Controllers
{
    public class ClientesController : Controller
    {

        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listar()
        {
            try
            {
                return View(Repositorio.ListarClientes());
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");

            }
        }

        [HttpGet]
        public ActionResult Incluir()
        {

            return View("Incluir");


        }

        [HttpPost]
        public ActionResult Incluir(Clientes novo)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                Repositorio.NovoCliente(novo);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");

            }
        }

        [HttpGet]
        private ActionResult BuscarCliente(int Codigo, string operacao)
        {
            try
            {
                var cliente = Repositorio.PesquisarCliente(Codigo);
                return View(operacao, cliente);
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }

        public ActionResult Detalhes(int Codigo)
        {
            return BuscarCliente(Codigo, "Pesquisar");
        }

        [HttpGet]
        public ActionResult Editar(int Codigo)
        {

            return BuscarCliente(Codigo, "Editar");

        }
        [HttpPost]
        public ActionResult Editar(Clientes cliente)
        {
            try
            {
                Repositorio.AlterarCliente(cliente);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }

        }


        [HttpGet]
        public ActionResult Excluir(int Codigo)
        {

            return BuscarCliente(Codigo, "Excluir");

        }
        [HttpPost]
        public ActionResult Excluir(Clientes cliente)
        {
            try
            {
                Repositorio.ApagarCliente(cliente);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }

        }


    }
}