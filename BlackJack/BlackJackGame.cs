using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class BlackJackGame : Game, IWalkAway
    {
        public BlackJackDealer Dealer { get; set; }

        public override void Play()     //override is required to implement an abstract method
        {
            Dealer = new BlackJackDealer();
            foreach (Player player in Players)
            {
                player.Hand = new List<Card>();
                player.Stay = false;
            }
            Dealer.Hand = new List<Card>();
            Dealer.Stay = false;
            Dealer.Deck = new Deck();
            Dealer.Deck.Shuffle();
            Console.WriteLine("\nPlace your bet!");

            foreach (Player player in Players)
            {
                int bet = Convert.ToInt32(Console.ReadLine());
                bool successfullyBet = player.Bet(bet);
                if (!successfullyBet)
                {
                    return;
                }
                Bets[player] = bet;
            }
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing...");
                foreach (Player player in Players)
                {
                    Console.Write("{0}: ", player.Name);
                    Dealer.Deal(player.Hand);
                    if (i == 1)
                    {
                        bool blackJack = BlackJackRules.CheckForBlackJack(player.Hand);
                        if (blackJack)
                        {
                            Console.WriteLine($"BlackJack! {player.Name} wins {Bets[player] * 1.5}!");
                            player.Balance += Convert.ToInt32((Bets[player] * 1.5) + Bets[player]);
                            Console.WriteLine($"Your current balance is: {player.Balance}");
                            Console.WriteLine("Do you want to play again?");
                            string answer = Console.ReadLine().ToLower();
                            if (answer == "yes" || answer == "yeah" || answer == "ya" || answer == "y")
                            {
                                player.isActivelyPlaying = true;
                                return;
                            }
                            else
                            {
                                player.isActivelyPlaying = false;
                                return;
                            }
                        }
                    }
                }
                Console.Write("Dealer: ");
                Dealer.Deal(Dealer.Hand);
                if (i == 1)
                {
                    bool blackJack = BlackJackRules.CheckForBlackJack(Dealer.Hand);
                    if (blackJack)
                    {
                        Console.WriteLine("Dealer has BlackJack! Everyone loses!");
                        foreach (KeyValuePair<Player, int> entry in Bets)
                        {
                            Dealer.Balance += entry.Value;
                        }
                        foreach (Player player in Players)
                        {
                            Console.WriteLine($"Your current balance is: {player.Balance}");
                            Console.WriteLine("Do you want to play again?");
                            string answer = Console.ReadLine().ToLower();
                            if (answer == "yes" || answer == "yeah" || answer == "ya" || answer == "y")
                            {
                                player.isActivelyPlaying = true;
                                return;
                            }
                            else
                            {
                                player.isActivelyPlaying = false;
                                return;
                            }
                        }
                    }
                }
            }
            foreach (Player player in Players)
            {
                while (!player.Stay)
                {
                    Console.WriteLine("Your cards are:");
                    foreach (Card card in player.Hand)
                    {
                        Console.WriteLine(card.ToString());
                    }
                    Console.WriteLine("\n\nHit or Stay?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "stay")
                    {
                        player.Stay = true;
                        break;
                    }
                    else if (answer == "hit")
                    {
                        Dealer.Deal(player.Hand);
                    }
                    bool busted = BlackJackRules.IsBusted(player.Hand);
                    if (busted)
                    {
                        Dealer.Balance += Bets[player];
                        Console.WriteLine($"{player.Name} busted! You lose your bet of {Bets[player]}.");
                        Console.WriteLine($"\nYour balance is now {player.Balance}.");
                        Console.WriteLine("\nDo you want to play again?");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "yes" || answer == "yeah" || answer == "ya" || answer == "y")
                        {
                            player.isActivelyPlaying = true;
                            return;
                        }
                        else
                        {
                            player.isActivelyPlaying = false;
                            return;
                        }
                    }
                }
            }
            Dealer.isBusted = BlackJackRules.IsBusted(Dealer.Hand);
            Dealer.Stay = BlackJackRules.ShouldDealerStay(Dealer.Hand);
            while (!Dealer.Stay && !Dealer.isBusted)
            {
                Console.WriteLine("Dealer is hitting...");
                Dealer.Deal(Dealer.Hand);
                Dealer.isBusted = BlackJackRules.IsBusted(Dealer.Hand);
                Dealer.Stay = BlackJackRules.ShouldDealerStay(Dealer.Hand);

                if (Dealer.Stay)
                {
                    Console.WriteLine("Dealer is staying.");
                }
                if (Dealer.isBusted)
                {
                    Console.WriteLine("Dealer busted!");
                    foreach (KeyValuePair<Player, int> entry in Bets)
                    {
                        Console.WriteLine("{0} won {1}!", entry.Key.Name, entry.Value);
                        Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2);
                        Dealer.Balance -= entry.Value;
                    }
                    foreach (Player player in Players)
                    {
                        Console.WriteLine($"\nYour current balance is: {player.Balance}.");
                        Console.WriteLine("\nDo you want to play again?");
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "yes" || answer == "yeah" || answer == "ya" || answer == "y")
                        {
                            player.isActivelyPlaying = true;
                            return;
                        }
                        else
                        {
                            player.isActivelyPlaying = false;
                            return;
                        }
                    }
                }
            }
            foreach (Player player in Players)      //it is possible to make bool or int or other types take on extra values
            {
                bool? playerWon = BlackJackRules.CompareHands(player.Hand, Dealer.Hand);     //  Allows bool to have a null value
                if (playerWon == null)
                {
                    Console.WriteLine("Push! No one wins.");
                    player.Balance += Bets[player];
                    Bets.Remove(player);
                }
                else if (playerWon == true)
                {
                    Console.WriteLine("{0} won {1}!", player.Name, Bets[player]);
                    player.Balance += (Bets[player] * 2);
                    Dealer.Balance -= Bets[player];
                }
                else
                {
                    Console.WriteLine("Dealer wins {0}!", Bets[player]);
                    Dealer.Balance += Bets[player];
                }

                Console.WriteLine($"\nYour current balance is: {player.Balance}");
                Console.WriteLine("\nDo you want to play again?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "ya" || answer == "yeah" || answer == "y")
                {
                    player.isActivelyPlaying = true;
                }
                else
                {
                    player.isActivelyPlaying = false;
                }
            }

            
        }
        public override void ListPlayers()
        {
            Console.WriteLine("Blackjack Players: ");
            base.ListPlayers();         //This is equivalent to the contained code for this method in Game
        }
        public void WalkAway(Player player)
        {
            throw new NotImplementedException();
        }

    }
}
