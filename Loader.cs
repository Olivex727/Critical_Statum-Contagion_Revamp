using Game;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Loader {
    class DataLoader {

        string dir = Directory.GetCurrentDirectory();

        public static Map loadMapData(string name) {
            return new Map();
        }

        public string saveGame(Save game, string file) {
            return "Game saved succsessfully";
        }

        public string clearGame(string file) {
            return "Game data cleared succsessfully";
        }
        
        public Tuple<Save, string> loadGame(string file) {
            return Tuple.Create(new Save(), "Game loaded succsessfully");
        }

        public string listSaves() {
            return "";
        }

        private void writeFile() {

        }

        private void readFile() {
            
        }

        public string readFileComplete(string file) {
            string text = "";
            try {
                text = File.ReadAllText(dir+file);
            } catch (IOException e) {
                Console.WriteLine(e.Message);
            }
            return text;
        }

        public static Tuple<Save, string> newGame() {
            return Tuple.Create(new Save(false), "Game created succsessfully");
        }

        public Player[] deserializePlayers() {
            using (StreamReader file = File.OpenText(dir+"/ReadOnly/Players.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (Player[])serializer.Deserialize(file, typeof(Player[]));
            }
        }

    }

    class Decoder {

        public static Save decodeSave(string save) {
            return null;
        }
        
        public static Map decodeMap(string map) {
            return null;
        }

        public static Dictionary<string, Item> decodeItemMass(string item) {
            string[] items = item.Split(";");
            Dictionary<string, Item> dic = new Dictionary<string, Item>();
            foreach (string i in items) {
                string[] it = i.Split(",");
                dic.Add(it[0], new Item(it[0], byte.Parse(it[1]), it[2]));
            }
            return dic;
        }

        public static Dictionary<string, Tool> decodeToolMass(string item) {
            string[] items = item.Split(";");
            Dictionary<string, Tool> dic = new Dictionary<string, Tool>();
            foreach (string i in items) {
                string[] it = i.Split(",");
                dic.Add(it[0], new Tool(it[0], byte.Parse(it[1]), it[2]));
            }
            return dic;
        }

        public static Dictionary<string, Doc> decodeDocMass(string item) {
            string[] items = item.Split(";");
            Dictionary<string, Doc> dic = new Dictionary<string, Doc>();
            foreach (string i in items) {
                string[] it = i.Split(",");
                dic.Add(it[0], new Doc(it[0], byte.Parse(it[1]), it[2], it[3]));
            }
            return dic;
        }

        public static Dictionary<string, Weapon> decodeWeaponMass(string item) {
            string[] items = item.Split(";");
            Dictionary<string, Weapon> dic = new Dictionary<string, Weapon>();
            foreach (string i in items) {
                string[] it = i.Split(",");
                dic.Add(
                    it[0],
                    new Weapon(it[0], byte.Parse(it[1]), it[2], int.Parse(it[3]), int.Parse(it[4]), int.Parse(it[5]))
                    );
            }
            return dic;
        }

        public static Space decodeSpace(string space) {
            return null;
        }

        public static Area decodeArea(string area) {
            return null;
        }

    }
}