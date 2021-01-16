using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;

namespace BlackJackApp.Model
{
    public class Hand : BaseModel
    {
        #region Properties

        private List<Card> _cards;
        /// <summary>
        /// Hand cards.
        /// </summary>
        public List<Card> Cards
        {
            get => _cards;
            set
            {
                _cards = value;
                OnPropertyChanged(nameof(Cards));
            }
        }

        private int _sumValue;
        /// <summary>
        /// Summary of the cards value.
        /// </summary>
        public int SumValue
        {
            get => _sumValue;
            set
            {
                _sumValue = value;
                OnPropertyChanged(nameof(SumValue));
            }
        }

        private int _aces;
        /// <summary>
        /// Number of aces in the hand.
        /// </summary>
        public int Aces
        {
            get => _aces;
            set
            {
                _aces = value;
                OnPropertyChanged(nameof(Aces));
            }
        }

        #endregion

        #region Ctor

        public Hand()
        {
            Cards = new List<Card>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add card to the hand.
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            Cards.Add(card);
            SumValue += card.Value;
            if (card.Rank.ToLower().Equals("ace"))
            {
                Aces += 1;
            }
        }

        /// <summary>
        /// If the hand is over 21 and the player have ace, use the ace as '1' instead of '11'.
        /// </summary>
        public void AdjustForAce()
        {
            while (SumValue > 21 && Aces > 0)
            {
                SumValue -= 10;
                Aces--;
            }
        }
        
        #endregion 

    }
}
