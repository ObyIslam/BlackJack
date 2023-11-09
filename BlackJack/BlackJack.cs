using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class BlackJack
    {

        public string Card { get; set; }
        public int Score { get; set; }

        public BlackJack(string card)
        {
            Card = card;
        }
        
        public int CalculateScore()
        {
            if (Card.Contains("Ace"))
            {
                if (Score > 17)//Ace logic to determine whether value is a 1 or 11
                {
                    return Score + 1;
                }
                return Score + 11;
            }
            else if (Card.Contains("King") || Card.Contains("Queen") || Card.Contains("Jack"))
            {
                return Score + 10;
            }
            else if (int.TryParse(Card.Split(' ')[0], out int value))
            {
                return Score + value;
            }
            return Score;

        }

    }
}
