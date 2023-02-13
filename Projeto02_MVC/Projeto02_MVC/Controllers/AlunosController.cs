using Projeto02_MVC.Data;
using Projeto02_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto02_MVC.Controllers
{
    public class AlunosController : Controller
    {

        // GET: Alunos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listar()
        {
            try
            {
                return View(AlunosRepo.ListarAlunos());
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

            return View("Incluir");


        }

        [HttpPost]
        public ActionResult Incluir(Alunos novo)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                AlunosRepo.NovoAluno(novo);
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
                var cliente = AlunosRepo.PesquisarAluno(Codigo);
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
        public ActionResult Editar(Alunos cliente)
        {
            try
            {
                AlunosRepo.AlterarAluno(cliente);
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
        public ActionResult Excluir(Alunos cliente)
        {
            try
            {
                AlunosRepo.ApagarAluno(cliente);
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