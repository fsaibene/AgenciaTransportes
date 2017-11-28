using MVCTransportes.Models;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace MVCTransportes.Controllers
{
    public class VehiculoController : Controller
    {
        private AgenciaContext context = new AgenciaContext();

        // GET: Vehiculo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.IdChofer = new SelectList(context.Choferes, "IdChofer", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVehiculo,IdChofer,Marca,Modelo,Matricula,Caracteristicas")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                context.Vehiculos.Add(vehiculo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdChofer = new SelectList(context.Choferes, "IdChofer", "Nombre", vehiculo.IdChofer);
            return View(vehiculo);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = context.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "IdVehiculo,Marca,Modelo,Chofer,Matricula,Caracteristicas ")] Vehiculo vehiculo)
        {    
            if (ModelState.IsValid)
            {
                context.Entry(vehiculo).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehiculo);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = context.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Vehiculo vehiculo = context.Vehiculos.Find(id);
            context.Vehiculos.Remove(vehiculo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}