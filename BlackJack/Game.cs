using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public abstract class Game      //Adding abstract stops other people from accessing it
    {
        //      A good coding practice is to write code to be generic so it can used over again

        private List<Player> _players = new List<Player>();
        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();

        public List<Player> Players { get { return _players; } set { _players = value; } }
        public string Name { get; set; }
        public Dictionary<Player, int> Bets { get { return _bets; } set {_bets = value;} }

        public abstract void Play();    //This abstract method states that any program which implements this class, 
                                        //must also utilize this method. Can only be inside abstract class.

        public virtual void ListPlayers()       //virtual can only exist inside an abstract class. This allows us to
        {                                       //make some changes in the inheriting class and customize this method
            foreach (Player player in Players)  //for other uses
            {
                Console.WriteLine(player);
            }

        }
    }
}
