using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Command
{
    public class AddOrderCommand : ICommand
    {
        private Order _order;
        private IMenuItem _item;

        public AddOrderCommand(Order order, IMenuItem item)
        {
            _order = order;
            _item = item;
        }

        public void Execute() => _order.AddItem(_item);
        public void Undo() => _order.RemoveItem(_item);
    }
}
