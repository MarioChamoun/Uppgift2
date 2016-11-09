using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUppgift
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool again = true;
            while (again)
            {
                userval classval = new userval();
                Console.WriteLine("Välj ett nummer: ");
                Console.WriteLine("1: Lägg till kund");
                Console.WriteLine("2: Lägg till produkt");
                Console.WriteLine("3: Uppdatera produkt pris");
                try
                {
                    int val = int.Parse(Console.ReadLine());
                    if (val == 1) { classval.createcustomer(); }
                    else if (val == 2) { classval.createproduct(); }
                    else if (val == 3) { Console.WriteLine(classval.updateprice()); }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    
                }
                Console.ReadLine();
            }
        }
    }
}
