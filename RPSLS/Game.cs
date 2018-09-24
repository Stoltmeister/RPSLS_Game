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
        private int handNumber;
        public Player playerOne;
        public Player playerTwo;
        public List<string> handsList = new List<string> { "rock", "paper", "scissors", "spock", "lizard" };

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
                Console.WriteLine("\n");
                playerOne = new Human();
                playerOne.name = playerOneName;
                playerTwo = new Computer();

            }
            else if (gameType == 2)
            {
                // 2 human player game setup
                string playerTwoName;
                Console.WriteLine("Player One please enter your name");
                playerOneName = Console.ReadLine();
                Console.WriteLine("\n");
                playerOne = new Human();
                playerOne.name = playerOneName;
                Console.WriteLine("Player Two please enter your name");
                playerTwoName = Console.ReadLine();
                Console.WriteLine("\n");
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
            currentRound++;
            // Game steps

            // main game loop
            while (gameRunning)
            {
                // Get Hands
                playerOne.GetHand(handsList, playerOne);
                playerTwo.GetHand(handsList, playerTwo);

                // Determine Round Winner
                handWinner = CompareHands(playerOne.currentHand, playerTwo.currentHand);
                UpdateScore(handWinner);

                IncrementRounds();
            }
        }


        public int StartGameMenu()
        {
            int userInput = 3;
            string userInputUnchecked;
            string rules = "The rules are the same as rock, paper, scissors with two extra moves: Lizard and Spock. \n" +
                "Rock beats: scissors and lizard, Paper beats: rock and spock, Scissors beats: paper and lizard, \n" +
                "Lizard beats: paper and spock, Spock beats: rock and scissors \n" +
                "The format is best of 5 (first to 3 round wins) \n";
            do
            {
                Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock! \n");
                Console.WriteLine(rules);
                Console.WriteLine("Please choose a game type : ");
                Console.WriteLine("Type '1' for Player vs. Computer or '2' for Player vs. Player (0 to quit)");
                userInputUnchecked = Console.ReadLine();
                if (userInputUnchecked == "0" || userInputUnchecked == "1" || userInputUnchecked == "2")
                {
                    userInput = Int32.Parse(userInputUnchecked);
                    if (userInput == 0)
                    {
                        Environment.Exit(0);
                    }
                    if (userInput != 1 && userInput != 2)
                    {
                        Console.WriteLine(userInput);
                        Console.WriteLine("Input not valid please try again! \n");
                    }
                }
                else {
                    Console.WriteLine("Incorrect input. Please try again (any key to continue) \n");
                    Console.ReadLine();
                }

            } while (userInput != 1 && userInput != 2);

            return userInput;
        }

        public int CompareHands(string playerOneHand, string playerTwoHand)
        {
            int playerOneIndex = handsList.IndexOf(playerOneHand);
            int playerTwoIndex = handsList.IndexOf(playerTwoHand);
            handNumber = (5 + playerOneIndex - playerTwoIndex) % 5;

            if (handNumber == 1 || handNumber == 3)
            {
                return 1;
            }
            else if (handNumber == 2 || handNumber == 4)
            {
                return 2;
            }
            else if (handNumber == 0)
            {
                return handNumber;
            }
            else
            {
                Console.WriteLine("error");
                Console.ReadLine();
                return (handNumber);
            }
        }

        public void displayCurrentRound()
        {
            Console.WriteLine("Round " + currentRound);
        }

        public void displayRoundResults(Player winner, Player loser, bool isTie)
        {
            if (isTie)
            {
                Console.WriteLine("Both players had hand " + playerOne.currentHand + " ");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine(winner.name + " won round " + currentRound + " with " + winner.currentHand + " over " + loser.currentHand);
                Console.WriteLine("\n");
            }
        }

        public void UpdateScore(int roundWinner)
        {
            if (roundWinner == 1)
            {
                playerOne.score++;
                displayRoundResults(playerOne, playerTwo, false);
            }
            else if (roundWinner == 2)
            {
                playerTwo.score++;
                displayRoundResults(playerTwo, playerOne, false);
            }
            else if (roundWinner == 0)
            {
                displayRoundResults(playerOne, playerTwo, true);

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
            int runAgain;
            if (playerOne.score >= roundsToWin)
            {
                gameRunning = !gameRunning;
                Console.WriteLine(playerOne.name + " is the winner! \n" +
                    "Press '1' to start a new game" +
                    " (push any other key to exit) \n");
                runAgain = Int32.Parse(Console.ReadLine());
                if (runAgain == 1)
                {
                    Game newGame = new Game();
                    newGame.RunGame();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else if (playerTwo.score >= roundsToWin)
            {
                gameRunning = !gameRunning;
                Console.WriteLine(playerTwo.name + " is the winner! \n" +
                    "Press '1' to start a new game" +
                    " (push any other number to exit) \n");
                runAgain = Int32.Parse(Console.ReadLine());
                if (runAgain == 1)
                {
                    Game newGame = new Game();
                    newGame.RunGame();
                }
                else
                {
                    Environment.Exit(0);
                }
            }

        }

    }
}
