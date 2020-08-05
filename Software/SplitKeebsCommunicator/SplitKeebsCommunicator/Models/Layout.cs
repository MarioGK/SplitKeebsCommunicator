using System.Collections.ObjectModel;
using System.Windows.Documents;
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

        public void ReOrderZIndex()
        {/*
            for (var i = _rows.Count - 1; i >= 0; i--)
            {
                var row = _rows[i];
                row.ZIndex = i;
            }*/

            for (var i = 0; i < _rows.Count; i++)
            {
                var row = _rows[i];
                row.ZIndex = i;
            }
        }
    }
}