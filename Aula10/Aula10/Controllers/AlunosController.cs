using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Acesso a API
using System.Net.Http;
using System.Net.Http.Headers;
//Uso API
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Services.Description;
using Aula10.Models;

namespace Aula10.Controllers
{
    public class AlunosController : Controller
    {

        //Objeto de acesso
        HttpClient client;


        public AlunosController()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44376/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        //se respondeu
        public async Task<ActionResult> Listar()
        {
            try
            {
                //procurar o servico
                var response = await client.GetAsync("Api/Alunos/ListarAlunos");

                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadAsStringAsync();

                    var lista = JsonConvert.DeserializeObject<Alunos[]>(resultado).ToList();

                    return View(lista);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception erro)
            {

                return View("erro");
            }
        }

        public async Task<ActionResult> ListarMaterias()
        {
            try
            {
                //procurar o servico

                var response = await client.GetAsync("api/alunos/ListarMaterias");

                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadAsStringAsync();

                    //var lista = JsonConvert.DeserializeObject<Alunos[]>(resultado).ToList();

                    var lista = JsonConvert.SerializeObject(resultado);

                    ViewBag.Lista = lista;

                    ViewBag.Lista = new List<string>();
                    string listas = lista;
                    var listmaterias = listas.Split('\\').ToList();

                    foreach (var materia in listmaterias)
                    {
                        string materia1 = materia.Replace("\"", "").Replace("[", "").Replace("]", "").Replace(",", "");
                        

                        if (!string.IsNullOrEmpty(materia1))
                        {
                            ViewBag.Lista.Add(materia1);

                        }
                    }

                    return View();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception erro)
            {

                return View("erro");
            }
        }

        public async Task<ActionResult> Pesquisar(int id)
        {
            try
            {
                //procurar o servico
                var response = await client.GetAsync($"api/alunos/PesquisarAlunos/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadAsStringAsync();

                    resultado = "[" + resultado + "]";

                    var lista = JsonConvert.DeserializeObject<Alunos[]>(resultado).ToList();

                    return View(lista);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception erro)
            {

                return View("erro");
            }
        }


        // GET: Alunos
        public ActionResult Index()
        {
            return View();
        }

    }
}