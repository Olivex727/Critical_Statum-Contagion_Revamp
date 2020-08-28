using System;
using System.Collections.Generic;

namespace Game {

    //=====PLAYER-DERIVED OBJECTS=====//

    //Class from which charachters/save states are derived from
    class Player
    {
        //Inventory
        private List<Item> invent { get; set; }

        //The stats dictionary
        private Dictionary<string, int> stats { get; set; }

        //The amount of money the player has/Skill points
        private Currency points { get; set; }

        //Add Something to Inventory
        public virtual void addToInvent() {
            Console.WriteLine("x");
            invent = new List<Item>();
            invent.Add(new Tool());
            Console.WriteLine(invent.ToString());
        }

        //Add Remove from Inventory
        public void removeFromInvent(){

        }

        //Update the stats dictionary
        public virtual void updateStats() {

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
        public int lvl { get; set; }

        //Overrided add to inventory class
        public override void addToInvent() {

        }

        //Overried stats class
        public override void updateStats(){

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
    }

    //Currency can be used either as a skill point/payment item
    class Currency : Item
    {
        public int amount { get; set; }
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