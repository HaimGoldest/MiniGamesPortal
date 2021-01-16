namespace Common.Model
{
    public class Chips : BaseModel
    {
        #region Properties

        private int _total;
        public int Total
        {
            get => _total;
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        private int _bet;
        public int Bet
        {
            get => _bet;
            set
            {
                _bet = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="total">Starting total amount.</param>
        public Chips(int total)
        {
            Total = total;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Win the bet (add the bet amount to the total Chips.)
        /// </summary>
        public void WinBet()
        {
            Total += Bet;
        }

        /// <summary>
        /// Lose the bet (reduce the bet amount to the total Chips.)
        /// </summary>
        public void LoseBet()
        {
            Total -= Bet;
        }

        #endregion
    }
}
