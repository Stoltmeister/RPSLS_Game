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
        private string hand;
        private int score;
        private string name;
        private bool isWinning;
        private bool isHuman;

        // constructor
        public Player(bool isHuman, string name)
        {
            this.isHuman = isHuman;
            this.name = name;
        }

        // methods
        private string GetHand(List<string> handsList)
        {
            do
            {
                Console.WriteLine("Enter which hand you would like :");
                Console.WriteLine("'1' = rock, '2' = paper, '3' = scissors, '4' = lizard, '5' = spock");
                handIndex = Int32.Parse(Console.ReadLine());

            } while (handIndex > 5 || handIndex < 1);

            switch (handIndex)
            {
                case 1:
                    hand = handsList[1];
                    break;
                case 2:
                    hand = handsList[2];
                    break;
                case 3:
                    hand = handsList[3];
                    break;
                case 4:
                    hand = handsList[4];
                    break;
                case 5:
                    hand = handsList[5];
                    break;

            }
            
            return hand;
        }


    }
}