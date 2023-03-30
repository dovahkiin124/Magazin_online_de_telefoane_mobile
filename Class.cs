using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

public class Telefon
{
    
    public string Brandul { get; set; }
    public string Model { get; set; }
    public decimal Pret { get; set; }
    public string Descriere { get; set; }
    public int Stoc { get; set; }

    public Telefon( string brand, string model, decimal pret, string descriere, int stoc)//constructor al clasei telefon
    {
        
        Brandul = brand;
        Model = model;
        Pret = pret;
        Descriere = descriere;
        Stoc = stoc;
    }
}

public class comandaprodus
{
    public Telefon Phone { get; set; }
    public int Cantitate { get; set; }

    public comandaprodus(Telefon phone, int quantity)
    {
        Phone = phone;
        Cantitate = quantity;
    }
}

public class Comanda
{
    private static int comandaId = 1;
    public int Id { get; set; }
    public List<comandaprodus> Produse { get; set; }
   
    public string Adresa{ get; set; }
    public DateTime Data_comenzii { get; set; }
    public bool Livrata { get; set; }

    public Comanda(List<comandaprodus> produse, string adresa)
    {
        Id = comandaId++;
        Produse = produse;
        Adresa = adresa;
        Data_comenzii = DateTime.Now;
        Livrata = false;
    }
}

public class Client
{
    private static int ClientId = 1;
    public int Id { get; set; }
    public string Nume { get; set; }
    public string Email { get; set; }
    public string Adresa { get; set; }
    public List<Comanda> Comenzi { get; set; }

    public Client(string nume, string email, string adresa)
    {
        Id = ClientId++;
        Nume = nume;
        Email = email;
        Adresa = adresa;
        Comenzi = new List<Comanda>();
    }
}

public class MagazinulDeTelefoaneMobile
{
    private List<Telefon> telefoane = new List<Telefon>();
    private List<Client> clienti = new List<Client>();
    private List<Comanda> comenzi = new List<Comanda>();

    public void Adauga_Telefon(Telefon telefon)
    {
        telefoane.Add(telefon);

        // Deschide fișierul în modul append
        using (StreamWriter file = new StreamWriter("C:/Users/Asus/Desktop/telefoane.txt", true))
        {
            // Scrie datele telefonului in fisier
            file.WriteLine($" {telefon.Brandul}, {telefon.Model}, {telefon.Pret}, {telefon.Descriere}, {telefon.Stoc}");
        }
    }

   

    public void Adauga_Client(Client client)
    {
        clienti.Add(client);

        // Deschide fișierul în modul append
        using (StreamWriter file = new StreamWriter("C:/Users/Asus/Desktop/clienti.txt"))
        {
            // Scrie datele clientului in fisier
            file.WriteLine($"{client.Nume}, {client.Email}, {client.Adresa}, {client.Comenzi}");
        }

        Console.WriteLine("Client adaugat cu succes!");
    }

   
    public Client Cauta_Client(string email)
    {
        using (StreamReader sr = new StreamReader(@"C:/Users/Asus/Desktop/clienti.txt"))
        {
            //citeste din fisier pana la sfarsit
            while (!sr.EndOfStream)
            {
                //citeste prima linie
                string line = sr.ReadLine();
                // ','este luat ca un despartitor
                string[] fields = line.Split(',');
                //preia datele in functie de pozitia lor in fisier luand in calcul si despartitorul 
                string nume = fields[0].Trim();
                string emailFile = fields[1].Trim();
                string adresa = fields[2].Trim();

                if (emailFile == email)
                {
                    Console.WriteLine($"Clientul {nume} are urmatoarele comenzi:");

                    foreach (var comanda in comenzi)
                    {
                        Console.WriteLine($"ID-ul comenzii: {comanda.Id}, \nData comenzii: {comanda.Data_comenzii}, \nAdresa: {comanda.Adresa}");
                    }

                    return new Client(nume, email, adresa);
                }
            }
        }

        Console.WriteLine($"\nNu s-a gasit niciun client cu adresa de email {email}.");
        return null;
    }





    public void Sterge_Client(Client Sterge)
    {
        
        Client client = Cauta_Client(Sterge.Email);
        if (client != null)
        {
            clienti.Remove(client);

            // Serializeaza lista actualizată de clienți într-un fișier
            string json = JsonConvert.SerializeObject(clienti, Formatting.Indented);
            File.WriteAllText("clienti.json", json);

            Console.WriteLine($"Clientul cu adresa de email {Sterge.Email} a fost sters cu succes.");
        }
        else
        {
            Console.WriteLine($"Nu s-a gasit niciun client cu adresa de email {Sterge.Email}.");
        }
    }




    public List<Telefon> GetTelefoane()
    {
        List<Telefon> telefoane = new List<Telefon>();

        using (StreamReader sr = new StreamReader(@"C:/Users/Asus/Desktop/telefoane.txt"))
        {
            //citeste din fisier pana la sfarsit
            while (!sr.EndOfStream)
            {
                //citeste prima linie
                string line = sr.ReadLine();
                // ','este luat ca un despartitor
                string[] fields = line.Split(',');
                //preia datele in functie de pozitia lor in fisier luand in calcul si despartitorul 
                
                string brand = fields[0].Trim();
                string model = fields[1].Trim();
                decimal pret = decimal.Parse(fields[2].Trim());
                string descriere = fields[3].Trim();
                int stoc = int.Parse(fields[4].Trim());

                Telefon telefon = new Telefon( brand, model, pret, descriere, stoc);
                telefoane.Add(telefon);
            }
        }

        return telefoane;
    }

   

    public List<Client> GetClienti()
    {
        return clienti;
    }

    public List<Comanda> GetComenzi()
    {
        return comenzi;
    }
  
}
