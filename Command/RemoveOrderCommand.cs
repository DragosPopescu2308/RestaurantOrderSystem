using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Command
{
    public class RemoveOrderCommand : ICommand
    {
        private Order _order;
        private IMenuItem _item;

        public RemoveOrderCommand(Order order, IMenuItem item)
        {
            _order = order;
            _item = item;
        }

        public void Execute() => _order.RemoveItem(_item); 
        public void Undo() => _order.AddItem(_item); 
    }
}
