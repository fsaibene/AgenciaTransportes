using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCTransportes.Models;

namespace MVCTransportes.Controllers
{
    public class VehiculoController : Controller
    {
        private AgenciaContext db = new AgenciaContext();

        // GET: Vehiculo
        public ActionResult Index()
        {
            var vehiculos = db.Vehiculos.Include(v => v.Chofer);
            return View(vehiculos.ToList());
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            ViewBag.IdChofer = new SelectList(db.Choferes, "IdChofer", "Nombre");
            return View();
        }

        // POST: Vehiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVehiculo,IdChofer,Marca,Modelo,Matricula,Caracteristicas")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculos.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdChofer = new SelectList(db.Choferes, "IdChofer", "Nombre", vehiculo.IdChofer);
            return View(vehiculo);
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdChofer = new SelectList(db.Choferes, "IdChofer", "Nombre", vehiculo.IdChofer);
            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVehiculo,IdChofer,Marca,Modelo,Matricula,Caracteristicas")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdChofer = new SelectList(db.Choferes, "IdChofer", "Nombre", vehiculo.IdChofer);
            return View(vehiculo);
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            db.Vehiculos.Remove(vehiculo);
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
