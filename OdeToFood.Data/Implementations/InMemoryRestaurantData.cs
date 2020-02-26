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

        public Restaurant GetRestaurantById(int restaurantId)
        {
            return restaurants.SingleOrDefault(r => r.Id == restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            var list = from restaurant in restaurants
                       where string.IsNullOrEmpty(name) || restaurant.Name.StartsWith(name)
                       orderby restaurant.Name
                       select restaurant;


                      return list;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant AddNewRestaurant(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;

            return newRestaurant;
        }
    }
}
