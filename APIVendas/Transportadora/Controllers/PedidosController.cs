using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transportadora.Models;

using System.Net.Http;
using System.Net.Http.Headers;

using System.Threading;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Transportadora.Controllers
{
    public class PedidosController : Controller
    {
        HttpClient client;

        public PedidosController()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44390/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        public async Task<ActionResult> RetirarPedidos()
        {
            var response = await client.GetAsync("api/vendas/listarpedidosstatus/ENVIADO");

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var Lista = JsonConvert.DeserializeObject<Pedidos[]>(resultado).ToList();
                return View(Lista);
            }
            else return View();
        }
        public async Task<ActionResult> RetirarPedidosDevolvido()
        {
            var response = await client.GetAsync("api/vendas/listarpedidosstatus/DEVOLVIDO");

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var Lista = JsonConvert.DeserializeObject<Pedidos[]>(resultado).ToList();
                return View(Lista);
            }
            else return View();
        }

        public async Task<ActionResult> EntregarPedidos()
        {
            var response = await client.GetAsync("api/vendas/listarpedidosstatus/EM_TRANSPORTE");

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var Lista = JsonConvert.DeserializeObject<Pedidos[]>(resultado).ToList();
                return View(Lista);
            }
            else return View();
        }

        public async Task<ActionResult> EntregarPedidosDevolvidos()
        {
            var response = await client.GetAsync("api/vendas/listarpedidosstatus/DEV_EM_TRANSPORTE");

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var Lista = JsonConvert.DeserializeObject<Pedidos[]>(resultado).ToList();
                return View(Lista);
            }
            else return View();
        }

        public async Task<ActionResult> PedidosEntregues()
        {
            var response = await client.GetAsync("api/vendas/listarpedidosstatus/ENTREGUE");

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var Lista = JsonConvert.DeserializeObject<Pedidos[]>(resultado).ToList();
                return View(Lista);
            }
            else return View();
        }

        public async Task<ActionResult> TodosPedidos()
        {
            var response = await client.GetAsync("api/vendas/listarpedidosstatus/ENTREGUE_DEV");

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var Lista = JsonConvert.DeserializeObject<Pedidos[]>(resultado).ToList();
                return View(Lista);
            }
            else return View();
        }

        public async Task<ActionResult> MudarStatusRetirado(string id)
        {
            Status Mudou = new Status();

            Mudou.CodPedido = Convert.ToInt32(id);
            Mudou.NovoStatus = "EM_TRANSPORTE";
            Mudou.Obs = "[Transportadora] Pedido a Caminho da Entrega";

            string json = JsonConvert.SerializeObject(Mudou);

            HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

            var response = await client.PostAsync("api/vendas/MudarStatusPedido", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("RetirarPedidos");
            }
            else
                throw new Exception(response.ReasonPhrase);
        }

        public async Task<ActionResult> MudarStatusRetiradoDevolvido(string id)
        {
            Status Mudou = new Status();

            Mudou.CodPedido = Convert.ToInt32(id);
            Mudou.NovoStatus = "DEV_EM_TRANSPORTE";
            Mudou.Obs = "[Transportadora] Pedido a Caminho da Devolução";

            string json = JsonConvert.SerializeObject(Mudou);

            HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

            var response = await client.PostAsync("api/vendas/MudarStatusPedido", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("RetirarPedidos");
            }
            else
                throw new Exception(response.ReasonPhrase);
        }

        public async Task<ActionResult> MudarStatusEntregue(string id)
        {
            Status Mudou = new Status();

            Mudou.CodPedido = Convert.ToInt32(id);
            Mudou.NovoStatus = "ENTREGUE";
            Mudou.Obs = "[Transportadora] Pedido entregue";

            string json = JsonConvert.SerializeObject(Mudou);

            HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

            var response = await client.PostAsync("api/vendas/MudarStatusPedido", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("EntregarPedidos");
            }
            else
                throw new Exception(response.ReasonPhrase);
        }

        public async Task<ActionResult> MudarStatusDevolvido(string id)
        {
            Status Mudou = new Status();

            Mudou.CodPedido = Convert.ToInt32(id);
            Mudou.NovoStatus = "DEV_ENTREGUE";
            Mudou.Obs = "[Transportadora] Pedido DEVOLVIDO entregue";

            string json = JsonConvert.SerializeObject(Mudou);

            HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

            var response = await client.PostAsync("api/vendas/MudarStatusPedido", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("EntregarPedidos");
            }
            else
                throw new Exception(response.ReasonPhrase);
        }
    }
}