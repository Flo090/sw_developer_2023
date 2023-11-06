using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instanz
            //Book myBook = new Book();

            Book aBook = new Book("Die unendliche Geschichte", "Michael Ende", "X-5655-321-9", 550, 26.90m);

            // 1. Initialisierung ?     DONE!
            // 2. Zustandsinformationen nicht geschützt!!!

            // Zustandsinformationen initialisieren
            //myBook.Id = Guid.NewGuid();
            //myBook.Author = "Michael Ende";
            //myBook.Title = "Die unendliche Geschichte";
            //myBook.Isbn = "X-65654464-665454-9";
            //myBook.PageCount = 550;
            //myBook.Price = 26.50m;
            //myBook.IsAvailable = true;

            //myBook.DisplayInfos();

            //myBook.StartBorrowing(TimeSpan.FromDays(7));
            //myBook.DisplayInfos();

            //myBook.StopBorrowingDate = new DateTime(2024, 12, 31);
            //myBook.StartBorrowingDate = new DateTime(2024, 2, 28);

            aBook.DisplayInfo();
            

            //myBook.EndBorrowing();
            //myBook.DisplayInfos();
        }
    }
}
