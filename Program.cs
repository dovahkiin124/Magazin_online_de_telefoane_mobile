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
        while (true)
        {
            Console.WriteLine("1. Afiseaza toate telefoanele");
            Console.WriteLine("2. Afiseaza toate comenzile unui client");
            Console.WriteLine("3. Adauga un telefon");
            Console.WriteLine("4. Plaseaza o comanda");
            Console.WriteLine("5. Adauga un client");
            Console.WriteLine("6. Sterge un client");
            Console.WriteLine("0. Iesire");

            Console.WriteLine("Introdu comanda:");
            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                

                case "1":
                    // Get all phones from the shop
                    List<Telefon> phones = shop.GetTelefoane();

                    // Check if there are any phones in the shop
                    if (phones.Count == 0)
                    {
                        Console.WriteLine("Nu exista telefoane in magazin.");
                    }
                    else
                    {
                        // Display each phone
                        foreach (Telefon phone in phones)
                        {
                            Console.WriteLine($"ID: {phone.Id}");
                            Console.WriteLine($"Brand: {phone.Brandul}");
                            Console.WriteLine($"Model: {phone.Model}");
                            Console.WriteLine($"Pret: {phone.Pret}");
                            Console.WriteLine($"Descriere: {phone.Descriere}");
                            Console.WriteLine($"Stoc: {phone.Stoc}");
                            Console.WriteLine();
                        }
                    }
                    break;

                case "2":
                    Console.Write("Introduceti adresa de email a clientului: ");
                    string email = Console.ReadLine();
                    // Find the customer based on the entered email
                    Client customer = shop.Cauta_Client(email);

                    if (customer != null)
                    {
                        Console.WriteLine($"Comenzi ale clientului {customer.Nume}:");
                        foreach (var customerOrder in customer.Comenzi)
                        {
                            Console.WriteLine($"ID-ul comenzii: {customerOrder.Id}, \nData comenzii: {customerOrder.Data_comenzii}, \nPret Total: ${customerOrder.prettotal}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Nu exista client cu adresa de email {email}");
                    }
                    break;
                case "3":
                    Console.Write("Introduceti ID-ul telefonului: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Introduceti brandul telefonului: ");
                    string brand = Console.ReadLine();

                    Console.Write("Introduceti modelul telefonului: ");
                    string model = Console.ReadLine();

                    Console.Write("Introduceti pretul telefonului: ");
                    decimal pret = decimal.Parse(Console.ReadLine());

                    Console.Write("Introduceti descrierea telefonului: ");
                    string descriere = Console.ReadLine();

                    Console.Write("Introduceti stocul initial al telefonului: ");
                    int stoc = int.Parse(Console.ReadLine());

                    // Create a new phone object and add it to the shop
                    Telefon newPhone = new Telefon(id, brand, model, pret, descriere, stoc);
                    shop.Adauga_Telefon(newPhone);

                    Console.WriteLine($"Telefonul {newPhone.Brandul} {newPhone.Model} a fost adaugat cu succes.");
                    break;
                case "4":
                    // TODO: Implement code to place an order
                    break;
                case "5":
                    // Add a new client to the shop
                    Console.WriteLine("Introduceti numele clientului:");
                    string nume = Console.ReadLine();

                    Console.WriteLine("Introduceti adresa de email a clientului:");
                    string mailAdress = Console.ReadLine();

                    Console.WriteLine("Introduceti adresa de livrare a clientului:");
                    string adresa = Console.ReadLine();

                    Client newClient = new Client(nume, mailAdress, adresa);
                    shop.Adauga_Client(newClient);

                    Console.WriteLine("Client adaugat cu succes!");
                    break;
                case "6":
                    // Sterge un client
                    Console.Write("Introduceti adresa de email a clientului de sters: ");
                    string emailStergere = Console.ReadLine();
                    Client clientSters = shop.Cauta_Client(emailStergere);
                    if (clientSters != null)
                    {
                        shop.Sterge_Client(clientSters);
                        Console.WriteLine($"Clientul {clientSters.Nume} a fost sters cu succes.");
                    }
                    else
                    {
                        Console.WriteLine($"Nu s-a gasit niciun client cu adresa de email {emailStergere}.");
                    }
                    break;
                   
                case "0":
                    Console.WriteLine("La revedere!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Optiune invalida.");
                    break;
            }
        }



    }

}
