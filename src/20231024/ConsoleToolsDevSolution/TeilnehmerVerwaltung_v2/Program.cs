using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wifi.UITools;

namespace TeilnehmerVerwaltung_v2
{
    internal class Program
    {
        // Implementieren Sie eine Applikation mit der beliebig viele Teilnehmerdaten erfasst und dargestellt
        // werden können. Folgende Anforderung sollen dabei erfüllt werden:

        // - max.Anzahl der Teilnehmer soll zu Beginn vom User abgefragt werden
        // - Einlesen folgender Daten:
        //     - Name, Vorname
        //     - Geburtsdatum
        //     - PLZ, Ort
        // - Fehlertolerante Eingaben
        // - verwenden sie Methoden wo sinnvoll
        // - verwenden sie Farben
        // - Teilnehmerdaten sollen nach der Eingabe tabellarisch ausgegeben werden

        static void Main(string[] args)
        {
            int teilnehmerCount = 0;
            Teilnehmer teilnehmer = new Teilnehmer();
            Teilnehmer[] teilnehmerListe;
            string headerText = "Teilnehmer Verwaltung v2.0   (c) 2023 Wifi-Soft";

            // Header
            ConsoleTools.CreateHeader(headerText, ConsoleColor.Yellow, true);

            // Abfrage Anzahl Teilnehmer
            teilnehmerCount = ConsoleTools.ReadInt("Bitte Anzahl Teilnehmer eingeben: ");

            // TeilnehmerListe vorbereiten
            teilnehmerListe = new Teilnehmer[teilnehmerCount];

            // Daten einlesen
            Console.WriteLine("Bitte geben Sie die Teilnehmerdaten ein: ");

            for (int i = 0; i < teilnehmerListe.Length; i++)
            {
                Console.WriteLine($"\nTeilnehmer {i + 1} / {teilnehmerListe.Length}: ");
                // TODO: Die GetStudentInfos() Methode kann auch überladen werden, damit Sie eine ganze Liste einliest ...
                teilnehmerListe[i] = GetStudentInfos();
            }

            // Ausgabe der Daten
            Console.WriteLine("\nDie Teilnehmerdaten: \n");
            DisplayStudentInfo(teilnehmerListe);
            // TODO: Implement JSON and XML format too !!!
            SaveStudentInfosToFile(teilnehmerListe, "meineTeilnehmerDaten.csv");
        }

        private static void SaveStudentInfosToFile(Teilnehmer[] students, string filename)
        {
            // TODO: Wie funktioniert StreamReader?
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                for (int i = 0; i < students.Length; i++)
                {
                    string dataLine = $"{students[i].Name}, {students[i].Nachname}, {students[i].Geburtsdatum.ToShortDateString()}, {students[i].Plz}, {students[i].Ort}";
                    sw.WriteLine(dataLine);
                }
            }
        }

        private static Teilnehmer GetStudentInfos()
        {
            Teilnehmer teilnehmer;

            teilnehmer.Name = ConsoleTools.ReadString("\tVorname: ");
            teilnehmer.Nachname = ConsoleTools.ReadString("\tNachname: ");
            teilnehmer.Geburtsdatum = ConsoleTools.ReadDateTime("\tGeburtsdatum: ");    // Eingabe Geburtsdatum => Methode weil komplex
            teilnehmer.Plz = ConsoleTools.ReadInt("\tPLZ: ");                           // Eingabe PLZ => Methode weil komplex
            teilnehmer.Ort = ConsoleTools.ReadString("\tWohnort: ");

            return teilnehmer;
        }

        private static void DisplayStudentInfo(Teilnehmer[] studentInfos)
        {
            for (int i = 0; i < studentInfos.Length; i++)
            {
                DisplayStudentInfo(studentInfos[i]);
            }
        }

        private static void DisplayStudentInfo(Teilnehmer studentInfo)
        {
            Console.WriteLine($"\t{studentInfo.Name}, {studentInfo.Nachname}, {studentInfo.Geburtsdatum.ToShortDateString()}, {studentInfo.Plz}, {studentInfo.Ort}");
        }
    }
}
