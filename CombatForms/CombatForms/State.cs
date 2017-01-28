using System;
using System.Collections.Generic;
using System.IO;


namespace CombatForms
{
    public delegate void Handler();
    public enum State
    {
        INIT = 0,
        TEAMA = 1,
        TEAMB = 2,
        END = 9999,
    }

    class States
    {
        States() { }
        public States(string id)
        {
            name = id;
            //onenter += Start;
            //onexit += Exit;
        }
        public override string ToString()
        {
            return name;
        }

        //public override void Start()

        //{
        //    Console.WriteLine("enter State " + this.name);
        //}
        //public override void Exit()
        //{
        //    Console.WriteLine("Exit state " + this.name);
        //}

        //public AddEnterFunctionality(Delegate function)
        //{
        //    onEnter += function as Handler;
        //}

        private string name;
        

    }
  
}
