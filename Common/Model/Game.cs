using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class Game : BaseModel
    {
        #region Private Fileds and Propeties

        private List<Player> _players;
        public List<Player> Players
        {
            get => _players;
            set
            {
                _players = value;
                OnPropertyChanged(nameof(Players));
            }
        }

        #endregion

        #region Ctor

        public Game(int numberOfPlayers)
        {

        }

        #endregion

    }
}
