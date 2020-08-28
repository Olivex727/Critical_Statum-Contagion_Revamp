namespace Game {

    //=====PLAYER-DERIVED OBJECTS=====//

    //Abstract class from which charachters/save states are derived from
    abstract class Player {

    }

    //Game's save states, location/id/inventory
    class Save : Player {

    }

    //One of the five people available to choose
    class Person : Player {
        public string name { get; set; }
    }

    //=====SPACE-DERIVED OBJECTS=====//

    //A space is the abstract class of a 'place' the player can exist in
    abstract class Space {

    }

    //The Loc class is the general map location
    class Loc : Space {

    }

    //The area class is where specific dialouge events can occur
    class Area : Space {

    }

    //=====ITEM-DERIVED OBJECTS=====//

    //Abstract class from which all carryable items occur
    abstract class Item {

    }

    //A tool is an item that can be used
    class Tool : Item {

        //Uses the tool
        public string use() {
            string output = "";

            return output;
        }
    }

    //Currency can be used either as a skill point/payment item
    class Currency : Item {

    }

    //Accessories don't actually hold any use apart from being bought and sold
    class Accessory : Item {

    }
}