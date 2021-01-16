using System.ComponentModel;
using System.Runtime.CompilerServices;
using Common.Annotations;
using Common.Interfaces;

namespace Common.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IViewModel
    {
        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


    }
}
