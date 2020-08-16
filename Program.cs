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

    /* class Hand
     {
         public List<Card> collection { get; set; }
         public int handValue()
         {
             int counter = 0;
             int sum = 0;
             foreach (Card card in collection)
             {
                 sum = sum + collection[counter].cardValue;
                 counter++;
             }
             return sum;
         }
     }*/
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
        static List<Card> Deal(List<Card> Hand, List<Card> Deck)
        {
            var dealt = new List<Card>();
            dealt = Hand;
            dealt.Add(Deck[0]);
            return dealt;

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
            // Shuffle The Deck

            for (int shuffleCount = deck.Count; shuffleCount > 1; shuffleCount--)
            {
                var randomNumberGenerator = new Random();
                var randomNumber = randomNumberGenerator.Next(51);
                var swapContainer = deck[shuffleCount - 1];
                deck[shuffleCount - 1] = deck[randomNumber];
                deck[randomNumber] = swapContainer;
            }

            var dealer = new List<Card>();
            var player = new List<Card>();
            dealer = Deal(dealer, deck);
            dealer = Deal(dealer, deck);



            Console.WriteLine($"{dealer[0].rank} of {dealer[0].suite}");
            Console.WriteLine($"{dealer[1].rank} of {dealer[1].suite}");
            //Console.WriteLine(dealer.handValue());











            /*/Checking Deck of Cards (To see if it is correct)
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






