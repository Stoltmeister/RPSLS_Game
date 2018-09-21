using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class ComputerPlayer : Player
    {
        // member variables

        // constructor
        public ComputerPlayer()
            : base("Computer")
        {

        }

        // methods
        public override string GetHand(List<string> handsList)
        {
            Random randomNumber = new Random();
            currentHand = handsList[randomNumber.Next(handsList.Count + 1)];
            return currentHand;
        }
    }
}
