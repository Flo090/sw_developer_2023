using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrundlagenArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl = 4;
            const int MAX_ITEM_COUNT = 40;

            // Deklaration & Dimensionierung
            int[] zahlen;
            //double[]
            //Teilnehmer[] meinTeilnehmerListe;

            // Dimensionierung
            zahlen = new int[MAX_ITEM_COUNT];

            zahlen[0] = 45;
            zahlen[2] = 50;

            Console.WriteLine($"2. Wert: {zahlen[1]}");

            for (int i = 0; i < zahlen.Length; i++)
            {
                zahlen[i] = 0;
            }
        }
    }
}
