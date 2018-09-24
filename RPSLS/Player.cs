using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Player
    {
        // member variables
        private int handIndex;
        public string currentHand;
        public int score;
        public string input;
        public string name;

        // constructor
        public Player(string name)
        {
            this.name = name;
        }
        public Player()
        {

        }

        // methods
        public virtual string GetHand(List<string> handsList, Player currentPlayer)
        {
            do
            {
                Console.WriteLine(currentPlayer.name + " please enter which hand you would like :");
                Console.WriteLine("'1' = rock, '2' = paper, '3' = scissors, '4' = spock, '5' = lizard");
                input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5")
                {
                    handIndex = Int32.Parse(input);
                }
                    Console.WriteLine("\n");
                if (handIndex > 5 || handIndex < 1)
                {
                    Console.WriteLine("Please enter correct input!");
                    Console.WriteLine("\n");
                }
                

            } while (handIndex > 5 || handIndex < 1);

            switch (handIndex)
            {
                case 1:
                    currentHand = handsList[0];
                    break;
                case 2:
                    currentHand = handsList[1];
                    break;
                case 3:
                    currentHand = handsList[2];
                    break;
                case 4:
                    currentHand = handsList[3];
                    break;
                case 5:
                    currentHand = handsList[4];
                    break;
            }

            return currentHand;
        }

        public void UpdateScore()
        {
            score++;
        }

    }
}
