using MVCTransportes.Models;
using System.Data.Entity;
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

        [HttpPost]
        public ActionResult Carga([Bind(Include = "IdVehiculo,Marca,Modelo,Chofer,Matricula,Caracteristicas ")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                context.Vehiculos.Add(vehiculo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehiculo);
        }

        [HttpPost]
        public ActionResult Edicion([Bind(Include = "IdVehiculo,Marca,Modelo,Chofer,Matricula,Caracteristicas ")] Vehiculo vehiculo)
        {    
            if (ModelState.IsValid)
            {
                context.Entry(vehiculo).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehiculo);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Vehiculo opera = context.Vehiculos.Find(id);
            context.Vehiculos.Remove(opera);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}