using AlgoritmeClasslibrary;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        Evenement evenement = new();

        evenement.Groups = evenement.Generategroups();

        foreach (Groep group in evenement.Groups)
        {
            Console.WriteLine("Groep:" + group.Groepnumber);

            foreach (Bezoeker visitor in group.Groepbezoekers)
            {
                if (visitor.Child)
                {
                    Console.WriteLine("Bezoeker: " + visitor.Name + " " + "#" + visitor.uniquenumber + " " + visitor.GetFormattedBirthdate() + " (Kind)");
                }
                else
                {
                    Console.WriteLine("Bezoeker: " + visitor.Name + " " + "#" + visitor.uniquenumber + " " + visitor.GetFormattedBirthdate());
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Tijd om in te delen:");
        Console.WriteLine("...");
        Console.WriteLine("...");

        evenement.organise(evenement.Groups);

        Console.WriteLine();

        foreach (Vak vak in evenement.Vakken)
        {
            Console.WriteLine("Vak: " + vak.Name);

            Console.WriteLine();

            foreach (Rij rij in vak.rijen)
            {
                Console.WriteLine("Rij " + rij.Rijnumber + ":");

                foreach (Stoel stoel in rij.Stoelen)
                {
                    if (stoel.assigned)
                    {
                        Console.WriteLine("Stoel: " + vak.Name + rij.Rijnumber + "-" + stoel.number + " (Toegewezen aan: " + stoel.sitter +  " )");
                    }
                    else
                    {
                        Console.WriteLine("Stoel: " + vak.Name + rij.Rijnumber + "-" + stoel.number + " (Niet toegewezen)");
                    }
                }

                Console.WriteLine();
            }
        }

        Console.WriteLine("Groepen die niet ingedeeld zijn:");
        foreach (Groep notaddedgroups in evenement.NotAddedGroups)
        {
            Console.WriteLine("Groep:" + notaddedgroups.Groepnumber);

            foreach (Bezoeker visitor in notaddedgroups.Groepbezoekers)
            {
                if (visitor.Child)
                {
                    Console.WriteLine("Bezoeker: " + visitor.Name + " " + " #" + visitor.uniquenumber + visitor.GetFormattedBirthdate() + " (Kind)");
                }
                else
                {
                    Console.WriteLine("Bezoeker: " + visitor.Name + " " + visitor.GetFormattedBirthdate() + " #" + visitor.uniquenumber);
                }
            }

            Console.WriteLine();
        }

        Console.ReadLine();
    }

}
