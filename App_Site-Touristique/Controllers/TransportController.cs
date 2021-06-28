using App_Site_Touristique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_Site_Touristique.Controllers
{
    public class TransportController : Controller
    {

        private ApplicationDbContext _db;
        public TransportController()
        {
            _db = new ApplicationDbContext();

        }
        public ActionResult TransportList()
        {

            var transports = _db.Transports.ToList();
            return View(transports);

        }
        public ActionResult TransportInfo()
        {
            return View(new Transport { Id = 0 });
        }


        public ActionResult SaveTransport(Transport transport)

        {
            if (!ModelState.IsValid)
                return View("TransportInfo", transport);

            if (transport.Id == 0)
            {
                _db.Transports.Add(transport);
            }
            else
            {
                var modelInDb = _db.Transports.FirstOrDefault(c => c.Id == transport.Id);
                if (modelInDb == null)

                    return HttpNotFound();

                modelInDb.Nom = transport.Nom;

                modelInDb.Ligne = transport.Ligne;

            }

            _db.SaveChanges();


            return RedirectToAction("TransportList");


        }
 


        public ActionResult EditTransport (int? id )
        {
            if (id == null)
                return HttpNotFound();
            var transport = _db.Transports.FirstOrDefault(e => e.Id == id);
            if (transport == null)
                return HttpNotFound();
            return View("TransportInfo", transport); 
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }



        public ActionResult DeleteTransport(int? id)
        {
            if (id == null)
                return HttpNotFound();
            var transport = _db.Transports.FirstOrDefault(e => e.Id == id);
            if (transport == null)
                return HttpNotFound();
            _db.Transports.Remove(transport);
            _db.SaveChanges();
            return RedirectToAction("TransportList");

        }










        public ActionResult Index()
        {
            return View();
        }
    }
}