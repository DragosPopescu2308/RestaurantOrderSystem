using System.Xml.Linq;

namespace RestaurantOrderSystem.Models
{
    public class Pizza : IMenuItem
    {
        public string Name => "Pizza Margherita";
        public double Price => 25.99;

        public string GetName() => Name;

        public double GetPrice() => Price;
    }
}
