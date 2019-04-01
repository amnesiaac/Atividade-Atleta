using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppAtleta.Models;

namespace AppAtleta.Controllers
{
    public class UniformesController : Controller
    {
        private AppAtletaContext db = new AppAtletaContext();

        // GET: Uniformes
        public ActionResult Index()
        {
            var uniformes = db.Uniformes.Include(u => u.Atleta);
            return View(uniformes.ToList());
        }

        // GET: Uniformes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uniforme uniforme = db.Uniformes.Find(id);
            if (uniforme == null)
            {
                return HttpNotFound();
            }
            return View(uniforme);
        }

        // GET: Uniformes/Create
        public ActionResult Create()
        {
            ViewBag.AtletaId = new SelectList(db.Atletas, "AtletaId", "Nome");
            return View();
        }

        // POST: Uniformes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UniformeId,Descricao,Cor,Tamanho,AtletaId")] Uniforme uniforme)
        {
            if (ModelState.IsValid)
            {
                db.Uniformes.Add(uniforme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AtletaId = new SelectList(db.Atletas, "AtletaId", "Nome", uniforme.AtletaId);
            return View(uniforme);
        }

        // GET: Uniformes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uniforme uniforme = db.Uniformes.Find(id);
            if (uniforme == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtletaId = new SelectList(db.Atletas, "AtletaId", "Nome", uniforme.AtletaId);
            return View(uniforme);
        }

        // POST: Uniformes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniformeId,Descricao,Cor,Tamanho,AtletaId")] Uniforme uniforme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uniforme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtletaId = new SelectList(db.Atletas, "AtletaId", "Nome", uniforme.AtletaId);
            return View(uniforme);
        }

        // GET: Uniformes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uniforme uniforme = db.Uniformes.Find(id);
            if (uniforme == null)
            {
                return HttpNotFound();
            }
            return View(uniforme);
        }

        // POST: Uniformes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uniforme uniforme = db.Uniformes.Find(id);
            db.Uniformes.Remove(uniforme);
            db.SaveChanges();
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
