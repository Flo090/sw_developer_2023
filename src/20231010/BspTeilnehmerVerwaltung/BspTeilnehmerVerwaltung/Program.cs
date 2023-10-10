using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BspTeilnehmerVerwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Eingabe Name, Vorname, Geburtsdatum pro Teilnehmer
            //Validierung der Daten auf Gültigkeit => keine Abstürze
            //Verwenden Sie in der Ein-und Ausgabe Farben
            //Achten Sie auf eine klare Benutzerführung

            string name = string.Empty;
            string vorname = string.Empty;
            DateTime geburtsDatum = DateTime.MinValue;
            string input = string.Empty;

            // Header
            Console.WriteLine("Teilnehmer-Verwaltung\n\n");
            
            // Eingabe der Daten
            Console.WriteLine("Daten eingeben:");
            Console.Write("\tName eingeben: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            name = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\tVorname eingeben: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            vorname = Console.ReadLine();
            Console.ResetColor();

            Console.Write("\tGeburtsdatum eingeben (dd-mm-YYYY): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            input = Console.ReadLine();
            Console.ResetColor();

            try
            {
                geburtsDatum = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\aERROR: Ungültige Datumseingabe.\n" );
                geburtsDatum = DateTime.MinValue;
                Console.ResetColor();
            }

            // Validierung des Wertebereichs für Geburtsdatum (16-95)
            //TimeSpan alter = DateTime.Now.Subtract(geburtsDatum);
            //DateTime minAge = DateTime.Now.Subtract(new TimeSpan())
            if (geburtsDatum.Year == DateTime.MinValue.Year)
            {
                return;
            }

            int alter = DateTime.Now.Year - geburtsDatum.Year;

            if (alter < 16 || alter > 95)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR:\a Leider ist der Teilnehmer ausserhalb des gültigen Altersbereich.");
                Console.ResetColor();
                return;

            }

            // Ausgabe der Daten
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nTeilnehmerdaten:");
            Console.WriteLine($"\tVorname:       {vorname}");
            Console.WriteLine($"\tName:          {name}");
            Console.WriteLine($"\tGeburtsdatum:  {geburtsDatum.ToLongDateString()}");
            Console.ResetColor();
        }
    }
}
