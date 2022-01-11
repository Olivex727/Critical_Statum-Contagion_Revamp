using System;
using System.Collections.Generic;
using Loader;

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

        // Creates basic save to load on
        public Save() {
            invent = new Inventory();
            players = new Player[5];
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

        string name { get; set; }

        Currency curr { get; set; }

        Type type { get; set; }

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
        enum Type {

        }

        Player(string name, Currency curr, Type type) {
            this.name = name; this.curr = curr; this.type = type;
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
    }

    /*
     * Map Location containing:
     * - Location Areas
     * - Pointers to Adjacent Locations
     */
    class Location : Space {

        HashSet<Area> areas;

        HashSet<String> pointers;

        Location(string[] outputDesc, string name) : base(outputDesc, name) {
            this.areas = new HashSet<Area>();
            this.pointers = new HashSet<String>();
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
        HashSet<Location> locs;

        public string display() {
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

        public Item(string itemname, byte id) {
            name = itemname;
            usageID = id;
        }
    }

    //Currency can be used either as a skill point/payment item
    class Currency : Item
    {
        public int amount;

        public Currency(string itemname, byte id, int amount = 0) : base(itemname, id) {
            this.amount = amount;
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

        public Tool(string itemname, byte id) : base(itemname, id) {
            
        }
        
    }

    //A document item, stored in inventory
    class Doc : Item
    {
        //A string of all of the document's inner details
        private string documentContents { get; set; }
    
        public Doc(string itemname, byte id) : base(itemname, id) {
            
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

        public Weapon(string itemname, byte id, int dmg, int acc, int spd) : base(itemname, id) {
            this.damage = dmg; this.accuracy = acc; this.speed = spd;
        }
    }

    class Inventory {
        public HashSet<Item> items { get; set; }

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
    }
}