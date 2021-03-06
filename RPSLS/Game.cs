﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Game
    {
        // member variables
        public int roundsToWin;
        public int currentRound;
        public bool gameRunning;
        public string playerOneName;
        private int handWinner;
        private int handNumber;
        public Player playerOne;
        public Player playerTwo;
        public List<string> handsList;

        // contructor
        public Game()
        {
            roundsToWin = 3;
            gameRunning = true;
            handsList = new List<string> { "rock", "paper", "scissors", "spock", "lizard" };
        }

        // methods

        public void SetPlayers(int gameType)
        {
            if (gameType == 1)
            {
                // single player vs computer game setup
                Console.WriteLine("Player One please enter your name: \n");
                playerOneName = Console.ReadLine();
                Console.WriteLine("\n");
                playerOne = new Human(playerOneName);
                playerTwo = new Computer();

            }
            else if (gameType == 2)
            {
                // 2 human player game setup
                string playerTwoName;
                Console.WriteLine("Player One please enter your name: \n");
                playerOneName = Console.ReadLine();
                Console.WriteLine("\n");
                playerOne = new Human(playerOneName);                
                Console.WriteLine("Player Two please enter your name: \n");
                playerTwoName = Console.ReadLine();
                Console.WriteLine("\n");
                playerTwo = new Human(playerTwoName);
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

                try
                {
                    userInput = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input! Please try again (any key to continue) \n");
                    Console.ReadLine();
                    return StartGameMenu();
                }
                if (userInput == 0 || userInput == 1 || userInput == 2)
                {
                    if (userInput == 0)
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input. Please try again (any key to continue) \n");
                    Console.ReadLine();
                }

            } while (userInput != 1 && userInput != 2);
            Console.WriteLine("\n");
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

        public void DisplayCurrentRound()
        {
            Console.WriteLine("Round " + currentRound);
        }

        public void DisplayRoundResults(Player winner, Player loser, bool isTie)
        {
            if (isTie)
            {
                Console.WriteLine("Both players had hand " + playerOne.currentHand + " \n");
            }
            else
            {
                Console.WriteLine(winner.name + " won round " + currentRound + " with " + winner.currentHand + " over " + loser.currentHand + " \n");
            }
        }

        public void UpdateScore(int roundWinner)
        {
            if (roundWinner == 1)
            {
                playerOne.score++;
                DisplayRoundResults(playerOne, playerTwo, false);
            }
            else if (roundWinner == 2)
            {
                playerTwo.score++;
                DisplayRoundResults(playerTwo, playerOne, false);
            }
            else if (roundWinner == 0)
            {
                DisplayRoundResults(playerOne, playerTwo, true);

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
                Console.WriteLine(playerOne.name + " is the winner! \n" +
                    "Press '1' to start a new game" +
                    " (push any other key to exit) \n");
                NewGame();
            }
            else if (playerTwo.score >= roundsToWin)
            {
                gameRunning = !gameRunning;
                Console.WriteLine(playerTwo.name + " is the winner! \n" +
                    "Press '1' to start a new game" +
                    " (push any other number to exit) \n");
                NewGame();
            }
        }

        private void NewGame()
        {
            string input = Console.ReadLine();
            if (input == "1")
            {
                RunGame();
            }
        }

    }
}

