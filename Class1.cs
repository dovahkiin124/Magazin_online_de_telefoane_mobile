
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using System.Xml.Serialization;


public enum reteadetelefonie
{
    Telecom,
    Orange,
    Digi,
    Vodafone
}

public class Telefon
{

    public string Brandul { get; set; }
    public string Model { get; set; }
    public decimal Pret { get; set; }
    public string Descriere { get; set; }
    public bool Stoc { get; set; }

    public Telefon(string brand, string model, decimal pret, string descriere, bool stoc)//constructor al clasei telefon
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

    public string Adresa { get; set; }
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
public enum retele
{
    vodafone,
    digi,
    orange,
    telecom
}
public class MagazinulDeTelefoaneMobile
{
    public List<Telefon> telefoane = new List<Telefon>();
    private List<Client> clienti = new List<Client>();
    private List<Comanda> comenzi = new List<Comanda>();

    public void Adauga_Telefon(Telefon telefon)
    {
        telefoane.Add(telefon);


    }
    public void SalveazaTelefoane(string filePath)
    {

        try
        {
            foreach (Telefon telefon in telefoane)
            {
                using (StreamWriter file = new StreamWriter(filePath, true))
                {
                    // Scrie datele telefonului in fisier
                    file.WriteLine($" {telefon.Brandul}, {telefon.Model}, {telefon.Pret}, {telefon.Descriere}, {telefon.Stoc}");
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"A aparut o eroare la salvarea fisierului: {ex.Message}");
        }
    }




    public void Adauga_Client(Client client)
    {
        clienti.Add(client);

        // Deschide fișierul în modul append
        using (StreamWriter file = new StreamWriter("C:/Users/Asus/Desktop/client.txt"))
        {
            // Scrie datele clientului in fisier
            file.WriteLine($"{client.Nume}, {client.Email}, {client.Adresa}, {client.Comenzi}");
        }

        Console.WriteLine("Client adaugat cu succes!");
    }


    public Client Cauta_Client(string email)
    {

        using (StreamReader sr = new StreamReader(@"C:/Users/Asus/Desktop/client.txt"))
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




    public List<Telefon> ReadPhonesFromFile(string filePath)
    {
        telefoane = new List<Telefon>();

        using (var reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(',');

                if (fields.Length == 4)
                {
                    string brand = fields[0].Trim();
                    string model = fields[1].Trim();
                    decimal pret = decimal.Parse(fields[2].Trim());
                    string descriere = fields[3].Trim();
                    //bool stoc = bool.Parse(fields[4].Trim());

                    telefoane.Add(new Telefon(brand, model, pret, descriere,true));
                }
            }
        }

        return telefoane;
    }


    public List<Telefon> SearchTelefoane(string criteria)
    {
        var Gasit = telefoane.Where(b =>
            b.Brandul.ToLower().Contains(criteria.ToLower()) ||
            b.Model.ToLower().Contains(criteria.ToLower()) ||
            b.Pret.ToString().ToLower().Contains(criteria.ToLower())
        ).ToList();

        return Gasit;
    }



    public List<Telefon> GetTelefoane()
    {
        List<Telefon> telefoane = new List<Telefon>();

        using (StreamReader sr = new StreamReader(@"C:/Users/Asus/Desktop/telefon.txt"))
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
                bool stoc = bool.Parse(fields[4].Trim());

                Telefon telefon = new Telefon(brand, model, pret, descriere, stoc);
                telefoane.Add(telefon);
            }
        }

        return telefoane;
    }
    public void Afisare_Telefoane(List<Telefon> telefoane)
    {
        if (telefoane.Count == 0)
        {
            Console.WriteLine("Nu exista telefoane in magazin.");
        }
        else
        {
            // Afiseaza fiecare telefon
            foreach (Telefon phone in telefoane)
            {

                Console.WriteLine($"Brand: {phone.Brandul}");
                Console.WriteLine($"Model: {phone.Model}");
                Console.WriteLine($"Pret: {phone.Pret}");
                Console.WriteLine($"Descriere: {phone.Descriere}");
                Console.WriteLine($"Stoc: {phone.Stoc}");
                Console.WriteLine();
            }
        }
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
