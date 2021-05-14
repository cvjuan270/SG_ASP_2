using SG_ASP_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SG_ASP_2.Controllers
{
    public class EnfermeriaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Enfermeria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int Id)
        {
            var atenciones = db.Atenciones.Find(Id);
            EnfermeriaViewModel viewModel = new EnfermeriaViewModel();

            ViewBag.DocIde = atenciones.DocIde;
            ViewBag.NomApe = atenciones.NomApe;
            ViewBag.Empres = atenciones.Empres;
            if (atenciones.Interconsultas.Count==0)
            {
                return HttpNotFound("No se Crearon interconsultas");
            }
            else
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
        public ActionResult Create(EnfermeriaViewModel enf)
        {
            if (enf.Interconsultas != null)
            {
                foreach (var item in enf.Interconsultas)
                {
                    item.UserName = HttpContext.User.Identity.Name;
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Atenciones");
            }
            else
            {
                return View(enf);
            }
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