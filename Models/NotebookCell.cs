using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VSCodeNodeEditor.Models
{
    public class NotebookCell : INotifyPropertyChanged
    {
        private string _code;
        private string _output;
        private CellType _cellType;

        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        public CellType CellType
        {
            get => _cellType;
            set { _cellType = value; OnPropertyChanged(); }
        }

        public string Code
        {
            get => _code;
            set { _code = value; OnPropertyChanged(); }
        }

        public string Output
        {
            get => _output;
            set { _output = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public enum CellType
    {
        Code,
        Markdown,
        Output
    }
}