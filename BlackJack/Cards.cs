using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BlackJack
{
    internal class Cards
    {

        public string Rank { get; set; }
        public string Suit { get; set; }
        
        public Cards(string rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

    }
}
