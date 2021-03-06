﻿using System;
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
                Console.WriteLine("'1' = rock, '2' = paper, '3' = scissors, '4' = spock, '5' = lizard \n");
                input = Console.ReadLine();
                try
                {
                    handIndex = Int32.Parse(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input please try again! (Press any key to continue) \n");
                    Console.ReadLine();
                    GetHand(handsList, currentPlayer);
                }
                if (handIndex > 5 || handIndex < 1)
                {
                    Console.WriteLine("Please enter correct input! \n");
                }


            } while (handIndex > 5 || handIndex < 1);

            return(UpdateHand(handIndex, handsList));
        }

        public string UpdateHand(int handIndex, List<string> handsList)
        {
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
