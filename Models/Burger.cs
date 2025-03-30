namespace RestaurantOrderSystem.Models
{
    public class Burger : IMenuItem
    {
        public string Name => "Cheeseburger";
        public double Price => 18.99;
    }
}