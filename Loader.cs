using Game;
using System;
using System.Collections.Generic;

namespace Loader {
    class DataLoader {

        public string loadData(string name, string classtype) {
            return "";
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

        public Tuple<Save, string> newGame() {
            return Tuple.Create(new Save(), "Game created succsessfully");
        }

    }

    class Decoder {

        public Save decodeSave(string save) {
            return null;
        }
        
        public Map decodeMap(string map) {
            return null;
        }

        public Item decodeItem(string item) {
            return null;
        }

        public Space decodeSpace(string space) {
            return null;
        }

        public Space decodeArea(string area) {
            return null;
        }

    }
}