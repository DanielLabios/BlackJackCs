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

            // Creating the Player & Dealer

            var dealer = new List<Card>();
            var player = new List<Card>();
            int playerWin = 0;
            int dealerWin = 0;
            bool lossCheck;
            string hitStay;
            string keepPlaying = "yes";

            // Game BlackJack Play Again Loop

            while (keepPlaying == "yes")
            {

                // Shuffle The Deck

                for (int shuffleCount = deck.collection.Count; shuffleCount > 1; shuffleCount--)
                {
                    var randomNumberGenerator = new Random();
                    var randomNumber = randomNumberGenerator.Next(51);
                    var swapContainer = deck.collection[shuffleCount - 1];
                    deck.collection[shuffleCount - 1] = deck.collection[randomNumber];
                    deck.collection[randomNumber] = swapContainer;
                }

                // Deal 2 Cards to Dealer, then Deal 2 Cards to Player

                dealer.Add(deck.collection[deck.deckPosition]);
                deck.deckPosition++;
                dealer.Add(deck.collection[deck.deckPosition]);
                deck.deckPosition++;
                player.Add(deck.collection[deck.deckPosition]);
                deck.deckPosition++;
                player.Add(deck.collection[deck.deckPosition]);
                deck.deckPosition++;
                ReadHand(player);

                lossCheck = CheckIfHandValueIsGood(player);

                // Player Hit/Stay Loop

                hitStay = "hit";
                while (lossCheck == true && hitStay == "hit")
                {
                    Console.WriteLine("hit or stay?");
                    hitStay = Console.ReadLine();

                    while (hitStay != "hit" && hitStay != "stay")
                    {
                        Console.WriteLine("Error, input was entered wrong.");
                        Console.WriteLine("hit or stay?");
                        hitStay = Console.ReadLine();
                    }
                    if (hitStay == "hit")
                    {
                        player.Add(deck.collection[deck.deckPosition]);
                        deck.deckPosition++;
                        ReadHand(player);
                        lossCheck = CheckIfHandValueIsGood(player);
                    }

                }

                // Dealer Reveals Hand

                if (lossCheck == true)
                {
                    Console.WriteLine("dealer's hand:");
                    ReadHand(dealer);
                    lossCheck = CheckIfHandValueIsGood(dealer);
                }

                // Dealer Hit/Stay Loop

                hitStay = "Hit";
                while (lossCheck == true && hitStay == "Hit")
                {
                    if (handValue(dealer) < 17)
                    {
                        dealer.Add(deck.collection[deck.deckPosition]);
                        deck.deckPosition++;
                        ReadHand(dealer);
                        lossCheck = CheckIfHandValueIsGood(dealer);
                    }
                    else
                        hitStay = "Stay";
                }

                // Win Determinator

                if (handValue(player) > 21)
                {
                    Console.WriteLine("No Bueno, you lose");
                    dealerWin++;
                }
                else if (handValue(player) < 21 && handValue(player) < handValue(dealer) && handValue(dealer) <= 21)
                {
                    Console.WriteLine("No Bueno, you lose2");
                    dealerWin++;
                }
                else if (handValue(player) > handValue(dealer))
                {

                    Console.WriteLine("Congratulations! You Win!");
                    playerWin++;
                }
                else if (handValue(dealer) > 21)
                {

                    Console.WriteLine("Congratz! You win!");
                    playerWin++;
                }


                Console.WriteLine("Play again? yes/no");
                keepPlaying = Console.ReadLine();
                while (keepPlaying != "yes" && keepPlaying != "no")
                {
                    Console.WriteLine("Error, input was entered wrong.");
                    Console.WriteLine("Play again? yes/no");
                    keepPlaying = Console.ReadLine();
                }
                deck.deckPosition = 0;
                player.Clear();
                dealer.Clear();

                Console.WriteLine($"Player Wins: {playerWin}");
                Console.WriteLine($"Dealer Wins: {dealerWin}");

            }


            Console.WriteLine("You reached the end!!");












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






