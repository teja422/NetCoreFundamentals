using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data.Interfaces
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int restaurantId);
        Restaurant AddNewRestaurant(Restaurant newRestaurant);
        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);
        int Commit();
    }
}
