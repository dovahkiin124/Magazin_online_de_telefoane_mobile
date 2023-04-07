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
            Console.WriteLine("__________________________________________");
            Console.WriteLine("|             MENIUL PRINCIPAL           |");
            Console.WriteLine("|________________________________________|");
            Console.WriteLine("|1_Afiseaza toate telefoanele            |");
            Console.WriteLine("|2_Afiseaza toate comenzile unui client  |");
            Console.WriteLine("|3_Adauga un telefon                     |");
            Console.WriteLine("|4_Plaseaza o comanda                    |");
            Console.WriteLine("|5_Adauga un client                      |");
            Console.WriteLine("|6_Sterge un client                      |");
            Console.WriteLine("|0_Iesire                                |");
            Console.WriteLine("|________________________________________|");
            Console.WriteLine("__________________");
            Console.WriteLine("|Introdu comanda:|");
            Console.WriteLine("------------------");
            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                

                case "1":
                    // Preia toate datele din fisierul telefoane.txt
                    List<Telefon> phones = shop.GetTelefoane();

                    // Vede daca sunt telefoane in magazin
                    if (phones.Count == 0)
                    {
                        Console.WriteLine("Nu exista telefoane in magazin.");
                    }
                    else
                    {
                        // Afiseaza fiecare telefon
                        foreach (Telefon phone in phones)
                        {
                            
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
                    // Gaseste clientul bazat pe adresa de email
                    Client customer = shop.Cauta_Client(email);

                    
                    break;
                case "3":

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

                    // Creaza un nou obiect telefon și il adauga în magazin
                    Telefon newPhone = new Telefon( brand, model, pret, descriere, stoc);
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
                    Console.WriteLine("Brand  | Model  | Pret  | Descriere  | Stoc");
                    foreach (Telefon phone in pTelefon)
                    {
                        Console.WriteLine($"{phone.Brandul}  | {phone.Model}  | {phone.Pret}  | {phone.Descriere}  | {phone.Stoc}");
                    }

                    // Prompt the user to enter the phone ID and quantity
                    Console.Write("Introduceti ID-ul telefonului: ");
                    string phoneBrand = Console.ReadLine();
                    Console.Write("Introduceti cantitatea: ");
                    int quantity = int.Parse(Console.ReadLine());

                    // Check if the requested phone is available
                    Telefon selectedPhone = pTelefon.FirstOrDefault(p => p.Brandul == phoneBrand);
                    if (selectedPhone == null)
                    {
                        Console.WriteLine($"Nu s-a gasit niciun telefon cu Brandul {phoneBrand}.");
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
