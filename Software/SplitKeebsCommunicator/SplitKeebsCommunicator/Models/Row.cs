using System.Collections.ObjectModel;
using System.Windows;
using Prism.Mvvm;

namespace SplitKeebsCommunicator.Models
{
    public class Row : BindableBase
    {
        private double                    _height;
        private ObservableCollection<Key> _keys;

        public ObservableCollection<Key> Keys
        {
            get => _keys;
            set => SetProperty(ref _keys, value);
        }

        public double Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        public void CalculateKeysPosition()
        {
            var width  = 0d;
            var border = 0d;

            foreach (var key in _keys)
            {
                key.X =  width;
                width += key.Width + key.ExtraWidth + key.Border;
                key.Y =  Height;
            }
        }
    }
}