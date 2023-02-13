using Projeto01.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Controllers
{
    public class PedidosController : Controller
    {

        [HttpGet]
        public ActionResult Pedido()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pedido(Pedido pedido)
        {
            if (!ModelState.IsValid)
                return View();

            txt(pedido);
            return View("Lista", pedido);
        }

        [HttpGet]
        public ActionResult Lista()
        {

            string arquivo = @"C:\Users\Joao Sambrano\Desktop\Aula\Lista.txt";

            List<Pedido> lista = new List<Pedido>();
            using (StreamReader sr = new StreamReader(arquivo))
            {
                String linha;
                // Lê linha por linha até o final do arquivo
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] texto = linha.Split('#');


                    Pedido pedido = new Pedido()
                    {
                        ID = Convert.ToInt32(texto[0]),
                        Produto = texto[1],
                        Quantidade = Convert.ToInt32(texto[2])
                    };

                    lista.Add(pedido);
                }
            }

            return View(lista);
        }



        public void txt(Pedido pedido)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\Joao Sambrano\\Desktop\\Aula\\Lista.txt", true))
            {
                writer.WriteLine(pedido.ID + "#" + pedido.Produto + "#" + pedido.Quantidade);
            }
        }

    }
}