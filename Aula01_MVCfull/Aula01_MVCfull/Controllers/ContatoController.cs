using Aula01_MVCfull.Models;
using Aula01_MVCfull.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Aula01_MVCfull.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        //GET
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepository.ListarContatos();
            return View(contatos);
        }

        //GET
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Criado com Sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro no sistema. {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            _contatoRepository.Editar(contato);
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepository.BuscarporID(id);
            return View(contato);
        }

        //GET
        public IActionResult Excluir(int id)
        {
            ContatoModel contato = _contatoRepository.BuscarporID(id);
            return View(contato);

        }

        public IActionResult ExcluirID(int id)
        {
            _contatoRepository.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
