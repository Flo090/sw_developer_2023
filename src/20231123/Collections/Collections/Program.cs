using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //alt = Array
            //var nameList = new string[]
            //{
            //    ""
            //};

            var nameList = new List<string>();
            var dateList = new List<DateTime>();

            nameList.Add("Gandalf");
            nameList.Add("Hans");
            nameList.Add("Max");

            nameList.Remove("Hans");

            DisplayItems(nameList);
        }

        private static void DisplayItems(IEnumerable<string> nameList)
        {
            foreach (var item in nameList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
