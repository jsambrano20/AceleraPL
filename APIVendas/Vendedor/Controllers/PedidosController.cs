using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Vendedor.Models;

using System.Net.Http;
using System.Net.Http.Headers;

using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Text;
using System.Web.UI.WebControls;

namespace Vendedor.Controllers
{
    public class PedidosController : Controller
    {
        HttpClient client;

        public PedidosController()
        {
            if(client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44390/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        public async Task<ActionResult> NovosPedidos()
        {
            var response = await client.GetAsync("api/vendas/listarpedidosstatus/FEITO");

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();

                var Lista = JsonConvert.DeserializeObject<Pedido[]>(resultado).ToList();
                return View(Lista);
            }
            else
                return View();
        }

        public async Task<ActionResult> ListaPedidos()
        {
            var response = await client.GetAsync("api/vendas/listarpedidos");
            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();

                var Lista = JsonConvert.DeserializeObject<Pedido[]>(resultado).ToList();
                return View(Lista);
            }
            else
                return View();
        }

        public async Task<ActionResult> MudarStatus(string id)
        {
            Status Mudou = new Status();

            Mudou.CodPedido = Convert.ToInt32(id);
            Mudou.NovoStatus = "ENVIADO";
            Mudou.Obs = "[VENDEDOR] Pedido disponivel para transporte";

            string json = JsonConvert.SerializeObject(Mudou);

            HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

            var response = await client.PostAsync("api/vendas/MudarStatusPedido", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("NovosPedidos");
            }
            else
                throw new Exception(response.ReasonPhrase);
        }

        public async Task<ActionResult> MudarStatusDevolvido(string id)
        {
            Status Mudou = new Status();

            Mudou.CodPedido = Convert.ToInt32(id);
            Mudou.NovoStatus = "ENTREGUE_DEV";
            Mudou.Obs = "[VENDEDOR] Pedido foi devolvido";

            string json = JsonConvert.SerializeObject(Mudou);

            HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

            var response = await client.PostAsync("api/vendas/MudarStatusPedido", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ListaPedidos");
            }
            else
                throw new Exception(response.ReasonPhrase);
        }

        public async Task<ActionResult> CancelarPedido(string id)
        {
            Status Mudou = new Status();

            Mudou.CodPedido = Convert.ToInt32(id);
            Mudou.NovoStatus = "CANCELADO_VENDEDOR";
            Mudou.Obs = "[VENDEDOR] Pedido Cancelado";

            string json = JsonConvert.SerializeObject(Mudou);

            HttpContent content = new StringContent(json, Encoding.Unicode, "application/json");

            var response = await client.PostAsync("api/vendas/MudarStatusPedido", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("NovosPedidos");
            }
            else
                throw new Exception(response.ReasonPhrase);
        }

        public async Task<ActionResult> HistoricoPedido(string id)
        {
            ViewData["Pedido"] = id;

            var response = await client.GetAsync("api/vendas/BuscarHistorico/" + id);
            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var Lista = JsonConvert.DeserializeObject<HistPedido[]>(resultado).ToList();
                return View(Lista);
            }
            else
                return View();
        }
    }
}