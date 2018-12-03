using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    interface IWalkAway
    {
        //      You can only inherit one base class but can inherit as many interfaces as you want.
        //          Everything in an interface is public so no need to state it.
        //      The naming convention for interfaces is to begin with I (interface).

        void WalkAway(Player player);
    }
}
