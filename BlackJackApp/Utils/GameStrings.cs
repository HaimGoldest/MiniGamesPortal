using BlackJackApp.Model;
using Common.Model;

namespace BlackJackApp.Utils
{
    /// <summary>
    /// Provides strings for the game.
    /// </summary>
    public static class GameStrings
    {
        /// <summary>
        /// Open statement for the game.
        /// </summary>
        public static string OpenStatement => "Welcome to BlackJack - 21!\nGet as close to 21 as you can without going over!\n" +
                                              "Dealer hits until she reaches 17.\nIn case of a tie the dealer wins.\nAces count as 1 or 11.";

        /// <summary>
        /// Request for a bet.
        /// </summary>
        public static string BetRequest => "\nHow many chips would you like to bet?\n";

        /// <summary>
        /// Bet amount changed.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string BetChanged(string value) => $"Bet amount set to {value}.\n" +
                                                         "Would you like to Hit or Stand?";

        /// <summary>
        /// The bet is not int.
        /// </summary>
        public static string BetNotInt => "Sorry, a bet must be an integer!";

        /// <summary>
        /// The bet is lass then 0.
        /// </summary>
        public static string BetMinusInt => "Sorry, a bet can not be less than 1!";

        /// <summary>
        /// The bet is exceeded from the total chips amount.
        /// </summary>
        public static string BetExceeded(int totalChips) => $"Sorry, your bet can't exceed {totalChips}";

        /// <summary>
        /// Player reached 21 and won.
        /// </summary>
        public static string WinWith21(Player player) => $"{player.Name} reached 21 and won!!";

        /// <summary>
        /// Player won.
        /// </summary>
        public static string PlayerWins(Player player) => $"{player.Name} won!!";

        /// <summary>
        /// Player busts.
        /// </summary>
        public static string PlayerBusts(Player player) => $"{player.Name} busts!!";

        /// <summary>
        /// Dealer hand value.
        /// </summary>
        public static string DealerCardsValue(int value) => $"Dealer hand reached to {value}.";

        /// <summary>
        /// Dealer cards header.
        /// </summary>
        public static string DealerCardsHeader => "Dealer cards:\n";

        /// <summary>
        /// Show card information in "Game Info".
        /// </summary>
        public static string NewCardInfo(Player player, Card card) => $"{player.Name} received " +
                                                                   $"{card.Suit} {card.Rank} card.";

        /// <summary>
        /// A draw between the player and Dealer.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Push(Player player, int value) => $"Push!! Dealer and {player.Name} reached to {value}.";

        /// <summary>
        /// Game over.
        /// </summary>
        public static string GameOver => "You lost all of your chips.\nGAME OVER!!!";
    }
}
