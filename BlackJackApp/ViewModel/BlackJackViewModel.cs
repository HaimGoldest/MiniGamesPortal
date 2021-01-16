using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BlackJackApp.Commands;
using BlackJackApp.Model;
using BlackJackApp.Utils;
using Common.Model;
using Common.ViewModel;

namespace BlackJackApp.ViewModel
{
    public class BlackJackViewModel : BaseViewModel
    {
        #region Private Fileds and Propeties

        private bool _isDealerTurn;

        private Deck _deck;
        public Deck Deck
        {
            get => _deck;
            set
            {
                _deck = value;
                OnPropertyChanged(nameof(Deck));
            }
        }

        private BlackJackPlayer _user;
        public BlackJackPlayer User
    {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public BlackJackPlayer Dealer { get; set; }

        private string _currentBet;
        public string CurrentBet
        {
            get => _currentBet;
            set
            {
                if (value == "0")
                {
                    _currentBet = value;
                    HitAndStandEnable = false;
                }
                else if (TakeBet(User, value))
                {
                    _currentBet = value;
                    HitAndStandEnable = true;
                    UpdateHandValueUI();
                    SetGameInfoText(GameStrings.BetChanged(value));
                }
                
                OnPropertyChanged(nameof(CurrentBet));
            }
        }
        
        private string _gameInfo;
        public string GameInfo
        {
            get => _gameInfo;
            set
            {
                _gameInfo = value;
                OnPropertyChanged(nameof(GameInfo));
            }
        }

        private string _playerHandValue;
        public string PlayerHandValue
        {
            get => _playerHandValue;
            set
            {
                _playerHandValue = value;
                OnPropertyChanged(nameof(PlayerHandValue));
            }
        }

        private string _dealerHandValue;
        public string DealerHandValue
        {
            get => _dealerHandValue;
            set
            {
                _dealerHandValue = value;
                OnPropertyChanged(nameof(DealerHandValue));
            }
        }

        private bool _hitAndStandEnable;
        public bool HitAndStandEnable
        {
            get => _hitAndStandEnable;
            set
            {
                _hitAndStandEnable = value;
                OnPropertyChanged(nameof(HitAndStandEnable));
            }
        }

        public HitCommand HitCommand { get; set; }
        public StandCommand StandCommand { get; set; }

        #endregion

        #region Init Methods

        /// <summary>
        /// Ctor
        /// </summary>
        public BlackJackViewModel()
        {
            HitCommand = new HitCommand(this);
            StandCommand = new StandCommand(this);
            StartNewGame();
        }

        /// <summary>
        /// Starting new game.
        /// </summary>
        public void StartNewGame()
        {
            InitPlayers();
            SetGameInfoText(GameStrings.OpenStatement);
            StartNewTurn();
        }

        #endregion

        #region Game Methods

        /// <summary>
        /// Starting new turn.
        /// </summary>
        private void StartNewTurn()
        {
            _isDealerTurn = false;
            HitAndStandEnable = false;
            AddGameInfoText(GameStrings.BetRequest);
            CurrentBet = "0";
            CardsDistribution();
            if (BustOrBlackJack(User))
            {
                StartNewTurn();
            }
        }

        /// <summary>
        /// Init the game players
        /// </summary>
        private void InitPlayers()
        {
            Dealer = new BlackJackPlayer(-1, "Dealer", 0);
            User = new BlackJackPlayer(1, "User", 100);
        }

        /// <summary>
        /// Change the GameInfo text.
        /// </summary>
        /// <param name="text">New text.</param>
        private void SetGameInfoText(string text)
        {
            GameInfo = text;
        }

        /// <summary>
        /// Add text to the GameInfo text.
        /// </summary>
        /// <param name="text">New text to add.</param>
        private void AddGameInfoText(string text)
        {
            GameInfo = GameInfo + "\n\n" + text;
        }

        /// <summary>
        /// Create & shuffle the deck, deal two cards to each player.
        /// </summary>
        private void CardsDistribution()
        {
            Deck = new Deck();
            Deck.Shuffle();
            User.Hand = GetNewHand();
            Dealer.Hand = GetNewHand();
        }

        /// <summary>
        /// Get new hand with 2 cards from the deck.
        /// </summary>
        private Hand GetNewHand()
        {
            Hand hand = new Hand();
            hand.AddCard(Deck.Deal());
            hand.AddCard(Deck.Deal());
            return hand;
        }

        /// <summary>
        /// Set bet amount.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="amount"></param>
        /// <returns>if the bet is valid.</returns>
        public bool TakeBet(BlackJackPlayer player, string amount)
        {
            if (player == null)
            {
                return false;
            }

            try
            {
                var totalAmount = player.Chips.Total;
                var bet = int.Parse(amount);

                if (bet > totalAmount)
                {
                    SetGameInfoText(GameStrings.BetExceeded(totalAmount));
                    return false;
                }

                if (bet < 0)
                {
                    SetGameInfoText(GameStrings.BetMinusInt);
                    return false;
                }

                player.Chips.Bet = bet;
                return true;
            }
            catch (FormatException)
            {
                SetGameInfoText(GameStrings.BetNotInt);
                return false;
            }
        }

        /// <summary>
        /// Take card from deck.
        /// </summary>
        /// <param name="player"></param>
        public void Hit(BlackJackPlayer player)
        {
            var hand = player.Hand;
            var newCard = Deck.Deal();
            hand.AddCard(newCard);
            hand.AdjustForAce();
            UpdateHandValueUI();

            if (player != Dealer || _isDealerTurn)
            {
                AddGameInfoText(GameStrings.ShowCard(player, newCard));
            }

            if (player != Dealer && BustOrBlackJack(player))
            {
                StartNewTurn();
            }
        }

        private void UpdateHandValueUI()
        {
            if (_isDealerTurn)
            {
                DealerHandValue = Dealer.Hand.SumValue.ToString();
            }
            else
            {
                PlayerHandValue = User.Hand.SumValue.ToString();
                DealerHandValue = Dealer.Hand.Cards[0].Value.ToString();
            }
        }

        /// <summary>
        /// Check and update if the player wins as BlackJack or lose as Bust.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>if the hand is Bust Or BlackJack.</returns>
        private bool BustOrBlackJack(BlackJackPlayer player)
        {
            if (IsBlackJack(player))
            {
               WinWith21(player);
               return true;
            }
            if (IsBust(player))
            {
                PlayerBusts(player);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns if the player reached to 21.
        /// </summary>
        /// <param name="player"></param>
        private bool IsBlackJack(BlackJackPlayer player)
        {
            var sum = player.Hand.SumValue;
            return sum == 21;
        }

        /// <summary>
        /// Returns if the player bust (the hand is over 21).
        /// </summary>
        /// <param name="player"></param>
        private bool IsBust(BlackJackPlayer player)
        {
            var sum = player.Hand.SumValue;
            return sum > 21;
        }

        /// <summary>
        /// Player reached 21 and win.
        /// </summary>
        /// <param name="player"></param>
        private void WinWith21(BlackJackPlayer player)
        {
            AddGameInfoText(GameStrings.WinWith21(player));
            WinBet(player);
        }

        /// <summary>
        /// Player win a bet.
        /// </summary>
        /// <param name="player"></param>
        private void WinBet(BlackJackPlayer player)
        {
            player.Chips.WinBet();
        }

        /// <summary>
        /// Player lose a bet.
        /// </summary>
        /// <param name="player"></param>
        private void LoseBet(BlackJackPlayer player)
        {
            player.Chips.LoseBet();
        }

        /// <summary>
        /// Finished current turn.
        /// </summary>
        public void Stand()
        {
            DealerTurn();
        }

        /// <summary>
        /// Start dealer turn
        /// </summary>
        private void DealerTurn()
        {
            _isDealerTurn = true;
            ShowDealerHand();

            var value = Dealer.Hand.SumValue;
            UpdateDealerTotalValueInfo(Dealer.Hand.SumValue);

            while (value < 17)
            {
                Hit(Dealer);
                value = Dealer.Hand.SumValue;
                UpdateDealerTotalValueInfo(value);
            }

            if (IsBlackJack(Dealer))
            {
                WinWith21(Dealer);
                LoseBet(User);
            }
            else if (IsBust(Dealer))
            {
                PlayerBusts(Dealer);
                WinBet(User);
            }
            else
            {
                var winner = GetWinner();
                if (winner == User)
                {
                    PlayerWins(User);
                }
                else
                {
                    PlayerWins(Dealer);
                    LoseBet(User);
                }
            }
            
            StartNewTurn();
        }

        /// <summary>
        /// Display dealer hand to the user.
        /// </summary>
        private void ShowDealerHand()
        {
            SetGameInfoText(GameStrings.ShowDealerCardsHeader);
            foreach (var card in Dealer.Hand.Cards)
            {
                AddGameInfoText(GameStrings.ShowCard(Dealer, card));
            }

            UpdateHandValueUI();
        }

        /// <summary>
        /// Returns the winning player (with the better hand).
        /// </summary>
        private BlackJackPlayer GetWinner()
        {
            var dealerValue = Dealer.Hand.SumValue;
            var userValue = User.Hand.SumValue;

            if (userValue > dealerValue)
            {
                return User;
            }

            if (userValue == dealerValue)
            {
                AddGameInfoText(GameStrings.Push(User,userValue));
            }

            return Dealer;
        }

        /// <summary>
        /// Add the player total cards value to the game info.
        /// </summary>
        /// <param name="value"></param>
        private void UpdateDealerTotalValueInfo(int value)
        {
            AddGameInfoText(GameStrings.DealerCardsValue(value));
        }

        /// <summary>
        /// Player won with a better hand.
        /// </summary>
        /// <param name="player"></param>
        private void PlayerWins(BlackJackPlayer player)
        {
            AddGameInfoText(GameStrings.PlayerWins(player));
            WinBet(player);
        }


        /// <summary>
        /// Player busts and lose (have over 21 in his hand).
        /// </summary>
        /// <param name="player"></param>
        private void PlayerBusts(BlackJackPlayer player)
        {
            AddGameInfoText(GameStrings.PlayerBusts(player));
            LoseBet(player);
        }

        /// <summary>
        /// returns if Hit/Stand button are enabled.
        /// </summary>
        public bool CanHitOrStand()
        {
            if (CurrentBet == null) return false;

            try
            {
                var bet = int.Parse(CurrentBet);
                return bet > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
