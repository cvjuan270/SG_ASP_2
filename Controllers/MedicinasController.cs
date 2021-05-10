using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SG_ASP_2.Models;

namespace SG_ASP_2.Controllers
{
    public class MedicinasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medicinas
        public ActionResult Index()
        {
            return View(db.Medicinas.ToList());
        }

        // GET: Medicinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return HttpNotFound();
            }
            return View(medicina);
        }

        // GET: Medicinas/Create
        public ActionResult Create(int Id)
        {
            var medicina = new Medicina();

            medicina.HorIng = TimeSpan.Parse(DateTime.Now.ToLongTimeString());
            medicina.HorSal = TimeSpan.Parse(DateTime.Now.ToLongTimeString());

            ViewBag.Atencion_Id = Id;
            ViewBag.Medico = new SelectList(db.Medicos, "Id", "NomApe");
            var LisApt = new List<SelectListItem>();
            LisApt.Add(new SelectListItem() { Text = "Apto", Value = "Apto" });
            LisApt.Add(new SelectListItem() { Text = "Apto con restricciones", Value = "Apto con restricciones" });
            LisApt.Add(new SelectListItem() { Text = "No apto", Value = "No apto" });
            ViewBag.Aptitu = LisApt;

            return View(medicina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AtenId,HorIng,HorSal,Medico,Aptitu,FecApt,FecEnv,Coment,Observ,UserName")] Medicina medicina,int Atencion_Id)
        {
            if (ModelState.IsValid)
            {
                var atencion = db.Atenciones.Find(Atencion_Id);
                atencion.Medicina.Add(medicina);
                db.Entry(atencion).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index","Atenciones");
            }

            return View(medicina);
        }

        // GET: Medicinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return HttpNotFound();
            }
            return View(medicina);
        }

        // POST: Medicinas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AtenId,HorIng,HorSal,Medico,Aptitu,FecApt,FecEnv,Coment,Observ,UserName")] Medicina medicina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicina);
        }

        // GET: Medicinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return HttpNotFound();
            }
            return View(medicina);
        }

        // POST: Medicinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicina medicina = db.Medicinas.Find(id);
            db.Medicinas.Remove(medicina);
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
