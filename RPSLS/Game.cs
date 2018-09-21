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
        private bool gameRunning = true;
        Player playerOne = new Player("Player One");
        Player playerTwo = new Player("Player Two");
        List<string> handsList = new List<string>();



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
        private string CompareHands(string playerOneHand, string playerTwoHand)
        {
            string playerOne = "playerOne";
            string playerTwo = "playerTwo";
            switch (playerOneHand)
            {
                case "rock":
                    if (playerTwoHand == "paper" || playerTwoHand == "spock")
                    {
                        return playerTwo;
                    }
                    else if (playerTwoHand == "lizard" || playerTwoHand == "scissors")
                    {
                        return playerOne;
                    }
                    break;
                case "paper":
                    if (playerTwoHand == "scissors" || playerTwoHand == "lizard")
                    {
                        return playerTwo;
                    }
                    else if (playerTwoHand == "spock" || playerTwoHand == "rock")
                    {
                        return playerOne;
                    }
                    break;
                case "scissors":
                    if (playerTwoHand == "spock" || playerTwoHand == "rock")
                    {
                        return playerTwo;
                    }
                    else if (playerTwoHand == "lizard" || playerTwoHand == "paper")
                    {
                        return playerOne;
                    }
                    break;
                case "lizard":
                    if (playerTwoHand == "rock" || playerTwoHand == "scissors")
                    {
                        return playerTwo;
                    }
                    else if (playerTwoHand == "spock" || playerTwoHand == "scissors")
                    {
                        return playerOne;
                    }
                    break;
                case "spock":
                    if (playerTwoHand == "paper" || playerTwoHand == "lizard")
                    {
                        return playerTwo;
                    }
                    else if (playerTwoHand == "rock" || playerTwoHand == "scissors")
                    {
                        return playerOne;
                    }
                    break;
                default:
                    Console.WriteLine("Case not found check inputs");
                    return null;

            }
            return null;
        }

        private void UpdateScore(string roundWinner)
        {
            if (roundWinner == "playerOne")
            {
                playerOne.score++;
            }
            else if (roundWinner == "playerTwo")
            {
                playerTwo.score++;
            }
        }
        private bool IncrementRounds(int roundsToWin)
        {
            currentRound++;

            if (currentRound >= roundsToWin * 2)
            {
                return !gameRunning;
            }

            return gameRunning;

        }

    }
}
