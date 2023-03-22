using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

public class Telefon
{
    public int Id { get; set; }
    public string Brandul { get; set; }
    public string Model { get; set; }
    public decimal Pret { get; set; }
    public string Descriere { get; set; }
    public int Stoc { get; set; }

    public Telefon(int id, string brand, string model, decimal pret, string descriere, int stoc)//constructor al clasei telefon
    {
        Id = id;
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
    public decimal prettotal
    {
        get
        {
            return Produse.Sum(item => item.Phone.Pret * item.Cantitate);
        }
    }
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

        // Open the file in append mode
        using (StreamWriter file = new StreamWriter("telefoane.txt", true))
        {
            // Write the phone data to the file
            file.WriteLine($"{telefon.Id}, {telefon.Brandul}, {telefon.Model}, {telefon.Pret}, {telefon.Descriere}, {telefon.Stoc}");
        }
    }


    public void Adauga_Client(Client client)
    {
        clienti.Add(client);

        // Serialize the list of clients to a file
        using (StreamWriter file = new StreamWriter("clienti.txt"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, clienti);
        }

        Console.WriteLine("Client adaugat cu succes!");
    }

    public void PlaceOrder(Client client, Comanda comanda)
    {
        if (!clienti.Contains(client))
        {
            clienti.Add(client);
        }
        client.Comenzi.Add(comanda);
        comenzi.Add(comanda);
        foreach (var produs in comanda.Produse)
        {
            produs.Phone.Stoc -= produs.Cantitate;
        }
    }
    public Client Cauta_Client(string email)
    {
        foreach (var client in clienti)
        {
            if (client.Email == email)
            {
                Console.WriteLine($"Clientul {client.Nume} are urmatoarele comenzi:");

                foreach (var comanda in client.Comenzi)
                {
                    Console.WriteLine($"ID-ul comenzii: {comanda.Id}, \nData comenzii: {comanda.Data_comenzii}, \nAdresa: {comanda.Adresa}");
                }

                return client;
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

            // Serialize the updated list of clients to a file
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
