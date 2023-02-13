using Aula04_AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula04_AdoNet.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            Repositorio pesq = new Repositorio();
            DataSet Tabelas = new DataSet();

            Tabelas = pesq.VoltaClientes();

            IEnumerable<DataRow> Clientes = from Cli in Tabelas.Tables[0].AsEnumerable()
                                                orderby Cli.Field<int>("Idade") descending
                                                    select Cli;

            IEnumerable<DataRow> ClientesFiltro = Clientes.Where(c => c.Field<int>("Idade") > 40);

            int iTotal = Clientes.Sum(p => p.Field<int>("Idade"));

            ViewBag.Dados = "";
            foreach (DataRow item in Tabelas.Tables[0].Rows)
            {
                ViewBag.Dados += item["Nome"].ToString() + " - ";
            }



            return View();
        }
    }
}