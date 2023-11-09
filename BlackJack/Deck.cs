using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        static Random random = new Random();

        public List<Cards> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Cards>();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };


            //creates 52 cards using the arrays
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Cards deck = new Cards(ranks[j], suits[i]);
                    Cards.Add(deck);
                }

            }

        }

        

        






    }
}
