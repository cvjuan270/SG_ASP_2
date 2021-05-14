using SG_ASP_2.Models;
using System;
using System.Collections.Generic;
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
            viewModel.Admision = atenciones.Admisions.First();
            foreach (var item in atenciones.Interconsultas)
            {
                viewModel.Interconsultas.Add(item);
            }

            return View();
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