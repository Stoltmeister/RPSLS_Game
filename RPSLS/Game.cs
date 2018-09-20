using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Game
    {
        // member variables
        private int roundsToWin;
        public int currentRound;
        List<string> handsList = new List<string>();        
        Player playerOne = new Player();
        Player playerTwo = new Player();


        // contructor
        public Game()
        {
            handsList.Add("rock");
            handsList.Add("paper");
            handsList.Add("scissors");
            handsList.Add("lizard");
            handsList.Add("spock");

        }


        // methods

    }
}
