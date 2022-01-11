using Game;
using System;
using System.Collections.Generic;

namespace Loader {
    class DataLoader {

        public string loadData(string name, string classtype) {
            return "";
        }

        static void saveGame(Save game) {

        }
        
        static Save loadGame() {
            return new Save();
        }

        static private void writeFile() {

        }

        static private void readFile() {
            
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