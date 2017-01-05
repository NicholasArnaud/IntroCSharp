using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GistAssignments
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Gist 1: In C# create a new list of integers then populate the list with all
                even numbers from 0 to 100. Then print all of these numbers to the console.
                Once you have that loop through the list again and remove all numbers that are
                a multiple of 10. Then print all the remaining numbers to the console.
             */
            List<int> noTens =new List<int>();
            int k = 0;
            for(int i = 0; i <= 100; i+=2)
            {
                noTens.Add(i);
                Console.WriteLine(noTens.ElementAt(k));
                k++;
            }
            Console.ReadLine();
            int l = 10;
            for(int j= 0; j<=40;j++)
            {
                
                noTens.Remove(l);
                Console.WriteLine(noTens.ElementAt(j));
                l+=10;
            }
            Console.ReadLine();
        }
    }
}
