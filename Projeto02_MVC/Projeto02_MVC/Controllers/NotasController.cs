using Projeto02_MVC.Data;
using Projeto02_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto02_MVC.Controllers
{
    public class NotasController : Controller
    {

        // GET: Notas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listar()
        {
            try
            {
                return View(NotasRepo.ListarNotas());
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("Erro");

            }
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            var lista = AlunosRepo.ListarAlunos();
            List<string> aux = new List<string>();
            foreach (var item in lista)
            {
                string id = item.Cod.ToString();

                aux.Add(id);
            }

            ViewBag.Lista = new SelectList(aux);
            return View("Incluir");

        }

        [HttpPost]
        public ActionResult Incluir(Notas novo)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                NotasRepo.NovoNota(novo);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("Erro");

            }
        }

        [HttpGet]
        private ActionResult BuscarAluno(int Codigo, string operacao)
        {
            try
            {
                var cliente = NotasRepo.PesquisarNota(Codigo);
                return View(operacao, cliente);
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("Erro");
            }
        }

        public ActionResult Detalhes(int Codigo)
        {
            return BuscarAluno(Codigo, "Pesquisar");
        }

        [HttpGet]
        public ActionResult Editar(int Codigo)
        {

            return BuscarAluno(Codigo, "Editar");

        }
        [HttpPost]
        public ActionResult Editar(Notas cliente)
        {
            try
            {
                NotasRepo.AlterarNota(cliente);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("Erro");
            }

        }


        [HttpGet]
        public ActionResult Excluir(int Codigo)
        {

            return BuscarAluno(Codigo, "Excluir");

        }
        [HttpPost]
        public ActionResult Excluir(Notas cliente)
        {
            try
            {
                NotasRepo.ApagarNota(cliente);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("Erro");
            }

        }
    }
}