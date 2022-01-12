using System;
using System.Collections.Generic;
using Game;
using Minigames;
using Loader;
using static Control.Terminal;

namespace Critical_Statum_Contagion_Revamp
{
    class Program
    {

        static public Save game;

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

            Console.Write("> ");
            string input = Console.ReadLine();

            while (input != "exit") {
                // Proccess Stage
                #pragma warning disable CS0168
                try {
                    Commands.run(input);
                } catch (NullReferenceException e) {
                    print("An error has occured when executing the entered command."
                    + "\nHave you loaded a save file or started a new game?");
                }
                #pragma warning restore CS0168

                // Input Stage
                Console.Write("\n> ");
                input = Console.ReadLine();
            }


        }
    }

    static class Commands
    {
        static string[] err = new string[] {
            "The command entered is unrecognised, please enter 'help' to see command list.",
            "An incorrect amount of arguments corresponding to your entered command has been entered."
            + "\nPlease enter 'help' to see command list.",
            "The second argument in the command is unrecognised, please enter 'help' to see command list.",
            "The command does not exist. Please type 'help' with no additional arguments to see all commands."
        };

        static Dictionary<String, String> help = new Dictionary<String, String>() {
            {"inventory", "inventory ..."}
        };

        /*
        COMMANDS:
        - Inventory     (inventory)
            - List Items    (list)
                - *, tools, weapons
            - Description   (desc)
            - Find          (find)
        - Wallet        (wallet)
        - Read          (read)
        - GoTo          (goto)
        - Look Around   (look)
        - Map           (map)
        - New Game      (newgame)
        - Data          (data)
            - Save          (save)
            - Load          (load)
            - Clear         (clear)
                - File Name (<name>)    [for all 3 commands]
            - List          (list)
        - Help          (help)
            - Commands      ([<command>])
        - Exit          (exit)
        */

        public static void run(string input) {
            string[] list = input.Split(" ");

            if (list.Length == 0) { return; }

            if (list[0] == "inventory") {
                if (list.Length != 3) {
                    print(err[1]);
                } else if (list[1] == "list") {
                    print(Program.game.invent.list(list[2]));
                } else if (list[1] == "desc") {
                    print(Program.game.invent.desc(list[2]));
                } else if (list[1] == "find") {
                    if (Program.game.invent.find(list[2])) {
                        print("Item does exist in inventory.");
                    } else {
                        print("Item does not exist in inventory.");
                    }
                } else {
                    print(err[2]);
                }
            } else if (list[0] == "wallet") {
                if (list.Length != 1) {
                    print(err[1]);
                } else {
                    print(Program.game.wallet());
                }
            } else if (list[0] == "read") {
                if (list.Length != 2) {
                    print(err[1]);
                } else {
                    print(Program.game.invent.read(list[1]));
                }
            } else if (list[0] == "goto") {
                if (list.Length != 2) {
                    print(err[1]);
                } else {
                    print(Program.game.goTo(list[1]));
                }
            } else if (list[0] == "look") {
                if (list.Length != 1) {
                    print(err[1]);
                } else {
                    print(Program.game.look());
                }
            } else if (list[0] == "map") {
                if (list.Length != 1) {
                    print(err[1]);
                } else {
                    print(Program.game.map.display());
                }
            } else if (list[0] == "data") {
                DataLoader dl = new DataLoader();
                if (list.Length == 3) {
                    if (list[1] == "save") {
                        print("Attempting to save to file '" + list[2] + "' ...");
                        print(dl.saveGame(Program.game, list[2]));
                    } else if (list[1] == "load") {
                        print("Attempting to load file '" + list[2] + "' ...");
                        Tuple<Save, string> t = dl.loadGame(list[2]);
                        print(t.Item2);
                        if (t.Item1 != null) {
                            Program.game = t.Item1;
                        }
                    } else if (list[1] == "clear") {
                        print("Attempting to clear file '" + list[2] + "' ...");
                        print(dl.clearGame(list[2]));
                    }
                } else if (list.Length != 2) {
                    print(err[1]);
                } else if (list[1] == "list") {
                    print(dl.listSaves());
                }
            } else if (list[0] == "help") {
                if (list.Length > 2) {
                    print(err[1]);
                } else if (list.Length == 1) {
                    string str = "";
                    foreach (String s in help.Values) {
                        str += s + "\n";
                    }
                    print(str);
                } else if (list.Length == 2) {
                    if (list[1] == "list") {
                        string str = "";
                        foreach (String s in help.Keys) {
                            str += s + "\n";
                        }
                        print(str);
                    } else if (help.ContainsKey(list[1])){
                        print(help[list[1]]);
                    } else {
                        print(err[3]);
                    }
                }
            } else {
                print(err[0]);
            }
        }
    }

    // Use String -> Method thingy
    // All minigames return a boolean
    class Minigames
    {
        // Seperate ">" from minigame "$"
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
        - Hacking
        */
    }
    
}
