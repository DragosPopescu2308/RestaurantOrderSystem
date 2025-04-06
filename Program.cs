using System;
using RestaurantOrderSystem.Models;
using RestaurantOrderSystem.Factory;
using RestaurantOrderSystem.Command;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order();
        List<ICommand> commandHistory = new List<ICommand>(); // Listă pentru gestionarea comenzilor

        while (true)
        {
            Console.WriteLine("\n--- Meniu Restaurant ---");
            Console.WriteLine("1. Adauga produs în comanda");
            Console.WriteLine("2. Sterge produs din comanda");
            Console.WriteLine("3. Afiseaza comanda curenta");
            Console.WriteLine("4. Anuleaza ultima comanda");
            Console.WriteLine("5. Iesire");

            Console.Write("\nAlege o optiune: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nProduse disponibile: pizza, pasta, burger, salad, drink");
                    Console.Write("Introdu produsul dorit: ");
                    string productType = Console.ReadLine().ToLower();

                    try
                    {
                        IMenuItem item = MenuItemFactory.CreateItem(productType); // Se foloseste Factory pentru creare
                        ICommand command = new AddOrderCommand(order, item);
                        command.Execute();
                        commandHistory.Add(command);
                        Console.WriteLine($"{item.GetName()} a fost adaugat in comanda!"); // Foloseste GetName() pentru incapsularea numelui
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "2":
                    if (order.Items.Count == 0)
                    {
                        Console.WriteLine("Comanda este goala! Nu exista produse de sters.");
                        break;
                    }

                    Console.WriteLine("\nProdusele din comanda:");
                    for (int i = 0; i < order.Items.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {order.Items[i].GetName()} - {order.Items[i].GetPrice()} RON"); // Foloseste GetName() si GetPrice()
                    }

                    Console.Write("Introdu numarul produsului pe care vrei sa-l stergi: ");
                    if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= order.Items.Count)
                    {
                        IMenuItem itemToRemove = order.Items[index - 1];
                        ICommand removeCommand = new RemoveOrderCommand(order, itemToRemove);
                        removeCommand.Execute();
                        commandHistory.Add(removeCommand);
                        Console.WriteLine($"{itemToRemove.GetName()} a fost eliminat din comanda.");
                    }
                    else
                    {
                        Console.WriteLine("Numar invalid!");
                    }
                    break;

                case "3":
                    if (order.Items.Count == 0)
                    {
                        Console.WriteLine("Comanda este goala!");
                    }
                    else
                    {
                        Console.WriteLine("\nComanda curenta:");
                        foreach (var item in order.Items)
                        {
                            Console.WriteLine($"{item.GetName()} - {item.GetPrice()} RON"); // Foloseste GetName() si GetPrice()
                        }
                    }
                    break;

                case "4":
                    if (commandHistory.Count > 0)
                    {
                        ICommand lastCommand = commandHistory[^1]; // Ultima comanda adaugata
                        lastCommand.Undo();
                        commandHistory.RemoveAt(commandHistory.Count - 1);
                        Console.WriteLine("Ultima actiune a fost anulata.");
                    }
                    else
                    {
                        Console.WriteLine("Nu exista actiuni de anulat.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Iesire...");
                    return;

                default:
                    Console.WriteLine("Optiune invalida! Incearca din nou.");
                    break;
            }
        }
    }
}
