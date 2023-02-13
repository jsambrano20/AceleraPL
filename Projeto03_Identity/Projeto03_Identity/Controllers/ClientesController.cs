using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto03_Identity.Data;

namespace Projeto03_Identity.Controllers
{
    public class ClientesController : Controller
    {
        private AtividadeIdentityEntities db = new AtividadeIdentityEntities();

        [Authorize(Roles = "members, User, Visual,Admin")]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return View(db.Cliente.ToList());
            else
                return View("Error");

        }

        [Authorize(Roles = "members, User")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [Authorize(Roles = "members, User")]

        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "members, User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                //db.SaveChanges();

                if (db.SaveChanges() > 0)
                {

                    Navegacao nav = new Navegacao()
                    {
                        Nome = User.Identity.Name,
                        IdAcao = cliente.ID,
                        Acao = "I"
                    };
                    db.Navegacao.Add(nav);
                    db.SaveChanges();

                }
                else
                {
                    return View("Error");

                }

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        [Authorize(Roles = "members, User")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [Authorize(Roles = "members, User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    Navegacao nav = new Navegacao()
                    {
                        Nome = User.Identity.Name,
                        IdAcao = cliente.ID,
                        Acao = "A"
                    };
                    db.Navegacao.Add(nav);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [Authorize(Roles = "members, Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
            if (db.SaveChanges() > 0)
            {
                Navegacao nav = new Navegacao()
                {
                    Nome = User.Identity.Name,
                    IdAcao = id,
                    Acao = "D"
                };
                db.Navegacao.Add(nav);
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
