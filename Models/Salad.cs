namespace RestaurantOrderSystem.Models
{
    public class Salad : IMenuItem
    {
        public string Name => "Caesar Salad";
        public double Price => 15.50;

        public string GetName() => Name;

        public double GetPrice() => Price;
    }
}