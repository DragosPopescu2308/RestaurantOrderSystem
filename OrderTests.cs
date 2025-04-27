using Xunit;
using RestaurantOrderSystem.Models;
using RestaurantOrderSystem.Factory;
using RestaurantOrderSystem.Command;
using System;

public class OrderTests
{
     [Theory]
 [InlineData("pizza")]
 [InlineData("pasta")]
 [InlineData("burger")]
 [InlineData("drink")]
 [InlineData("salad")]
 public void Test_AddItemToOrder(string productType)
 {
     // Arrange
     Order order = new Order();
     IMenuItem item = MenuItemFactory.CreateItem(productType);
     ICommand addCommand = new AddOrderCommand(order, item);

     // Act
     addCommand.Execute();

     // Assert
     Assert.Contains(item, order.Items);
 }


 [Theory]
 [InlineData("pizza")]
 [InlineData("pasta")]
 [InlineData("burger")]
 [InlineData("drink")]
 [InlineData("salad")]
 public void Test_RemoveItemFromOrder(string productType)
 {
     // Arrange
     Order order = new Order();
     IMenuItem item = MenuItemFactory.CreateItem(productType);
     ICommand addCommand = new AddOrderCommand(order, item);
     addCommand.Execute(); // Adăugăm mai întâi produsul în comandă

     ICommand removeCommand = new RemoveOrderCommand(order, item);

     // Act
     removeCommand.Execute();

     // Assert
     Assert.DoesNotContain(item, order.Items);
 }

    [Theory]
    [InlineData("pizza")]
    [InlineData("pasta")]
    [InlineData("burger")]
    [InlineData("drink")]
    [InlineData("salad")]
    public void Test_UndoLastCommand(string productType)
    {
        // Arrange
        Order order = new Order();
        IMenuItem item = MenuItemFactory.CreateItem(productType);
        ICommand command = new AddOrderCommand(order, item);

        // Act
        command.Execute();

        // Assert
        Assert.Contains(item, order.Items);

        // Act
        command.Undo();

        // Assert
        Assert.DoesNotContain(item, order.Items);
    }

    [Fact]
    public void Test_AddAndRemoveMultipleItems()
    {
        // Arrange
        Order order = new Order();
        IMenuItem pizza = MenuItemFactory.CreateItem("pizza");
        IMenuItem pasta = MenuItemFactory.CreateItem("pasta");
        IMenuItem burger = MenuItemFactory.CreateItem("burger");
        IMenuItem drink = MenuItemFactory.CreateItem("drink");
        IMenuItem salad = MenuItemFactory.CreateItem("salad");

        // Act
        order.AddItem(pizza);
        order.AddItem(pasta);
        order.AddItem(burger);
        order.AddItem(drink);
        order.AddItem(salad);

        // Assert
        Assert.Contains(pizza, order.Items);
        Assert.Contains(pasta, order.Items);
        Assert.Contains(burger, order.Items);
        Assert.Contains(drink, order.Items);
        Assert.Contains(salad, order.Items);

        // Act
        order.RemoveItem(pizza);
        order.RemoveItem(pasta);
        order.RemoveItem(burger);
        order.RemoveItem(drink);
        order.RemoveItem(salad);

        // Assert
        Assert.Empty(order.Items);
    }

    [Fact]
    public void Test_AddInvalidProduct()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => MenuItemFactory.CreateItem("unknownProduct"));
        Assert.Equal("Produs indisponibil!", exception.Message);
    }
}
