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
            do
            {
                Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock!");
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

            Console.WriteLine("test complete! type");
            Console.ReadLine();
        }
    }
}
