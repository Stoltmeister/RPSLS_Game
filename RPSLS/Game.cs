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
        public bool gameRunning = true;
        public string playerOneName;
        private int handWinner;
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
                playerOne = new Human();
                playerTwo = new Computer();

            }
            else if (gameType == 2)
            {
                // 2 human player game setup
                string playerTwoName;
                Console.WriteLine("Player One please enter your name");
                playerOneName = Console.ReadLine();
                playerOne = new Human();
                playerOne.name = playerOneName;
                Console.WriteLine("Player Two please enter your name");
                playerTwoName = Console.ReadLine();
                playerTwo = new Human();
                playerTwo.name = playerTwoName;
            }
            else
            {
                Console.WriteLine("Error input incorrect");
                Console.ReadLine();
            }
        }

        public void RunGame()
        {            
            SetPlayers(StartGameMenu());

            // Game steps

            // main game loop
            while (gameRunning)
            {
                // Get Hands
               playerOne.GetHand(handsList);
               playerTwo.GetHand(handsList);

                // Determine Round Winner
                handWinner = CompareHands(playerOne.currentHand, playerTwo.currentHand);
                UpdateScore(handWinner);

                IncrementRounds();
            }
        }
    

    public int StartGameMenu()
    {
        int userInput;
        string rules = "The rules are the same as rock, paper, scissors with two extra moves: Lizard and Spock. /n" +
            "Rock beats: scissors and lizard, Paper beats: rock and spock, Scissors beats: paper and lizard, /n" +
            "Lizard beats: paper and spock, Spock beats: rock and scissors";
        do
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock!");
            Console.WriteLine(rules);
            Console.WriteLine("Please choose a game type : ");
            Console.WriteLine("Type '1' for Player vs. Computer or '2' for Player vs. Player (0 to quit)");
            userInput = Convert.ToInt32(Console.ReadLine());

            if (userInput == 0)
            {
                Environment.Exit(0);
            }
            if (userInput != 1 && userInput != 2)
            {
                Console.WriteLine(userInput);
                Console.WriteLine("Input not valid please try again!");
            }
        } while (userInput != 1 && userInput != 2);

        return userInput;
    }

    public int CompareHands(string playerOneHand, string playerTwoHand)
    {
        int playerOne = 1;
        int playerTwo = 2;
        int tie = 3;
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
                else
                {
                    return tie;
                }
            case "paper":
                if (playerTwoHand == "scissors" || playerTwoHand == "lizard")
                {
                    return playerTwo;
                }
                else if (playerTwoHand == "spock" || playerTwoHand == "rock")
                {
                    return playerOne;
                }
                else
                {
                    return tie;
                }
            case "scissors":
                if (playerTwoHand == "spock" || playerTwoHand == "rock")
                {
                    return playerTwo;
                }
                else if (playerTwoHand == "lizard" || playerTwoHand == "paper")
                {
                    return playerOne;
                }
                else
                {
                    return tie;
                }
            case "lizard":
                if (playerTwoHand == "rock" || playerTwoHand == "scissors")
                {
                    return playerTwo;
                }
                else if (playerTwoHand == "spock" || playerTwoHand == "scissors")
                {
                    return playerOne;
                }
                else
                {
                    return tie;
                }
            case "spock":
                if (playerTwoHand == "paper" || playerTwoHand == "lizard")
                {
                    return playerTwo;
                }
                else if (playerTwoHand == "rock" || playerTwoHand == "scissors")
                {
                    return playerOne;
                }
                else
                {
                    return tie;
                }
            default:
                Console.WriteLine("Case not found check inputs");
                return 0;
        }

    }

    public void displayCurrentRound()
    {
        Console.WriteLine("Round " + currentRound);
    }

    public void displayRoundResults(Player winner, Player loser)
    {
            Console.WriteLine(winner.name + " won round " + currentRound + "with " + winner.currentHand + " over " + loser.currentHand);
            Console.WriteLine()
    }

    public void UpdateScore(int roundWinner)
    {
        if (roundWinner == 1)
        {
            playerOne.score++;
                displayRoundResults(playerOne, playerTwo);
        }
        else if (roundWinner == 2)
        {
            playerTwo.score++;
        }
        else
        {
            Console.WriteLine("error");
            Console.ReadLine();
        }
    }
    public void IncrementRounds()
    {
        currentRound++;

        if (playerOne.score >= roundsToWin)
        {
            gameRunning = !gameRunning;
            playerOne.roundsWon++;
        }


    }

}
}
