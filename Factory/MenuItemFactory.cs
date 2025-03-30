
using RestaurantOrderSystem.Models;
using System;

namespace RestaurantOrderSystem.Factory
{
    public class MenuItemFactory
    {
        public static IMenuItem CreateItem(string type)
        {
            return type.ToLower() switch
            {
                "pizza" => new Pizza(),
                "pasta" => new Pasta(),
                "burger" => new Burger(),
                "salad" => new Salad(),
                "drink" => new Drink(),
                _ => throw new ArgumentException("Produs indisponibil!")
            };
        }
    }
}
