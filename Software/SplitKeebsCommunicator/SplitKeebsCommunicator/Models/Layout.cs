using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace SplitKeebsCommunicator.Models
{
    public class Layout : BindableBase
    {
        private ObservableCollection<Row> _rows = new ObservableCollection<Row>();

        public ObservableCollection<Row> Rows
        {
            get => _rows;
            set => SetProperty(ref _rows, value);
        }

        public void CalculateRowsPosition()
        {
            for (var i = 0; i < _rows.Count; i++)
            {
                var row = _rows[i];
                row.Height = i * 70;

                row.CalculateKeysPosition();
            }
        }
    }
}