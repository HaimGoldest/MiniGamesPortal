using System.ComponentModel;

namespace Common.Interfaces
{
    public interface IViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}