using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using Common.Utils;

namespace BlackJackApp.Model
{
    public class Deck : BaseModel
    {
        #region Private Fildes

        private readonly List<string> _suits = new List<string> { "Hearts", "Diamonds", "Spades", "Clubs" };
        private readonly List<string> _ranks = new List<string> { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
            "Jack", "Queen", "King", "Ace"};

        private readonly Dictionary<string, int> _values;
        private readonly List<Card> _cards;

        #endregion

        #region Ctor

        public Deck()
        {
            _values = new Dictionary<string, int>
            {
                {"Two",2}, {"Three",3},{"Four",4}, {"Five",5},{"Six",6}, {"Seven",7},{"Eight",8}, {"Nine",9},{"Ten",10},
                { "Jack",10},{"Queen",10}, {"King",10},{"Ace",11}
            };

            _cards = new List<Card>();
            foreach (var suit in _suits)
            {
                foreach (var rank in _ranks)
                {
                    if (rank != null && suit != null)
                    {
                        int value = GetValueFromRank(rank);
                        _cards.Add(new Card(suit, rank, value));
                    }

                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Shuffle the cards
        /// </summary>
        public void Shuffle()
        {
            _cards.Shuffle();
        }

        /// <summary>
        /// Deal a card and remove it from the deck.
        /// </summary>
        public Card Deal()
        {
            Card lastCard = _cards.LastOrDefault();
            _cards.RemoveAt(_cards.Count - 1);
            return lastCard;
        }

        #endregion

        #region Private Methods

        private int GetValueFromRank(string rank)
        {
            return _values.TryGetValue(rank, out int value) ? value : 0;
        }

        #endregion
    }
}
