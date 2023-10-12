using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BeispielZahlenRaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variablen
            const int MIN_VALUE = 1;
            const int MAX_VALUE = 100;
            TimeSpan MAX_GAME_DURATION = TimeSpan.FromSeconds(10);

            int eingabe = 0;
            int anzahlVersuche = 5;
            int anzDurchlauefe = 0;

            // Zufallszahl
            Random rnd = new Random();
            int geheimZahl = rnd.Next(MIN_VALUE, MAX_VALUE + 1);
            // Boolsche Variablen
            bool numberIsValid = false;
            bool zahlErraten = false;

            // Header
            Console.WriteLine($"Zahlen raten (Zwischen {MIN_VALUE} und {MAX_VALUE})\n");

            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            TimeSpan gameDuration = TimeSpan.Zero;

            do
            {
                // Eingabe
                Console.WriteLine($"Anzahl der Versuche {anzahlVersuche - anzDurchlauefe}");
                Console.Write("Geben Sie eine Zahl ein:");

                anzDurchlauefe++;

                try
                {
                    eingabe = int.Parse(Console.ReadLine());
                    numberIsValid = true;   
                }
                catch
                {
                    Console.WriteLine("Fehler bei der Eingabe!!");
                    numberIsValid = false;
                }

                endTime = DateTime.Now;
                TimeSpan currentDuration = endTime - startTime;

                if ( currentDuration > MAX_GAME_DURATION )
                {
                    Console.WriteLine("Leider Spielzeit abgelaufen");
                    return;
                }
                
                if (eingabe < 1 || eingabe > 100)
                {
                    Console.WriteLine("Zahl nicht im Bereich zwischen 1 und 100");
                    numberIsValid = false;
                }

                if (numberIsValid)
                {
                    //Eingabe < Geheimzahl ==> Ausgabe; Zahl ist grösser!
                    //Eingabe > Geheimzahl ==> Ausgabe: Zahl ist kleiner!
                    //Eingabe = Geheimzahl ==> Ausgabe: Sie haben GEWONNEN!

                    if (eingabe < geheimZahl)
                    {
                        Console.WriteLine("\nZahl ist grösser!");
                        zahlErraten = false;
                    }
                    else if (eingabe > geheimZahl)
                    {
                        Console.WriteLine("\nZahl ist kleiner!");
                        zahlErraten = false;
                    }
                    else if (eingabe == geheimZahl)
                    {
                        Console.WriteLine("\nSie haben GEWONNEN!");
                        zahlErraten = true;
                    }
                }
            }
            while (!zahlErraten && !(anzDurchlauefe == anzahlVersuche));
        }
    }
}
