using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Human : Player
    {
        // member variables

        // constructor
        public Human(string name) 
        {
            this.name = name;
        }
        
        // methods

        // override the getHand when 2 players to hide the previous choice from the next player
        // maybe just clear the text off the console instead?
    }
}
