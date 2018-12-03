using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public struct Card
    {
        // A class is a design or frame for something

        //      A constructor is values assigned to an object upon creation

        //public Card()
        //{
        //    Suit = "Queen";
        //    Face = "Two";
        //}
        public Suit Suit { get; set; }
        public Face Face { get; set; }

        public override string ToString()
        {
            return string.Format($"{Face} of {Suit}");
        }
    }
    public enum Suit
    {
        Diamonds,
        Spades,
        Hearts,
        Clubs
    }
    public enum Face
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
