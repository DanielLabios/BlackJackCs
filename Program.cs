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
        static int handValue(List<Card> player5)
        {
            int counter = 0;
            int sum = 0;
            foreach (Card card in player5)
            {
                sum = sum + player5[counter].cardValue;
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
            Console.WriteLine($"--------{player3}'s hand---------");
            foreach (Card card in player3)
            {
                Console.WriteLine($"{handCount + 1}. {player3[handCount].rank} of {player3[handCount].suite}");
                handCount++;
            }
            Console.WriteLine($"Score: {handValue(player3)}");
            Console.WriteLine("------------------------------");
            System.Threading.Thread.Sleep(2500);
        }
        static void PlayIntro()
        {
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("                                               ");
            Console.WriteLine("            Let's Play BlackJack               ");
            Console.WriteLine("                                               ");
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||");
            System.Threading.Thread.Sleep(2500);
            Console.WriteLine("Initializing.....");
            System.Threading.Thread.Sleep(2500);
            Console.Write("Player 1 is Ready,");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("   GoodLuck!");
            System.Threading.Thread.Sleep(1000);
        }
        static void PlayShuffleSounds()
        {
            Console.Write("SSSCCHHHHHHHHPP!! SSSCCHHHHHHHHPPP!!");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("   Deck has been shuffled.");
            System.Threading.Thread.Sleep(1000);
        }
        static void PlayInitialDeal()
        {
            Console.Write("Flip!, ");
            System.Threading.Thread.Sleep(500);
            Console.Write("Flip!, ");
            System.Threading.Thread.Sleep(500);
            Console.Write("Flip!, ");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Flip!, ");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Cards have been dealt.");
            System.Threading.Thread.Sleep(2500);
        }
        static void DisplayScores(int wins, int loses)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("----------Score----------");
            Console.WriteLine($"Player Wins: {wins}");
            Console.WriteLine($"Dealer Wins: {loses}");
            System.Threading.Thread.Sleep(2500);
        }
        static void PlaySendOff(int wins, int loses)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("------Final Score------");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Player Wins: {wins}");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Dealer Wins: {loses}");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("-----------------------");
            Console.WriteLine("Thank You For Playing!!");
            Console.WriteLine("-----------------------");
            System.Threading.Thread.Sleep(2500);
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

            // Creating the Player, Dealer, & Important Tracker Variables

            var dealer = new List<Card>();
            var player = new List<Card>();
            int playerWin = 0;
            int dealerWin = 0;
            bool lossCheck;
            string hitStay;
            string keepPlaying = "yes";

            // Starting the Game

            PlayIntro();
            while (keepPlaying == "yes")
            {

                // Shuffle The Deck

                PlayShuffleSounds();
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
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("hit or stay?");
                        hitStay = Console.ReadLine();
                    }
                    if (hitStay == "hit")
                    {
                        Console.WriteLine("Flip! New Card!");
                        System.Threading.Thread.Sleep(1000);
                        player.Add(deck.collection[deck.deckPosition]);
                        deck.deckPosition++;
                        ReadHand(player);
                        lossCheck = CheckIfHandValueIsGood(player);
                    }
                }

                // Dealer Reveals Hand

                if (lossCheck == true)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Dealer reveals his hand!!");
                    System.Threading.Thread.Sleep(1000);
                    ReadHand(dealer);
                    lossCheck = CheckIfHandValueIsGood(dealer);
                }

                // Dealer Hit/Stay Loop

                hitStay = "hit";
                while (lossCheck == true && hitStay == "hit")
                {
                    if (handValue(dealer) < 17 && handValue(dealer) <= handValue(player))
                    {
                        Console.Write("Flip!");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("   Dealer gives himself another card.");
                        System.Threading.Thread.Sleep(1000);

                        dealer.Add(deck.collection[deck.deckPosition]);
                        deck.deckPosition++;
                        ReadHand(dealer);
                        lossCheck = CheckIfHandValueIsGood(dealer);
                    }
                    else
                        hitStay = "stay";
                }

                // Win Determinator

                if (handValue(player) > 21)
                {
                    Console.WriteLine("Oh no! Your score is more than 21!");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("You Lose...");
                    dealerWin++;
                }
                else if (handValue(player) <= 21 && handValue(player) <= handValue(dealer) && handValue(dealer) <= 21)
                {
                    Console.WriteLine("Oh no! The Dealer has the better hand...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("You Lose...");
                    dealerWin++;
                }
                else if (handValue(player) > handValue(dealer))
                {
                    Console.WriteLine("You have the better hand!");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("You beat the Dealer!");
                    playerWin++;
                }
                else if (handValue(dealer) > 21)
                {
                    Console.WriteLine("Oh no! The Dealer went over 21!");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("You beat the Dealer!");
                    playerWin++;
                }

                // Play Again Prompt

                DisplayScores(playerWin, dealerWin);
                Console.WriteLine("Play again? yes/no");
                keepPlaying = Console.ReadLine();
                while (keepPlaying != "yes" && keepPlaying != "no")
                {
                    Console.WriteLine("Error, input was entered wrong.");
                    System.Threading.Thread.Sleep(2500);
                    Console.WriteLine("Play again? yes/no");
                    keepPlaying = Console.ReadLine();
                }

                // Reset Cards

                deck.deckPosition = 0;
                player.Clear();
                dealer.Clear();
            }

            // Send Off

            PlaySendOff(playerWin, dealerWin);












            /*/Checking Deck of Cards (To see if it is correct)
            int cardCount = 0;
            foreach (Card card in deck.collection)
            {
                Console.WriteLine($"{deck.collection[cardCount].rank} of {deck.collection[cardCount].suite}");
                Console.WriteLine(deck.collection[cardCount].cardValue);
                cardCount++;
                }*/
        }
    }
}






