namespace RestaurantOrderSystem.Models
{
    public class Burger : IMenuItem
    {
        public string Name => "Cheeseburger";
        public double Price => 18.99;

        public string GetName() => Name;

        public double GetPrice() => Price;
    }
}