using App_Site_Touristique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App_Site_Touristique.Controllers
{
    public class RestaurantController : Controller
    {


        private ApplicationDbContext _db;
        public RestaurantController()
        {
            _db = new ApplicationDbContext();

        }


        public ActionResult RestaurantList()
        {

            var restaurants = _db.Restaurants.ToList();
            return View(restaurants);

        }
        public ActionResult RestaurantInfo()
        {
            return View(new Restaurant { Id = 0 });
        }

        public ActionResult SaveRestaurant(Restaurant restaurant)

        {
            if (!ModelState.IsValid)
                return View("RestaurantInfo", restaurant);

            if (restaurant.Id == 0)
            {
                _db.Restaurants.Add(restaurant);
            }
            else
            {
                var modelInDb = _db.Restaurants.FirstOrDefault(c => c.Id == restaurant.Id);
                if (modelInDb == null)

                    return HttpNotFound();

                modelInDb.Nom = restaurant.Nom;

                modelInDb.NumTel = restaurant.NumTel; 

                modelInDb.leType = restaurant.leType;

            }

            _db.SaveChanges();


            return RedirectToAction("RestaurantList");


        }




        public ActionResult EditRestaurant(int? id)
        {
            if (id == null)
                return HttpNotFound();
            var restaurant = _db.Restaurants.FirstOrDefault(e => e.Id == id);
            if (restaurant == null)
                return HttpNotFound();
            return View("RestaurantInfo", restaurant);
        }

        public ActionResult DeleteRestaurant(int? id)
        {
            if (id == null)
                return HttpNotFound();
            var restaurant = _db.Restaurants.FirstOrDefault(e => e.Id == id);
            if (restaurant == null)
                return HttpNotFound();
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("RestaurantList");

        }





        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }



        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }
    }
}