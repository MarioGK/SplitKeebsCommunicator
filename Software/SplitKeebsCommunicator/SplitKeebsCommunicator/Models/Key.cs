using System.Text.Json.Serialization;
using Prism.Mvvm;

namespace SplitKeebsCommunicator.Models
{
    public class Key : BindableBase
    {
        public readonly double ConstSize = 70;
        public readonly double Border = 0;
        private         string _keyCode;
        private         double _cherrySizeWidth;
        private         double _cherrySizeHeight;
        private         string _name;

        private double _x;

        private double _y;

        public Key(string name = "", double cherrySizeWidth = 1, double cherrySizeHeight = 1)
        {
            Name             = name;
            CherrySizeWidth  = cherrySizeWidth;
            CherrySizeHeight = cherrySizeHeight;
        }

        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name,     value);
                RaisePropertyChanged(nameof(FontSize));
            }
        }

        public string KeyCode
        {
            get => _keyCode;
            set => SetProperty(ref _keyCode, value);
        }
        
        public double FontSize
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    return 0;
                }

                if (_name.Length > 4)
                {
                    return 16;
                }

                if (_name.Length > 2)
                {
                    return 18;
                }

                return 22;
            }
        }

        /// <summary>
        ///     Key size XU
        /// </summary>
        public double CherrySizeWidth
        {
            get => _cherrySizeWidth;
            set
            {
                SetProperty(ref _cherrySizeWidth, value);
                RaisePropertyChanged(nameof(Width));
            }
        }

        private double _cherryExtraWidth;

        public double CherryExtraWidth
        {
            get => _cherryExtraWidth;
            set
            {
                SetProperty(ref _cherryExtraWidth, value);
                RaisePropertyChanged(nameof(ExtraWidth));
            }
        }

        /// <summary>
        /// Spacer between keys
        /// </summary>
        public double ExtraWidth => _cherryExtraWidth * ConstSize;
        
        public double Width =>_cherrySizeWidth * ConstSize;

        public double Height
        {
            get
            {
                if (CherrySizeHeight == 0)
                {
                    return ConstSize;
                }

                return _cherrySizeHeight * ConstSize + Border * 2;
            }
        }

        public double CherrySizeHeight
        {
            get => _cherrySizeHeight;
            set
            {
                SetProperty(ref _cherrySizeHeight, value);
                RaisePropertyChanged(nameof(Height));
            }
        }

        [JsonIgnore]
        public double X
        {
            get => _x;
            set => SetProperty(ref _x, value);
        }

        [JsonIgnore]
        public double Y
        {
            get => _y;
            set => SetProperty(ref _y, value);
        }

        public override string ToString()
        {
            return $"Name:{Name} Size:{CherrySizeWidth}U";
        }
    }
}