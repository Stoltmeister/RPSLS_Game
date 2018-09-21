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
        public int roundsToWin = 3;
        public int currentRound;
        private bool gameRunning = true;
        public string playerOneName;
        public Player playerOne;
        public Player playerTwo;
        public List<string> handsList = new List<string> { "rock", "paper", "scissors", "lizard", "spock" };

        // contructor
        public Game()
        {
            
        }

        // methods

        public void SetPlayers(int gameType)
        {
            if (gameType == 1)
            {
                // single player vs computer game setup
                Console.WriteLine("Player One please enter your name");
                playerOneName = Console.ReadLine();
                playerOne = new HumanPlayer();
                playerOne.name = playerOneName;
                playerTwo = new ComputerPlayer();

            }
            else if (gameType == 2)
            {    
                // 2 human player game setup
                string playerTwoName;
                Console.WriteLine("Player One please enter your name");
                playerOneName = Console.ReadLine();
                playerOne = new HumanPlayer();
                playerOne.name = playerOneName;
                Console.WriteLine("Player Two please enter your name");
                playerTwoName = Console.ReadLine();
                playerTwo = new HumanPlayer();
                playerTwo.name = playerTwoName;
            }
            else
            {
                Console.WriteLine("Error input incorrect");
                Console.ReadLine();
            }
        }
        public int CompareHands(string playerOneHand, string playerTwoHand)
        {
            int playerOne = 1;
            int playerTwo = 2;
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
                    return 0;

            }
            return 0;
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
        private bool IncrementRounds()
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
