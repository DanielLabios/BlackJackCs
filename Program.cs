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
        public List<Card> collection = new List<Card>();
        public int deckPosition { get; set; }
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
        static int handValue(List<Card> player)
        {
            int counter = 0;
            int sum = 0;
            foreach (Card card in player)
            {
                sum = sum + player[counter].cardValue;
                counter++;
            }
            return sum;
        }
        static bool CheckIfHandValueIsGood(List<Card> player2)
        {
            int sum = handValue(player2);
            if (sum > 21)
            {
                return false;
            }
            else
                return true;
        }
        static void ReadHand(List<Card> player3)
        {
            int handCount = 0;
            foreach (Card card in player3)
            {
                Console.WriteLine($"{player3[handCount].rank} of {player3[handCount].suite}");
                handCount++;
            }
            Console.WriteLine(handValue(player3));

        }

        static void Main(string[] args)
        {
            // Creating The Deck of Cards
            var deck = new Deck();
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
                    deck.collection.Add(newCard);
                }
            }
            deck.deckPosition = 0;
            // Shuffle The Deck

            for (int shuffleCount = deck.collection.Count; shuffleCount > 1; shuffleCount--)
            {
                var randomNumberGenerator = new Random();
                var randomNumber = randomNumberGenerator.Next(51);
                var swapContainer = deck.collection[shuffleCount - 1];
                deck.collection[shuffleCount - 1] = deck.collection[randomNumber];
                deck.collection[randomNumber] = swapContainer;
            }

            var dealer = new List<Card>();
            var player = new List<Card>();
            dealer.Add(deck.collection[deck.deckPosition]);
            deck.deckPosition++;
            dealer.Add(deck.collection[deck.deckPosition]);
            deck.deckPosition++;
            player.Add(deck.collection[deck.deckPosition]);
            deck.deckPosition++;
            player.Add(deck.collection[deck.deckPosition]);
            deck.deckPosition++;
            ReadHand(player);
            bool lossCheck = CheckIfHandValueIsGood(player);

            string hitStay = "Hit";
            while (lossCheck == true && hitStay == "Hit")
            {
                Console.WriteLine("Hit or Stay?");
                hitStay = Console.ReadLine();

                while (hitStay != "Hit" && hitStay != "Stay")
                {
                    Console.WriteLine("Error, input was entered wrong.");
                    Console.WriteLine("Hit or Stay?");
                    hitStay = Console.ReadLine();
                }
                if (hitStay == "Hit")
                {
                    player.Add(deck.collection[deck.deckPosition]);
                    deck.deckPosition++;
                    ReadHand(player);
                    lossCheck = CheckIfHandValueIsGood(player);
                }

            }
            Console.WriteLine("dealer's hand:");
            ReadHand(dealer);


            // sorry game over












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






