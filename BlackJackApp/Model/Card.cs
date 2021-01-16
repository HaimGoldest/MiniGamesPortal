using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;

namespace BlackJackApp.Model
{
    public class Card : BaseModel
    {
        public string Suit { get; }
        public string Rank { get; }
        public int Value { get; }
        
        public Card(string suit, string rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;
        }
    }
}
