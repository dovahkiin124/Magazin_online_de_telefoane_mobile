using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        MagazinulDeTelefoaneMobile shop = new MagazinulDeTelefoaneMobile();
    
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
                    Console.Write("Introduceti adresa de email a clientului: ");
                    string customerEmail = Console.ReadLine();

                    // Search for the customer
                    Client client = shop.Cauta_Client(customerEmail);
                    if (client == null)
                    {
                        Console.WriteLine($"Nu s-a gasit niciun client cu adresa de email {customerEmail}.");
                        break;
                    }

                    // Display the available phones
                    List<Telefon> pTelefon = shop.GetTelefoane();
                    Console.WriteLine("ID  | Brand  | Model  | Pret  | Descriere  | Stoc");
                    foreach (Telefon phone in pTelefon)
                    {
                        Console.WriteLine($"{phone.Id}  | {phone.Brandul}  | {phone.Model}  | {phone.Pret}  | {phone.Descriere}  | {phone.Stoc}");
                    }

                    // Prompt the user to enter the phone ID and quantity
                    Console.Write("Introduceti ID-ul telefonului: ");
                    int phoneId = int.Parse(Console.ReadLine());
                    Console.Write("Introduceti cantitatea: ");
                    int quantity = int.Parse(Console.ReadLine());

                    // Check if the requested phone is available
                    Telefon selectedPhone = pTelefon.FirstOrDefault(p => p.Id == phoneId);
                    if (selectedPhone == null)
                    {
                        Console.WriteLine($"Nu s-a gasit niciun telefon cu ID-ul {phoneId}.");
                        break;
                    }
                    if (selectedPhone.Stoc < quantity)
                    {
                        Console.WriteLine($"Cantitatea solicitata nu este disponibila. Stoc curent: {selectedPhone.Stoc}.");
                        break;
                    }

                    // Reduce the stock of the phone
                    selectedPhone.Stoc -= quantity; 

                    // Save the order in a text file
                    string filePath = @"C:\Users\Asus\Desktop\clienti.txt";
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine($"Comanda pentru {customerEmail}: {quantity} x {selectedPhone.Brandul} {selectedPhone.Model} la pretul de {selectedPhone.Pret} lei.");
                    }

                    Console.WriteLine($"Comanda a fost plasata cu succes pentru {quantity} x {selectedPhone.Brandul} {selectedPhone.Model} la pretul de {selectedPhone.Pret} lei.");
                    break;



                case "5":
                    // Adauga un nou client
                    Console.WriteLine("Introduceti numele clientului:");
                    string nume = Console.ReadLine();

                    Console.WriteLine("Introduceti adresa de email a clientului:");
                    string mailAdress = Console.ReadLine();

                    Console.WriteLine("Introduceti adresa de livrare a clientului:");
                    string adresa = Console.ReadLine();

                    Client newClient = new Client(nume, mailAdress, adresa);
                    shop.Adauga_Client(newClient);
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
