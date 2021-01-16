using System.ComponentModel;

namespace Common.Interfaces
{
    public interface IModel
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}