using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        MagazinulDeTelefoaneMobile shop = new MagazinulDeTelefoaneMobile();

        // Adding phones to the shop
        Telefon phone1 = new Telefon(1, "Apple", "iPhone 12", 799.99m, "The iPhone 12 features a 6.1-inch Super Retina XDR display and A14 Bionic chip.", 10);
        Telefon phone2 = new Telefon(2, "Samsung", "Galaxy S21", 699.99m, "The Galaxy S21 features a 6.2-inch Dynamic AMOLED 2X display and Exynos 2100 chip.", 8);
        Telefon phone3 = new Telefon(3, "Google", "Pixel 5", 699.99m, "The Pixel 5 features a 6-inch OLED display and Snapdragon 765G chip.", 5);
        shop.Adauga_Telefon(phone1);
        shop.Adauga_Telefon(phone2);
        shop.Adauga_Telefon(phone3);

        // Adding customers to the shop
        Client customer1 = new Client("John Smith", "john.smith@example.com", "123 Main St, Anytown USA");
        Client customer2 = new Client("Jane Doe", "jane.doe@example.com", "456 Oak Ave, Anytown USA");
        shop.Adauga_Client(customer1);
        shop.Adauga_Client(customer2);

        // Placing an order
        comandaprodus orderItem1 = new comandaprodus(phone1, 2);
        comandaprodus orderItem2 = new comandaprodus(phone2, 1);
        Comanda order = new Comanda(new List<comandaprodus> { orderItem1, orderItem2 }, "789 Elm St, Anytown USA");
        shop.PlaceOrder(customer1, order);

        // Displaying order details
        Console.WriteLine($"ID-ul comenzii: {order.Id}");
        Console.WriteLine($"Data comenzii: {order.Data_comenzii}");
        Console.WriteLine($"Adresa comenzii: {order.Adresa}");
        Console.WriteLine("Produse comandate:");
        foreach (var item in order.Produse)
        {
            Console.WriteLine($"{item.Phone.Brandul} {item.Phone.Model} x {item.Cantitate} - ${item.Phone.Pret}");
        }
        Console.WriteLine($"Pret Total: ${order.prettotal}");
        Console.WriteLine($"Comanda Livrata: {order.Livrata}");

        // Displaying customer order history
        Console.WriteLine("Comenzi anterioare ale clientului:");
        foreach (var customerOrder in customer1.Comenzi)
        {
            Console.WriteLine($"ID-ul comenzii: {customerOrder.Id}, Data comenzii: {customerOrder.Data_comenzii}, Pret Total: ${customerOrder.Adresa}");
        }
    }
}
