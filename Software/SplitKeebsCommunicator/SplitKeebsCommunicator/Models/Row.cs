using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Prism.Mvvm;

namespace SplitKeebsCommunicator.Models
{
    public class Row : BindableBase
    {
        private ObservableCollection<Key> _keys;

        public ObservableCollection<Key> Keys
        {
            get => _keys;
            set => SetProperty(ref _keys, value);
        }

        private Int32 _zIndex;

        [JsonIgnore]
        public Int32 ZIndex
        {
            get => _zIndex;
            set => SetProperty(ref _zIndex, value);
        }
    }
}