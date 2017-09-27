using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfSoapStudentConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new ServiceReference1.Service1Client("BasicHttpBinding_IService1"))
            {
                bool stop = false;
                while (stop == false)
                {
                    Console.WriteLine("Skriv hvad du vil gøre med programmet." + "\n" + "Funktionerne står nedenunder" + "\n" + "Tilføj" + "\n" + "Slet" + "\n" + "Rediger" + "\n" + "Find" + "\n" + "Se alle studenter" + "\n" + "Stop");
                    string funktion = Console.ReadLine();
                    if (funktion.ToLower() == "tilføj")
                    {
                        Console.WriteLine("Skriv navn på studenten");
                        string navn = Console.ReadLine();
                        Console.WriteLine("Skriv efternavn på studenten");
                        string efternavn = Console.ReadLine();
                        Console.WriteLine("Skriv klassen på studenten");
                        string klasse = Console.ReadLine();
                        Console.WriteLine("skriv id på studenten");
                        int id = Convert.ToInt32(Console.ReadLine());
                        client.AddStudent(navn, efternavn, klasse, id);
                        Console.WriteLine("\n" + "Studenten " + navn + " " + efternavn + " " + klasse + " " + id + " " + "blev tilføjet." + "\n" + "Tryk på en knap for at fortsætte" + "\n" + "\n" + "\n");
                        
                    }
                    else if (funktion.ToLower() == "slet")
                    {
                        Console.WriteLine("Skriv id'et på den student du vil have slettet.");
                        int id = Convert.ToInt32(Console.ReadLine());
                        client.RemoveStudent(id);
                        Console.WriteLine("Studenten med id'et: " + id + "Blev fjernet fra de studerende." + "\n" + "Tryk på en knap for at fortsætte" + "\n" + "\n" + "\n");
                        
                    }
                    else if (funktion.ToLower() == "rediger")
                    {
                        Console.WriteLine("skriv id'et på den student du vil redigere");
                        int id = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("skriv navn på den redigeret student");
                        string navn = Console.ReadLine();
                        Console.WriteLine("skriv efternavn på den redigeret student");
                        string efternavn = Console.ReadLine();
                        Console.WriteLine("skriv klasse på den redigeret student");
                        string klasse = Console.ReadLine();
                        client.EditStudent(navn, efternavn, klasse, id);
                        Console.WriteLine("\n" + "Studenten er blevet redigeret til: " + navn + " " + efternavn + " " + klasse + "\n" + "Tryk på en knap for at fortsætte" + "\n" + "\n" + "\n");
                        
                    }
                    else if (funktion.ToLower() == "find")
                    {
                        Console.WriteLine("skriv id'et på den student du skal finde.");
                        int id = Convert.ToInt16(Console.ReadLine());
                        string navn = client.FindStudent(id).Navn;
                        string efternavn = client.FindStudent(id).Efternavn;
                        string klasse = client.FindStudent(id).Klasse;
                        Console.WriteLine("studenten du leder efter er: " + navn + " " + efternavn + " " + klasse + " " + id + "\n" + "Tryk på en knap for at fortsætte" + "\n" + "\n" + "\n");
                        
                    }
                    else if (funktion.ToLower() == "se alle studenter")
                    {
                        
                        foreach (var student in client.GetAllStudent())
                        {
                            Console.WriteLine("Studentens navn: " + student.Navn + " " + student.Efternavn + "\n" + " Studentens klasse: " + student.Klasse + "\n" + "Studentens id: " + student.ID + "\n" + "Tryk på en knap for at fortsætte" + "\n" + "\n" + "\n");

                        }

                    }
                    else if (funktion.ToLower() == "stop")
                    {
                        stop = true;
                    }
                    else if (funktion == "")
                    {
                        Console.WriteLine("du skal skrive hvilken funktion du vil bruge." + "\n" + "\n" + "Tryk på en knap for at fortsætte" + "\n" + "\n" + "\n");
                        
                    }
                }
            }
        }
    }
}
