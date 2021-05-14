using SG_ASP_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SG_ASP_2.Controllers
{
    public class AdmisionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admision
        public ActionResult Create(int Id)
        {
            Atenciones atenciones = db.Atenciones.Find(Id);
            AdmisionViewModel viewModel = new AdmisionViewModel();

            ViewBag.DocIde = atenciones.DocIde;
            ViewBag.NomApe = atenciones.NomApe;
            ViewBag.Empres = atenciones.Empres;

            if (atenciones.Admisions.Count!=0)
            {
                viewModel.Admision = atenciones.Admisions.First();
            }
            else
            {
                viewModel.Admision.IdAtenciones = Id;
            }

            if (atenciones.Interconsultas.Count!=0)
            {
                foreach (var item in atenciones.Interconsultas)
                {
                    viewModel.Interconsultas.Add(item);
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Enfermeria,Admin")]
        public ActionResult Create(AdmisionViewModel viewModel) 
        {
            if (ModelState.IsValid)
            {
                var atencion = db.Atenciones.Find(viewModel.Admision.IdAtenciones);
                var admision = viewModel.Admision;
                admision.UserName = HttpContext.User.Identity.Name;
                if (atencion.Admisions.Count==0)
                {
                    db.Admisions.Add(admision);
                    db.SaveChanges();
                }
                else
                {
                    atencion.Admisions.Clear();
                    atencion.Admisions.Add(admision);
                    db.Entry(atencion).State = EntityState.Modified;
                    db.SaveChanges();
                }

                if (viewModel.Interconsultas.Count != 0)
                {
                    foreach (var item in viewModel.Interconsultas)
                    {
                        item.UserName = HttpContext.User.Identity.Name;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    
                }


                return RedirectToAction("Index", "Atenciones");
            }

            return View(viewModel);
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