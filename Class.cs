using System.Collections.Generic;
using System;
using System.Linq;

public class Telefon
{
    public int Id { get; set; }
    public string Brandul { get; set; }
    public string Model { get; set; }
    public decimal Pret { get; set; }
    public string Descriere { get; set; }
    public int Stoc { get; set; }

    public Telefon(int id, string brand, string model, decimal pret, string descriere, int stoc)
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
    }

    public void Adauga_Client(Client client)
    {
        clienti.Add(client);
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
