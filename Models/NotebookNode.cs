using System;
using System.Collections.ObjectModel;

namespace VSCodeNodeEditor.Models
{
    public class NotebookNode
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public ObservableCollection<NotebookCell> Cells { get; set; }

        public NotebookNode()
        {
            Cells = new ObservableCollection<NotebookCell>();
        }
    }
}