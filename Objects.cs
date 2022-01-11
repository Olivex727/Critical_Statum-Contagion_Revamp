using System;
using System.Collections.Generic;

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
    }

    //=====LOCATION OBJECTS=====//

    // Abstract class that can be activated
    abstract class Space {
        public string outputDesc { get; set; }

        public string name { get; set; } // Used in command line

        public string unlockKey { get; set; }

        public abstract string activate(Save state);

        protected Space(string outputDesc, string name) {
            this.outputDesc = outputDesc;
            this.name = name;
        }
    }

    /*
     * Map Location containing:
     * - Location Areas
     * - Pointers to Adjacent Locations
     */
    class Location : Space {

        Location(string outputDesc, string name) : base(outputDesc, name) {

        }

        public override string activate(Save state = null) {
            return outputDesc;
        }

    }

    /*
     * Map Location containing:
     * - Area Stage
     * Note that if a minigame is passed, the string Space.name+'+' charachter is added to visited as well as Space.name.
     */
    class Area : Space {

        Area(string outputDesc, string name) : base(outputDesc, name) {

        }

        public override string activate(Save state = null) {
            return outputDesc;
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
    struct AreaStage {

    }

    //Custom data structure of locations
    class Map {

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

        public Item(string itemname, byte id) {
            name = itemname;
            usageID = id;
        }
    }

    //Currency can be used either as a skill point/payment item
    class Currency : Item
    {
        public int amount = 0;

        public Currency(string itemname, byte id) : base(itemname, id) {

        }
    }

    //Accessories don't actually hold any use in specific
    class Accessory : Item
    {
        //Wether or not the item can be sold
        public bool canSell { get; set; }

        //The item's value
        public int value { get; set; }

        public Accessory(string itemname, byte id) : base(itemname, id) {
            
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
    class Doc : Tool
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

        public Weapon(string itemname, byte id) : base(itemname, id) {
            
        }
    }
}