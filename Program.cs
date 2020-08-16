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
    class Deck
    {
        public List<Card> collection { get; set; }
        public int deckCounter { get; set; }
    }

    class Hand
    {
        public List<Card> cardsInHand { get; set; }
        public int handValue { get; set; }
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

        static int Deal(Hand Player, Deck inPlay, int numberOfCards)
        {
            int counter = 0;
            while (counter < numberOfCards)
            {
                Player.cardsInHand.Add(inPlay.collection[inPlay.deckCounter + counter]);
                counter++;
            }
            return inPlay.deckCounter = inPlay.deckCounter + numberOfCards;
        }

        static void Main(string[] args)
        {

            // Creating The Deck of Cards + Player + Dealer

            var deck = new List<Card>();
            var suite = new List<string> { "Diamonds", "Spades", "Hearts", "Clubs" };
            var rank = new List<string>();
            rank.Add("Ace");
            for (var counter = 2; counter <= 10; counter++)
            {
                rank.Add($"{counter}");
            }
            rank.AddRange(new string[] { "Jack", "Queen", "King" });

            for (var indexCount = 0; indexCount < 4; indexCount++)
            {
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

            var player = new Hand();
            var dealer = new Hand();

            // Shuffle The Deck

            for (int shuffleCount = deck.Count; shuffleCount > 1; shuffleCount--)
            {
                var randomNumberGenerator = new Random();
                var randomNumber = randomNumberGenerator.Next(51);
                var swapContainer = deck[shuffleCount - 1];
                deck[shuffleCount - 1] = deck[randomNumber];
                deck[randomNumber] = swapContainer;
            }
            Deal(player, deck, 2);



            /*/Checking Deck of Cards To see if it is correct
            int cardCount = 0;
            foreach (Card card in deck)
            {
                Console.WriteLine($"{deck[cardCount].rank} of {deck[cardCount].suite}");
                Console.WriteLine(deck[cardCount].cardValue);
                cardCount++;*/
        }






    }
}

