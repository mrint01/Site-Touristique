using App_Site_Touristique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_Site_Touristique.Controllers
{
    public class ActivityController : Controller
    {
        

        private ApplicationDbContext _db;
        public ActivityController()
        {
            _db = new ApplicationDbContext();

        }

       

        public ActionResult ActivityList()
        {

            var activities = _db.Activities.ToList();
            return View(activities);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }


        public ActionResult ActivityInfo()
        {
            return View(new Activity {Id =0 });
        }

        public ActionResult SaveActivity(Activity activity)

        {
            if (!ModelState.IsValid)
                return View("ActivityInfo", activity);
           
            if (activity.Id == 0)
            {
                _db.Activities.Add(activity);
            }
            else
            {
                var modelInDb = _db.Activities.FirstOrDefault(c => c.Id == activity.Id);
                if (modelInDb == null)

                    return HttpNotFound(); 

                modelInDb.Nom = activity.Nom;

                modelInDb.Genre = activity.Genre;
                modelInDb.prix = activity.prix;
                
            }

            _db.SaveChanges();


            return RedirectToAction("ActivityList");


        }

        public ActionResult EditActivity(int? id)


        {
            if (id == null)
                return HttpNotFound(); 
            var activity = _db.Activities.SingleOrDefault(c => c.Id == id);
            if (activity ==null) 
                return HttpNotFound();
            
            return View("ActivityInfo" , activity);
        }


        public ActionResult DeleteActivity(int id)
        {
            if (id == null)
                return HttpNotFound();
            var activity = _db.Activities.FirstOrDefault(e => e.Id == id);
            if (activity == null)
                return HttpNotFound();
            _db.Activities.Remove(activity);
            _db.SaveChanges();
            return RedirectToAction("ActivityList");

        }



        //public ActionResult DetailsActivity(int id)
        //{
        //    var activity = _db.Activities.SingleOrDefault(c => c.Id == id);
        //    return View(activity);
        //}









        //public ActionResult DeleteActivity(int id)
        //{
        //    if (id == null)
        //        return HttpNotFound();
        //    var activity = _db.Activities.FirstOrDefault(e => e.Id == id);
        //    if (activity == null)
        //        return HttpNotFound();
        //    _db.Activities.Remove(activity);
        //    _db.SaveChanges();
        //    return RedirectToAction(" ListActivity");

        //}




    }
}