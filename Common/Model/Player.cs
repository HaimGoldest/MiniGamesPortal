using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    #region Private Fileds and Propeties

    public class Player : BaseModel
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private Chips _chips;
        public Chips Chips
        {
            get => _chips;
            set
            {
                _chips = value;
                OnPropertyChanged(nameof(Chips));
            }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="id">Player ID.</param>
        /// <param name="name">Player name.</param>
        /// <param name="startingChips">Starting chips amount.</param>
        public Player(int id, string name, int startingChips)
        {
            Id = id;
            Name = name;
            Chips = new Chips(startingChips);
        }

        #endregion

    }
}
