using MVCTransportes.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace MVCTransportes.Controllers
{
    public class ChoferController : Controller
    {
        private AgenciaContext context = new AgenciaContext();

        // GET: Chofer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            return View(this.context.Choferes);
        }

        public ActionResult Carga()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Carga([Bind(Include = "Nombre, Apellido, DNI, Email, Celular, NroRegistro, Ciudad ")] Chofer Chofer)
        {
            if (ModelState.IsValid)
            {
                context.Choferes.Add(Chofer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Chofer);
        }

        [HttpPost]
        public ActionResult Edicion([Bind(Include = "IdChofer,Marca,Modelo,Chofer,Matricula,Caracteristicas ")] Chofer Chofer)
        {
            if (ModelState.IsValid)
            {
                context.Entry(Chofer).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Chofer);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Chofer opera = context.Choferes.Find(id);
            context.Choferes.Remove(opera);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}