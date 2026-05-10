using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using VSCodeNodeEditor.Models;
using VSCodeNodeEditor.ViewModels;

namespace VSCodeNodeEditor
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            this.DataContext = _viewModel;
            
            InitializeFileTree();
            AttachEventHandlers();
        }

        private void InitializeFileTree()
        {
            string projectPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var rootItem = _viewModel.CreateFileTreeItem(projectPath);
            FileTreeView.Items.Add(rootItem);
        }

        private void AttachEventHandlers()
        {
            AddCellBtn.Click += (s, e) => _viewModel.AddCell();
            RunBtn.Click += (s, e) => _viewModel.RunCells();
            SaveBtn.Click += (s, e) => _viewModel.SaveNotebook();

            FileTreeView.SelectedItemChanged += (s, e) =>
            {
                var selectedItem = FileTreeView.SelectedItem as FileSystemItemViewModel;
                if (selectedItem != null && selectedItem.IsFile)
                {
                    _viewModel.OpenFile(selectedItem.FullPath);
                    CurrentTabName.Text = selectedItem.Name;
                }
            };
        }
    }

    public class FileSystemItemViewModel
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public bool IsFile { get; set; }
        public bool IsExpanded { get; set; }
        public ObservableCollection<FileSystemItemViewModel> Children { get; set; }

        public FileSystemItemViewModel()
        {
            Children = new ObservableCollection<FileSystemItemViewModel>();
        }

        public override string ToString() => Name;
    }
}