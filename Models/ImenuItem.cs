namespace RestaurantOrderSystem.Models
{
    public interface IMenuItem
    {
        string Name { get; }
        double Price { get; }
        string GetName();
        double GetPrice();
    }
}
