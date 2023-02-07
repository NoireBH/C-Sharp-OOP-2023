using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Cards
{
    public class Card
    {
        public string Face { get; set; }
        public string Suit { get; set; }

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }
       
        public override string ToString()
        => $"[{this.Face}{this.Suit}]";
    }
}
