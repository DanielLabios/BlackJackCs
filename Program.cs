using System;
using System.Collections.Generic;

namespace BlackJackCs
{
    class Card
    {
        public string suite { get; set; }
        public string rank { get; set; }
        public int cardValue { get; set; }
    }

    class Program
    {
        static int GiveValue(int rank)
        {
            if (rank == 0)
            {
                return 11;
            }
            else if (rank >= 10)
            {
                return 10;
            }
            else
                return rank + 1;
        }
        static void Main(string[] args)
        {

            // Creating The Deck of Cards

            var deck = new List<Card>();
            for (var indexCount = 0; indexCount < 4; indexCount++)
            {
                var suite = new List<string> { "Diamonds", "Spades", "Hearts", "Clubs" };
                var rank = new List<string>();
                rank.Add("Ace");
                for (var counter = 2; counter <= 10; counter++)
                {
                    rank.Add($"{counter}");
                }
                rank.AddRange(new string[] { "Jack", "Queen", "King" });
                for (var suiteSetCounter = 0; suiteSetCounter < 13; suiteSetCounter++)
                {
                    var newCard = new Card()
                    {
                        suite = suite[indexCount],
                        rank = rank[suiteSetCounter],
                        cardValue = GiveValue(suiteSetCounter),
                    };
                    deck.Add(newCard);
                }
            }
            /* Checking Deck of Cards (To see if it is correct)
            int cardCount = 0;
            foreach (Card card in deck)
            {
                Console.WriteLine($"{deck[cardCount].rank} of {deck[cardCount].suite}");
                Console.WriteLine(deck[cardCount].cardValue);
                cardCount++;
            }*/






        }
    }
}
