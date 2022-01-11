using System;
using System.Collections.Generic;
using Game;
using Minigames;
using Loader;

namespace Critical_Statum_Contagion_Revamp
{
    class Program
    {

        static Save currentGame;

        static void Main(string[] args)
        {
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

            Console.Write("Enter Command: ");
            string input = Console.ReadLine();

            while (input != "exit") {
                Console.WriteLine(input);
                Console.Write("Enter Command: ");
                input = Console.ReadLine();
            }


        }
    }

    class Commands
    {
        /*
        COMMANDS:
        - Inventory (invent)
            - List Items    (list)
                - *, tools, weapons, 
            - Description   (desc)
            - Find          (find)
        - Wallet    (wallet)
        - Read      (docs)
        - GoTo      (goto)
        - Map       (map)
        - Save      (save)
        - Help      (help)
            - Commands      (<command>)
        - Exit      (exit)
        */
    }

    // Use String -> Method thingy
    // All minigames return a boolean
    class Minigames
    {
        /*
        MINIGAMES:
        - Combat
        - Corrupted Combat
        - Boss Combat
        - Password (Simple Area Input)
        - Maze
        - Battleship
        - Anagram
        - Hangman
        */
    }
}
