using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace wakarimasen
{

    class Character
    {

        private static SortedDictionary<int, Character> characters = new SortedDictionary<int, Character>();

        private string myName = "Unnamed";
        private int mySpriteID = -1;
        private double[] myPosition;

        // Properties for the very possible occasions when individual variables need changing. 
        public string name
        {
            get { return myName; }
            set { myName = value; }
        }
        public int spriteID
        {
            get { return mySpriteID; }
            set { mySpriteID = value; }
        }
        public double[] position
        {
            get { return myPosition; }
            set { myPosition = value; }
        }

        // Constructor.
        public Character(string name, int spriteID, double locationX, double locationY)
        {
            myName = name;
            mySpriteID = spriteID;
            myPosition = new double[2]{locationX, locationY};

            characters.Add(characters.Count, this);
        }

        public static Character getCharacter(int ID)
        {
            return characters[ID];
        }
        public static Character getCharacter(string name)
        {
            return null; // To be completed. The null is meaningless :0:0
        }

    }

}
