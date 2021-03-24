using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }

    }

    public class RestaurantDbContext : DbContext 
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        //"Cool, but what does that mean? Well this DbSet is going to act as a way to reference all entities of a given type. In this case we see we're setting the type as Restaurant inside the angle brackets. So Restaurants (the name of the property) will act as a way to access all Restaurant objects that we set in our database. And what are Entities? An Entity is the term used to describe models or objects that are being stored into the database. We can have other classes that define objects that are not Entities."
    }
}