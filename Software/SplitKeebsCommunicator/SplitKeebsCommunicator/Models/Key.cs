using System.Text.Json.Serialization;
using Prism.Mvvm;

namespace SplitKeebsCommunicator.Models
{
    public class Key : BindableBase
    {
        private string _keyCode;

        private double _keySize;

        private string _name;

        private double _size;

        public Key(string name = "", double keySize = 1, double keySizeHeight = 1)
        {
            Name = name;
            Size = GetFontSize();
            
            if (name != null)
            {
                IsSpacer = name == "Spacer";
            }
            
            KeySize = keySize;
            KeySizeHeight = keySizeHeight;
            KeyWidth = GetKeyWidth();
            KeyHeight = GetKeyHeight();
        }

        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                SetProperty(ref _size, GetFontSize());
            }
        }

        public string KeyCode
        {
            get => _keyCode;
            set => SetProperty(ref _keyCode, value);
        }

        [JsonIgnore]
        public double Size
        {
            get => _size;
            set => SetProperty(ref _size, value);
        }

        /// <summary>
        ///     Key size XU
        /// </summary>
        public double KeySize
        {
            get => _keySize;
            set => SetProperty(ref _keySize, value);
        }

        private double _keyWidth;

        [JsonIgnore]
        public double KeyWidth
        {
            get => _keyWidth;
            set => SetProperty(ref _keyWidth, value);
        }

        private bool _isSpacer;

        [JsonIgnore]
        public bool IsSpacer
        {
            get => _isSpacer;
            set => SetProperty(ref _isSpacer, value);
        }

        private double GetFontSize()
        {
            if (string.IsNullOrEmpty(_name))
            {
                return 0;
            }
            return _name.Length > 2 ? 22 : 30;
        }
        
        private const double ConstSize = 70;

        private double _keyHeight;

        [JsonIgnore]
        public double KeyHeight
        {
            get => _keyHeight;
            set => SetProperty(ref _keyHeight, value);
        }

        private double GetKeyWidth()
        {
            return _keySize * ConstSize;
        }
        
        private double GetKeyHeight()
        {
            if (KeySizeHeight == 0)
            {
                return ConstSize;
            }
            
            return _keySizeHeight * ConstSize;
        }

        private double _keySizeHeight;

        public double KeySizeHeight
        {
            get => _keySizeHeight;
            set => SetProperty(ref _keySizeHeight, value);
        }

        public override string ToString()
        {
            return $"Name:{Name} Size:{KeySize}U Blank:{IsSpacer}";
        }
    }
}