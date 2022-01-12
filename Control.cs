using System;
using static Control.Terminal;
using Loader;
using System.Collections.Generic;
using Game;

namespace Control {
    static class Terminal
    {

        private static Save game;

        private static string[] prevcommands;

        static int[] settings = { 0, 0, 1 };

        public static void run() {
            Console.Write("> ");
            string input = Console.ReadLine();

            while (input != "exit") {
                // Proccess Stage
                #pragma warning disable CS0168
                try {
                    game = Commands.run(input, game);
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

        public static void changeSetting(int setting, int value) {

        }

        public static void print(string str) {
            Console.WriteLine(str);
        }
    }

    static class Commands
    {
        static string[] err = new string[] {
            "The command '","' is unrecognised, please enter 'help' to see command list.",
            "An incorrect amount of arguments corresponding to your entered command has been entered."
            + "\nPlease enter 'help' to see command list.",
            "The second argument in the command is unrecognised, please enter 'help' to see command list.",
            "The command '","' does not exist. Please type 'help' with no additional arguments to see all commands.",
            "The third argument inputted was not an integer."
        };

        static Dictionary<String, String> help = new Dictionary<String, String>();

        static string[] info;

        static string[] date;

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

        public static Save run(string input, Save game) {
            string[] list = input.Split(" ");

            if (list.Length == 0 || input == "") { return game; }

            if (list[0] == "inventory") {
                if (list.Length != 3) {
                    print(err[2]);
                } else if (list[1] == "list") {
                    print(game.invent.list(list[2]));
                } else if (list[1] == "desc") {
                    print(game.invent.desc(list[2]));
                } else if (list[1] == "find") {
                    if (game.invent.find(list[2])) {
                        print("Item does exist in inventory.");
                    } else {
                        print("Item does not exist in inventory.");
                    }
                } else {
                    print(err[3]);
                }
            } else if (list[0] == "cli") {
                if (list.Length != 3) {
                    print(err[2]);
                } else {
                    bool yes = int.TryParse(list[2], out int value);
                    if (yes) { 
                        if (list[1] == "color") {
                            // Change color immediately (here)
                            Terminal.changeSetting(0, value);
                        } else if (list[1] == "speed") {
                            // Change speed as typing runs (unity)
                            Terminal.changeSetting(1, value);
                        } else if (list[1] == "space") {
                            // Change spacing as typing runs (terminal)
                            Terminal.changeSetting(2, value);
                        } else {
                            print(err[3]);
                        }
                    } else { print(err[6]); }
                }
            } else if (list[0] == "wallet") {
                if (list.Length != 1) {
                    print(err[2]);
                } else {
                    print(game.wallet());
                }
            } else if (list[0] == "read") {
                if (list.Length != 2) {
                    print(err[2]);
                } else {
                    print(game.invent.read(list[1]));
                }
            } else if (list[0] == "goto") {
                if (list.Length != 2) {
                    print(err[2]);
                } else {
                    print(game.goTo(list[1])); // AFFECTS SAVE
                }
            } else if (list[0] == "look") {
                if (list.Length != 1) {
                    print(err[2]);
                } else {
                    print(game.look());
                }
            } else if (list[0] == "map") {
                if (list.Length != 1) {
                    print(err[2]);
                } else {
                    print(game.map.display());
                }
            } else if (list[0] == "newgame") {
                if (list.Length != 1) {
                    print(err[2]);
                } else {
                    print("Attempting to create new game ...");
                        Tuple<Save, string> t = DataLoader.newGame();
                        print(t.Item2);
                        if (t.Item1 != null) {
                            game = t.Item1;  // AFFECTS SAVE
                        } else {
                            print("Creation failed.");
                        }
                }
            } else if (list[0] == "data") {
                DataLoader dl = new DataLoader();
                if (list.Length == 3) {
                    if (list[1] == "save") {
                        print("Attempting to save to file '" + list[2] + "' ...");
                        print(dl.saveGame(game, list[2]));
                    } else if (list[1] == "load") {
                        print("Attempting to load file '" + list[2] + "' ...");
                        Tuple<Save, string> t = dl.loadGame(list[2]);
                        print(t.Item2);
                        if (t.Item1 != null) {
                            game = t.Item1;  // AFFECTS SAVE
                        } else {
                            print("Load failed.");
                        }
                    } else if (list[1] == "clear") {
                        print("Attempting to clear file '" + list[2] + "' ...");
                        print(dl.clearGame(list[2]));
                    } else {
                        print(err[3]);
                    }
                } else if (list.Length != 2) {
                    print(err[2]);
                } else if (list[1] == "list") {
                    print(dl.listSaves());
                } else {
                    print(err[2]);
                }
            } else if (list[0] == "help") {
                if (list.Length > 2) {
                    print(err[2]);
                } else if (list.Length == 1) {
                    string str = "";
                    foreach (String s in help.Values) {
                        str += s;
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
                        print(err[4]+list[1]+err[5]);
                    }
                }
            } else if (list[0] == "system") {
                if (list.Length != 2) {
                    print(err[2]);
                } else {
                    int act = game.act;
                    if (list[1] == "info") {
                        print(info[act]);
                    } else if (list[1] == "date") {
                        print(date[act]);
                    } else if (list[1] == "clean") {
                        print("Clean unsucsessful. Please contact your IT staff member.");
                    } else {
                        print(err[3]);
                    }
                }
            } else {
                print(err[0]+input+err[1]);
            }

            return game;
        }

        public static void load(string helptext, string systext) {
            string[] set = helptext.Split("/");

            foreach (string s in set) {
                string[] keypair = s.Split("|");
                if (keypair[0] != "") {
                    if (keypair.Length == 2) {
                        help.Add(keypair[0], keypair[1]);
                    }
                }
            }

            set = systext.Split("\n|");
            int count = 0;
            info = new string[set.Length];
            date = new string[set.Length];

            foreach (string s in set) {
                string[] keypair = s.Split("/");
                if (keypair.Length == 2) {
                    info[count] = keypair[0];
                    date[count] = keypair[1];
                    count++;
                }
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