using System;
using System.Collections.Generic;
using Game;
using Minigames;

namespace Critical_Statum_Contagion_Revamp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CRITICAL STATUM: CONTAGION");

            //TEST STAGE

            Save lol = new Save();
            Tool x = new Tool();
            x.init("axe", 2);

            lol.addToInvent(x);
            lol.addToInvent(x);
            lol.removeFromInvent(x.name);

            Console.WriteLine("");

            //TEST STAGE

            //Main Game Loop -- Relplace with keypress 'enter' event

            Console.Write("Enter Command: ");
            string input = Console.ReadLine();

            while (input != "exit") {
                Console.WriteLine(input);
                Console.Write("Enter Command: ");
                input = Console.ReadLine();
            }


        }

        static void printToScreen() {
            
        }
    }

    class Minigames
    {

    }
}
