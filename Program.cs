using System;
using System.Collections.Generic;
using Game;
using Control;
using Loader;
using static Control.Terminal;

namespace Critical_Statum_Contagion_Revamp
{
    class Program
    {

        static void Main(string[] args)
        {
            DataLoader dl = new DataLoader();
            string helptxt = dl.readFileComplete("/text/help.txt");
            string systxt = dl.readFileComplete("/text/sysinfo.txt");
            Commands.load(helptxt, systxt);

            Console.WriteLine("CRITICAL STATUM: CONTAGION");

            //TEST STAGE

            /*Save lol = new Save();
            /Tool x = new Tool();
            x.init("axe", 2);

            lol.addToInvent(x);
            lol.addToInvent(x);
            lol.removeFromInvent(x.name);

            Console.WriteLine("");

            */

            //TEST STAGE

            //Main Game Loop -- Relplace with keypress 'enter' event

            Terminal.run();


        }
    }
    
}
