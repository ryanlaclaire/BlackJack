using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deck
    {
        public Deck()
        {
            //          This is an example of a nested for (foreach) loop. It will let us create all 4 suits of cards at the same time.
            Cards = new List<Card>();

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card card = new Card();
                    card.Face = (Face)i;
                    card.Suit = (Suit)j;
                    Cards.Add(card);
                }
            }
        }
        public List<Card> Cards { get; set; }

        public void Shuffle(int times = 1)        //  By adding a =1, the (times) integer becomes an optional input for the method. If no  
        {                                                           //  number is input (times) is assumed to be 1, but will accept another number as an input.
            for (int i = 0; i < times; i++)
            {                                                                       // The timesShuffled var is called an out. We are taking data out of the method and assigning it to another
                List<Card> TempList = new List<Card>();                             // variable. This example will allow us to verify the number of times this method runs.
                Random random = new Random();

                while (Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, Cards.Count);
                    TempList.Add(Cards[randomIndex]);
                    Cards.RemoveAt(randomIndex);
                }
                this.Cards = TempList;          // (this) means it's referring to this local thing
            }

        }
    }
}
