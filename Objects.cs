using System;
using System.IO;
using System.Collections.Generic;
using Loader;
using static Control.Terminal;

#pragma warning disable CS0169 // REMOVE LATER

namespace Game
{

    //=====PLAYER/STATE OBJECTS=====//

    /*
     * Save/Game State containing:
     * - Player Info
     * - Current Location
     * - Inventory and visited Locations
     * 
     */
    class Save
    {
        public Map map { get; set; }

        public Player[] players { get; set; }

        public Location loc { get; set; }

        public Inventory invent { get; set; }

        public int act;

        public Currency credits { get; set; }

        // Creates basic save to load on
        public Save(bool blank = true) {
            if (!blank) {
                invent = new Inventory();
                players = new Player[5];
                try {
                    map = DataLoader.loadMapData("tutorial");
                    loc = map.getFirstLoc();
                } catch (IOException e) {
                    onload(e);
                    print("An error occured when attempting to load the tutorial data.");
                } catch (NullReferenceException e) {
                    onload(e);
                    print("An error occured when attempting to prepare the tutorial.");
                }
                act = 0;
                credits = new Currency("Credits", 0, 200);
            }
        }

        // Creates a string of encoded data
        public string encode() {
            return "";
        }

        public string goTo(string loc) {
            return "";
        }

        public string look() {
            return "";
        }

        public string wallet() {
            return "";
        }

        public string teamList() {
            return "";
        }

        public string upgrade(int member) {
            return "";
        }

        public string toString() {
            return "";
        }
    }

    /*
     * Player state containing:
     * - Currency
     * - Name
     * - Type
     * 
     */
    class Player
    {

        public string name { get; set; }

        public Currency curr { get; set; }

        public Type type { get; set; }

        public int level = 1;

        //One of the five people available to choose
        //IDs of 'person', using modulo to confirm important info
        /*
         * REQUIRED:
         * Leader - 0
         * Pilot - 1
         *
         * PICK ONE POWER OF p:
         * Mechanic - 2
         * Engineer - 4
         * Tinkerer - 8
         *
         * Marksman - 3
         * Heavy - 9
         * Soldier - 27
         * 
         * Programmer - 5
         * Hacker - 25
         * Scientist - 125
         * 
        */
        public enum Type {
            Leader = 0, Pilot = 1, Mechanic = 2, Marksman = 3, Hacker = 4
        }

        Player(string name) {
            this.name = name;
        }

        public Player(string name, Currency curr, Type type, int level = 1) {
            this.name = name; this.curr = curr; this.type = type; this.level = level;
        }

        public string toString() {
            return "";
        }
    }

    //=====LOCATION OBJECTS=====//

    // Abstract class that can be activated
    abstract class Space {
        public string[] outputDesc { get; set; }

        /*
         * 0. Fail Unlock
         * 1. First introduction
         * 2. Minigame Faliure
         * 3. Minigame Pass
         * 4. Updated Introduction
         */
        protected int level { get; set; }

        public string name { get; set; } // Used in command line

        public string unlock { get; set; }

        public abstract string activate(Save state);

        protected Space(string[] outputDesc, string name) {
            this.outputDesc = outputDesc;
            this.name = name;
        }

        protected void incLevel() { level++; }

        public string toString() {
            return "";
        }
    }

    /*
     * Map Location containing:
     * - Location Areas
     * - Pointers to Adjacent Locations
     */
    class Location : Space {

        HashSet<Area> areas;

        HashSet<String> pointers;

        public bool entry;

        Location(string[] outputDesc, string name, bool entry) : base(outputDesc, name) {
            this.areas = new HashSet<Area>();
            this.pointers = new HashSet<String>();
            this.entry = entry;
        }

        public override string activate(Save state = null) {
            return outputDesc[level];
        }

    }

    /*
     * Map Location containing:
     * - Area Stage
     * Note that if a minigame is passed, the string Space.name+'+' charachter is added to visited as well as Space.name.
     */
    class Area : Space {

        AreaStage stage;

        Area(string[] outputDesc, string name, AreaStage stage) : base(outputDesc, name) {
            this.stage = stage;
        }

        public override string activate(Save state = null) {
            return outputDesc[level];
        }
    }

    /*
     * Space Structure containing feilds:
     * 1. Minigame
     * 2. Background Audio
     * 3. Background Image
     * 4. SFX
     * 5. Item Gained
     * 6. Currency Earned (Array)
     */
    public struct AreaStage {
        string minigame;

        string audio;

        string image;

        string sfx;

        string item; // Refrence to an item (to save space)

        (int, int)[] currency; // [ID, Amt.]
    }

    //Custom data structure of locations
    class Map {
        private HashSet<Location> locs;

        public Location getFirstLoc() {
            foreach (Location l in locs) {
                if (l.entry) { return l; }
            }
            throw new NullReferenceException();
        }

        public string display() {
            return "";
        }

        public string toString() {
            return "";
        }
    }

    //=====ITEM OBJECTS=====//

    /*
     * Map Location containing:
     * - Name
     * - UseageID
     */
    //Abstract class from which all carryable items occur
    class Item
    {
        //The name of the item
        public string name { get; set; }

        //What Person can use the item
        public byte usageID { get; set; }

        public string desc { get; set; }

        public Item(string itemname, byte id, string desc) {
            name = itemname;
            usageID = id;
            this.desc = desc;
        }

        public string toString() {
            return "";
        }
    }

    //Currency can be used either as a skill point/payment item
    class Currency : Item
    {
        public int amount;

        public Currency(string itemname, byte id, int amount = 0) : base(itemname, id, "") {
            this.amount = amount;
        }

        public bool pay(int amount) {
            if (this.amount >= amount) {
                this.amount -= amount;
                return true;
            } else {
                return false;
            }
        }

        new public string toString() {
            return "";
        }
    }

    //A tool is an item that can be used
    class Tool : Item
    {
        string output = "Used the ";

        //Uses the tool
        public string use()
        {
            return output;
        }

        public Tool(string itemname, byte id, string desc) : base(itemname, id, desc) {
            
        }

        new public string toString() {
            return "";
        }
        
    }

    //A document item, stored in inventory (Only the conspiracy documents)
    class Doc : Item
    {
        // A string of all of the document's inner details
        private string contents { get; set; }
    
        public Doc(string itemname, byte id, string desc, string contents) : base(itemname, id, desc) {
            this.contents = contents;
        }

        new public string toString() {
            return "";
        }
    }

    class Weapon : Tool
    {
        //How much damage does the weapon give
        public int damage { get; set; }

        //How accurate it is
        public int accuracy { get; set; }

        //How quick can it be used
        public int speed { get; set; }

        public Weapon(string itemname, byte id, string desc, int dmg, int acc, int spd) : base(itemname, id, desc) {
            this.damage = dmg; this.accuracy = acc; this.speed = spd;
        }

        new public string toString() {
            return "";
        }
    }

    class Inventory {
        public HashSet<Item> items { get; set; }

        public Inventory() {
            items = new HashSet<Item>();
        }

        public bool find(string item) {
            return true;
        }

        public string list(string group) {
            return "";
        }

        public string desc(string item) {
            return "";
        }

        public string read(string item) {
            return "";
        }

        public string toString() {
            return "";
        }
    }
}