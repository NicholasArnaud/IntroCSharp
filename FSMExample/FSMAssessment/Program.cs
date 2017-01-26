using System;
using System.Collections.Generic;
using System.IO;

namespace FSMAssessment
{
    class Program
    {


        static int TaylorLove = 0;
        static void Main(string[] args)
        {

            Student reggie = new Student();
            
            reggie.AddThingToSay(TaylorSwift);
            reggie.AddThingToSay(NickSaid);
            reggie.Talk();
        }
        static public void NickSaid()
        {
            Console.WriteLine("why you love taylor so much...");
        }
        static public void TaylorSwift()
        {
            TaylorLove = 9000;
            Console.WriteLine("I love me some taylor swift");
        }
    }
}