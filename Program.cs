using System;
using Game;

/*

The progress of the Project:

1. Add the basic object structure
2. Implement all of the methods
3. Develop/Test the text output game loop
--MOVE TO WINOWS 10--
4. Implement GUI
5. Read from JSON - Enter tutorial stage
6. Do final test of game loop/inventory handling
7. Parse rest of game's events into JSON/text files

*/

namespace Critical_Statum_Contagion_Revamp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CRITICAL STATUM: CONTAGION");

            //TEST STAGE

            Save lol = new Save();

            lol.addToInvent();

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
