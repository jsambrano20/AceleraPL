using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula07_Identity.Controllers
{
    public class HomeController : Controller
    {
        //teste@tst.com pwd: Teste@22

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Teste1()
        {
            if (User.Identity.IsAuthenticated)
                return "Autenticado";
            else
                return "Não Autenticado";
        }

        public string Teste2()
        {
            if (User.Identity.Name == "Admin@tst.com")
                return "Oi ADM";
            else
                return "Não é o ADM";
        }

        public string Teste3()
        {
            if (User.IsInRole("Admin"))
                return "Bem vindo Adm";
            else
                return "Não é o ADM";
        }

        [Authorize(Roles ="members, Admin")]
        public string Teste4()
        {
                return "Voce é o cara";
        }
    }
}