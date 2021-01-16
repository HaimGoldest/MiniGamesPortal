using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;

namespace BlackJackApp.Model
{
    public class BlackJackPlayer : Player
    {
        public Hand Hand { get; set; }
        public BlackJackPlayer(int id, string name, int startingChips) : base(id, name, startingChips)
        {
        }
    }
}
