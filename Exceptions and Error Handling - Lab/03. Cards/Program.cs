using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cards = new List<Card>();

            string[] cardInfo = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cardInfo.Length; i++)
            {
                string face = cardInfo[i].Split().First();
                string suit = cardInfo[i].Split().Last();

                try
                {
                    cards.Add(CreateCard(face, suit));
                }
                catch (InvalidOperationException e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            
            Console.WriteLine(String.Join(" ", cards));
            

        }

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

        private static Card CreateCard(string face, string suit)
        {
            List<string> validFaces = new List<string>
            {
             "2", "3", "4", "5", "6", "7", "8", "9", "10", 
                "J", "Q", "K", "A"
            };

            List<string> validSuits = new List<string>
            {
              "S", "H", "D", "C"
            };

            if (!validFaces.Contains(face) || !validSuits.Contains(suit))
            {
                throw new InvalidOperationException("Invalid card!");
            }

            string suitSymbol = string.Empty;
            switch (suit)
            {
                case "S": suitSymbol = "\u2660"; break;
                case "H": suitSymbol = "\u2665"; break;
                case "D": suitSymbol = "\u2666"; break;
                case "C": suitSymbol = "\u2663"; break;
            }

            return new Card(face, suitSymbol);
        }
    }
}
