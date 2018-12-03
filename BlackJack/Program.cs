using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grand Hotel and Casino. Let's start by telling me your name.");
            string playerName = Console.ReadLine();
            Console.WriteLine("\nAnd how much money did you bring today?");
            int bank = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\nHello, {playerName}. Would you like to join a game of Black Jack right now?");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya")
            {
                Player player = new Player(playerName, bank);
                Game game = new BlackJackGame();
                Console.WriteLine($"\nYour current balance is: {player.Balance}");
                game += player;
                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    game.Play();
                }
                game -= player;
                Console.WriteLine("\nThank you for playing!");
            }
            Console.WriteLine("\nFeel free to look around the casino. Bye for now.");
            Console.ReadLine();

        }
    }
        //              Lambda exprssions expose lists to a variety of methods to make life easier

        //int counter = 0;
        //foreach (Card card in deck.Cards)     This will count the aces in the deck but is bulky
        //{
        //    if (card.Face == Face.Ace)
        //    {
        //        counter++;
        //    }
        //}
        //                      This next line does the same as the above 8 lines. This is a lambda method

        //int count = deck.Cards.Count(x => x.Face == Face.Ace);      // Count is a lambda method 
        //                                                     // => means where or foreach and x is our var

        //              Another example of a lambda method replacing several lines of code.
        //List<Card> newList = deck.Cards.Where(x => x.Face == Face.King).ToList();

        //List<int> numberList = new List<int>() { 1, 2, 3, 343, 234, 23 };
        //int sum = numberList.Sum();
        //int num1 = numberList.Max();            // All examples of ways to use an int list
        //int num3 = numberList.Min();
        //int sum2 = numberList.Where(x => x > 20).Sum();     // Where creates a new list so needs an output.



        //              Every data in C# is either a reference type or a value type each of which has different
        //                  behaviors.

        //              Difference between a class and a struct. A class is a reference type and a struct is
        //                  a value type which cannot be inherited.
        //              Struct types = int, bool, datetime


        ////          Enum - is one in a set of constants. It is easily created
        ///             it allows you to limit the options for values.
        ///             Enum also has an underlying integer value which can be set and pulled for use
        //public enum DaysOfTheWeek
        //{
        //    Monday,
        //    Tuesday,
        //    Wednesday,
        //    Thursday,
        //    Friday,
        //    Saturday,
        //    Sunday
        //}
        //DaysOfTheWeek day = DaysOfTheWeek.Monday;       // This uses the created enum
        //ConsoleColor color = ConsoleColor.Cyan;         // This is a preset enum



        //          Generics. This allows you to write classes or methods which are more generic or less specific.
        //          The more generic a thing is, the more re-usability it has for future code.
        //          The most common use of generics is through the list type.



        //                  The three pillars of OOP

        //          Inheritance is one of the three pillars of OOP
        //              It is the ability of a class to inherit other properties and methods from another class.
        //      DRY = Don't Repeat Yourself

        //          Polymorphism (Poly = many, morph = change) is the second of the pillars of OOP
        //              It is the ability of a class to morph into other types of classes
        //              This only works if The class being changed inherits its abilities from a parent class

        //          Abstract Class aka Base class is number 3. It is a class listed with abstract and is meant to 
        //              never be an object. It is only meant to be inherited from.

        //          Interfaces. Similar to an Abstract class. However, the .Net Framework only allows one class
        //              inheritance per class. You can't add more than one. The solution is Interfaces.



        //          Methods aka Functions aka Routines = bits of code which do something and can be called over and over
        //          Method overloading is something C# has created that allows us to use the same Method name and create another method that is similar
        //              but it is required to be different.
        //      In above, deck.Shuffle(5); is a method being called from Deck.cs



        //      Objects are the backbone of Object Oriented Programming

        //Console.ReadLine();

        //List<Game> games = new List<Game>();
        //Game game = new BlackJackGame();                    //  Polymorphism. This will compile
        ////  BlackJackGame game = new BlackJackGame();       //  This will also work as Add will polymorph the class.
        //games.Add(game);

        //              Easy way to initialize an object with values
        //      Card card = new Card() { Face = "King", Suit = "Spades" };

        //              A named paramter will not change function but will make code easier to read
        //      deck = Shuffle(deck, 3);      //      ex. deck = Shuffle(deck: deck, times: 3);

        //BlackJackGame game = new BlackJackGame();  //  Calling a class which inherits attributes from another class is called a superclass
        //game.Players = new List<string>() { "Jesse", "Bill", "Joe" };
        //game.ListPlayers();
        //Console.ReadLine();


        //Game game = new BlackJackGame();
        //Player player = new Player();
        //player.Name = "Ryan";
        //game = game + player;
        //game -= player;                     //  This line and the one above effectively work the same



        //public static Deck Shuffle(Deck deck, int times)
        //{
        //    for (int i = 0; i < times; i++)
        //    {
        //        deck = Shuffle(deck);
        //    }
        //    return deck;
        //}
    
}
