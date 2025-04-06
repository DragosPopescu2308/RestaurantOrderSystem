namespace RestaurantOrderSystem.Models
{
    public class Pasta : IMenuItem
    {
        public string Name => "Pasta Carbonara";
        public double Price => 22.50;

        public string GetName() => Name;

        public double GetPrice() => Price;
    }
}
