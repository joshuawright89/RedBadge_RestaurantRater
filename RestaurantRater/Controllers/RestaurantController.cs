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

        // GET: Restaurant/Create
        // Without this method, there is no way to display the Create view.  This method allows us to return the specific view we want.
        public ActionResult Create()
        {
            return View();
        }

        //"16. Now we have an input field for a restaurant.  Go ahead and enter a name and hit enter.  Nothing will happen.  We need to make it so that we can enter a Name(according to our User Model), hit enter and be redirected back to our index. 17.  To do this, we're going to need to add a POST method to our Restaurant controller.  This will be the method that allows us to handle the incoming request from our view and send it to the DB."
        //See Create lesson page for a breakdown of this next method line by line:
        //POST: Restaurant/Create
        [HttpPost] //specifies that the method is a POST
        [ValidateAntiForgeryToken] //"annotation that allows the server to match up with the AntiForgeryToken that we have set in the Create form."
        public ActionResult Create(Restaurant restaurant) //Like our previous create method, except this one takes in a Restaurant item as a parameter.  That restaurant item "is the model that the view is going to give the controller once POST is called."
        {
            if (ModelState.IsValid)
            { //Inside the if statement we see the _db field called, and the Restaurants property accessed.  From there the .Add() method is called where we are adding the restaurant parameter to the Restaurants table."
                _db.Restaurants.Add(restaurant); //adds restaurant item to _db
                _db.SaveChanges(); //"...we call the _db.SaveChanges() method, which takes our modified snapshot and saves those changes to the actuall SQL database.  SaveChanges() also returns an int with the count of how many rows were modified.  We are not using this right now but it would be good to know for the future."
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }


    }
}