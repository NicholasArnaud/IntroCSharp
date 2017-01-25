using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GistAssignments
{

    class Program
    {


        #region gist 1
        static void Main(string[] args)
        {
            /*
             * Gist 1: In C# create a new list of integers then populate the list with all
                even numbers from 0 to 100. Then print all of these numbers to the console.
                Once you have that loop through the list again and remove all numbers that are
                a multiple of 10. Then print all the remaining numbers to the console.
             */
            List<int> noTens = new List<int>();
            int k = 0;
            for (int i = 0; i <= 100; i += 2)
            {
                noTens.Add(i);
                Console.WriteLine(noTens.ElementAt(k));
                k++;
            }
            Console.ReadLine();
            int l = 10;
            for (int j = 0; j <= 40; j++)
            {

                noTens.Remove(l);
                Console.WriteLine(noTens.ElementAt(j));
                l += 10;
            }
            #endregion


            ////////////////////////////////////////////////////////////
            /*
             Write a function that takes
             in as an argument, a string representation
             of a binary number whose maximum 
              amount (2^8)-1.
              This function must return a string
              matching this format except the first
              half should be the exact opposite of the second half.
              */

            Gene InvertThis = new Gene("00001001");
            string newHead = "";
            foreach (var c in InvertThis.Tail)
                newHead += Invert(c);



            //for (int i = 0; i <= 8; i++)
            //{

            //    Invert(InvertThis.Head.ElementAt(i));
            //    Invert(InvertThis.Tail.ElementAt(i));

            //}

        }

        static public char Invert(char s)
        {
            return ((s == '0') ? '1' : '0');
        }

        public class Gene
        {
            public Gene(string s)
            {
                if (s.Length != 8)
                    throw new Exception("too big or too small... must be 8 long");
                value = s;
                tail = value.Substring(4);
                head = value.Remove(4, 4);
            }
            string value;
            string tail;
            string head;
            public override string ToString()
            {
                return value;
            }
            public string Head
            {
                get
                {
                    return head;
                }
            }

            public string Tail
            {
                get
                {
                    return tail;
                }
            }
        }


    }
}
