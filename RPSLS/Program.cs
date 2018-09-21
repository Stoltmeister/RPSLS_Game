using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Program
    {
        static void Main(string[] args)
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

            
            if (userInput == 1)
            {
                // creating and starting the game
                Game playerVsComputer = new Game();
                playerVsComputer.SetPlayers(userInput);

                // Game steps
                playerVsComputer.playerOne.GetHand(playerVsComputer.handsList);
                playerVsComputer.playerTwo.GetHand(playerVsComputer.handsList);
                playerVsComputer.CompareHands(playerVsComputer.playerOne.currentHand, playerVsComputer.playerOne.currentHand);

            }
            else
            {
                // creating and starting the game
                Game humanGame = new Game();
                humanGame.SetPlayers(userInput);

            }
        }
    }
}
