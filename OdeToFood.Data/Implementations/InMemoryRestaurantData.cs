using OdeToFood.Core;
using OdeToFood.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data.Implementations
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant{Id=1, Name="Paradise", Location="Chennai", Cuisine=CuisineType.Indian},
                new Restaurant{Id=2, Name="Sumesh", Location="Paris", Cuisine=CuisineType.Italian},
                new Restaurant{Id=3, Name="Jiiva", Location="Chennai", Cuisine=CuisineType.Mexican},
                new Restaurant{Id=4, Name="John Peter", Location="Chennai", Cuisine=CuisineType.None}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            var list = from restaurant in restaurants
                   orderby restaurant.Id
                   select restaurant;
            
            return list;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            var list = from restaurant in restaurants
                       where string.IsNullOrEmpty(name) || restaurant.Name.StartsWith(name)
                       orderby restaurant.Name
                       select restaurant;


                      return list;
        }
    }
}
