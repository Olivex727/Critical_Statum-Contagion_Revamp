using System;
using System.Collections.Generic;

namespace Game
{

    //=====PLAYER-DERIVED OBJECTS=====//

    //Class from which charachters/save states are derived from
    class Player
    {
        //Inventory
        protected List<Item> invent { get; set; }

        //The stats dictionary
        protected Dictionary<string, int> stats { get; set; }

        //The amount of money the player has/Skill points
        protected Currency points { get; set; }

        //Initialise the player object
        public Player() {
            invent = new List<Item>();
            stats = new Dictionary<string, int>();

            stats.Add("charisma", 1);
            stats.Add("piloting", 1);
            stats.Add("tech. knowlege", 1);
            stats.Add("attack", 1);
            stats.Add("intellect", 1);

            if (this is Save) {
                points = new Currency();
                points.init("credits", 0);
            }
        }

        //Add Something to Inventory
        public virtual void addToInvent(Item input) {
            if (!invent.Contains(input) && !(input is Currency)) {
                invent.Add(input);
            }
        }

        //Add Remove from Inventory
        public void removeFromInvent(string itemname){
            Item remove = null;
            foreach (Item item in invent) {
                if (item.name == itemname) {
                    remove = item;
                }
            }
            invent.Remove(remove);
        }

        //Update the stats dictionary
        public virtual void updateStats(bool justDisplay = false) {
            
        }

        //Finds a required component of the player/person, either in invent, stats or points
        public bool digForInfo() {
            return true;
        }

    }

    //Game's save states, location/id/inventory
    class Save : Player
    {
        //A list of each of the five team members
        public List<Person> team { get; set; }

        //Location tuple for player's current location
        private (Loc, Area) loc { get; set; }

        //Store of all visited areas, to ensure that new information happens each time
        private List<string> visited { get; set; }

        //Causes the player to execute what happens in a certain area/add to list of visited
        public void runArea() {

        }

        //Causes the player to change their location/add to list of visited
        public void moveLoc () {

        }
    }

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
    class Person : Player
    {
        //The name of the person
        public string name { get; set; }

        //The person's id
        public byte id { get; set; }

        //The level of the person
        public int lvl = 1;

        //Constructor
        public Person(string name, byte id) {

        }

        //Overrided add to inventory class
        public override void addToInvent(Item input) {
            if (id % input.usageID == 0 && !invent.Contains(input) && !(input is Currency)) {
                invent.Add(input);
            }
        }

        //Overried stats class
        public override void updateStats(bool justDisplay = false){

        }

    }

    //=====SPACE-DERIVED OBJECTS=====//

    //A space is the abstract class of a 'place' the player can exist in
    class Space
    {
        //Current output text for activate() method
        public string outputDesc { get; set; }

        //Actuates the events that unfold in each area
        public virtual void activate(Save state = null) {

        }
    }

    //The Loc class is the general map location
    class Loc : Space
    {
        //The area that occurs everytime the player enters the location
        public Area nullArea { get; set; }

        //The area that must be passed before getting to Loc
        public Area unlockArea { get; set; }

        //Wether or not the location can be accesed (if unlocked area is on last stage and terminate is set to true)
        public bool locked = true;

        //The areas that exist inside the Loc, not the nullArea or the unlockArea
        public List<Area> locAreas { get; set; }

        //If unlock_area is null, then the location can be accesed at any point
        public Loc(Area null_area, Area unlock_area = null) {

        }
    }

    //The area class is where specific dialouge events can occur
    class Area : Space
    {
        //The 'stage' of event the area can hold
        public int stage = 0;

        //Wether or not the area is accesible on the last stage
        public bool terminates { get; set; }

        //Wether or not the area is accesible anymore
        public bool terminated { get; set; }

        //An array of tupules of
        //(output description | 
        //The required item id in order to pass | and its amount |
        //The minigame that will be played if the reqiured item is available
        //The output given item id | and its amount)
        //Note that some of these items will most likely be empty strings/zeroes. This is the class where most game action occurs
        public (string, string, int, string, string, int)[] stages { get; set; }

        //Actuates the events that unfold in each area
        public override void activate(Save state = null){

        }

        //Updates the output description/stage
        public void updateStage(){

        }
    }

    //=====ITEM-DERIVED OBJECTS=====//

    //Abstract class from which all carryable items occur
    class Item
    {
        //The name of the item
        public string name { get; set; }

        //What Person can use the item
        public byte usageID { get; set; }

        public void init(string itemname, byte id) {
            name = itemname;
            usageID = id;
        }
    }

    //Currency can be used either as a skill point/payment item
    class Currency : Item
    {
        public int amount = 0;
    }

    //Accessories don't actually hold any use in specific
    class Accessory : Item
    {
        //Wether or not the item can be sold
        public bool canSell { get; set; }

        //The item's value
        public int value { get; set; }
    }

    //A tool is an item that can be used
    class Tool : Item
    {
        
    }

    //A document item, stored in inventory
    class Doc : Tool
    {
        //A string of all of the document's inner details
        private string documentContents { get; set; }

        //Uses the tool
        public string use()
        {
            string output = "";

            return output;
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
    }
}
namespace Minigames
{
    class GameObject
    {

    }
}