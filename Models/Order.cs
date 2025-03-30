using System.Collections.Generic;

namespace RestaurantOrderSystem.Models
{
    public class Order
    {
        public List<IMenuItem> Items { get; } = new List<IMenuItem>();

        public void AddItem(IMenuItem item) => Items.Add(item);
        public void RemoveItem(IMenuItem item) => Items.Remove(item);
    }
}
