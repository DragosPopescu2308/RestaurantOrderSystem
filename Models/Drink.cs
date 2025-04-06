namespace RestaurantOrderSystem.Models
{
    public class Drink : IMenuItem
    {
        public string Name => "Cola";
        public double Price => 7.99;

        public string GetName() => Name;

        public double GetPrice() => Price;
    }
}