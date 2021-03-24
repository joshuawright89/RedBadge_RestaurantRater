using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        //"First thing we need to do is access our stores Restaurants.  We can do this by adding a RestaurantDbContext instance to our class.  We'll be adding one to the class as a field so all future methods can reference the same one.  Above thhe Index method let's add this code:"
        private RestaurantDbContext _db = new RestaurantDbContext();


        // GET: Restaurant
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList()); //"Now that we have our DbContext brought in (above) we need to use it in the return statement.  Inside the View() method we'll pass in our Restaurants from the table in the _db field."
        }
        //"What's happening here?  We're reaching into theh _db field, calling the Restaurants property which is the Dbset we created, and then convering it to a List with the .ToList() method call.  That list is then passed into the View method which willl then pass it to the View as the Model."
    }
}