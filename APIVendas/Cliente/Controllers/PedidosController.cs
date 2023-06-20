using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cliente.Models;

//namespace para conexão API
using System.Net.Http;
using System.Net.Http.Headers;

//Uso de dados da API
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Text;
using System.Web.Services.Description;

namespace Cliente.Controllers
{
    public class PedidosController : Controller
    {
        //Objeto de acesso a API
        HttpClient client;

        public PedidosController()
        {
            //Endereço da API e o tipo da Respotsa

            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44390/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        //Método para Listar os Pedidos do Cliente (via API)

        public async Task<ActionResult> Listar()
        {
            string API = "api/vendas/ListarPedidosCPF/" + Session["CPF"].ToString();

            var response = await client.GetAsync(API);

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();

                //List<Pedidos> <====JSON
                var lista = JsonConvert.DeserializeObject<Pedidos[]>(resultado).ToList();

                return View(lista);
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult NovoPedido()
        {
            Pedidos Novo = new Pedidos();
            Novo.CPF = Session["CPF"].ToString();
            return View(Novo);
        }

        [HttpPost]
        public async Task<ActionResult> NovoPedido(Pedidos Novo)
        {
            if (Session["CPF"] is null)
            {
                return View("Expirada");
            }

            Novo.Cod = 0; //Auto incremento
            Novo.Status = "FEITO"; //1º Status = Novo
            Novo.CPF = Session["CPF"].ToString();

            //Pedidos ===>JSON

            string json = JsonConvert.SerializeObject(Novo);

            HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

            var response = await client.PostAsync("api/vendas/NovoPedido", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Listar");
            else
                throw new Exception(response.ReasonPhrase);
        }

        [HttpGet]
        public ActionResult ConfirmarPedidoEntregue(string id)
        {
            Session["CodPedido"] = id;
            AvaliacaoPedido Novo = new AvaliacaoPedido();
            Novo.CodPedido = Convert.ToInt32(id);
            Novo.Avaliacao = "Escreve sua Avaliação...";

            return View(Novo);
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmarPedidoEntregue(AvaliacaoPedido Mudou)
        {
            Mudou.CodPedido = Convert.ToInt32(Session["CodPedido"].ToString());

            string json = JsonConvert.SerializeObject(Mudou);

            HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

            var response = await client.PutAsync("api/vendas/AvaliarPedido", content);


            if (response.IsSuccessStatusCode)
                return RedirectToAction("Listar");
            else
                throw new Exception(response.ReasonPhrase);
        }


        [HttpGet]
        public ActionResult CancelarPedidoNaoEnviado(string id)
        {
            Session["CodPedido"] = id;

            AvaliacaoPedido Novo = new AvaliacaoPedido();
            Novo.CodPedido = Convert.ToInt32(id);
            Novo.Avaliacao = "Descreva o Motivo do Cancelamento...";

            return View(Novo);
        }

        [HttpPost]
        public async Task<ActionResult> CancelarPedidoNaoEnviado(AvaliacaoPedido Mudou)
        {
            Mudou.CodPedido = Convert.ToInt32(Session["CodPedido"].ToString());

            string json = JsonConvert.SerializeObject(Mudou);

            HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

            var response = await client.PutAsync("api/vendas/CancelarPedido", content);


            if (response.IsSuccessStatusCode)
                return RedirectToAction("Listar");
            else
                throw new Exception(response.ReasonPhrase);

        }


        [HttpGet]
        public ActionResult DevolverPedidoCliente(string id)
        {
            Session["CodPedido"] = id;
            AvaliacaoPedido Novo = new AvaliacaoPedido();
            Novo.CodPedido = Convert.ToInt32(id);
            Novo.Avaliacao = "Escreve sua Avaliação...";

            return View(Novo);
        }

        [HttpPost]
        public async Task<ActionResult> DevolverPedidoCliente(AvaliacaoPedido Mudou)
        {

            Mudou.CodPedido = Convert.ToInt32(Session["CodPedido"].ToString());
            string json = JsonConvert.SerializeObject(Mudou);

            HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

            var response = await client.PutAsync("api/vendas/DevolvePedidoCliente", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Listar");
            else
                throw new Exception(response.ReasonPhrase);


        }




    }
}