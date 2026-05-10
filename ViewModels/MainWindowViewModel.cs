using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using VSCodeNodeEditor.Models;

namespace VSCodeNodeEditor.ViewModels
{
    public class MainWindowViewModel
    {
        // Define your custom file extension here
        private const string CUSTOM_FILE_EXTENSION = ".nbjson"; // NodeBook JSON format
        
        public ObservableCollection<NotebookCell> Cells { get; set; }
        public NotebookNode CurrentNotebook { get; set; }
        private string _currentFilePath;

        public MainWindowViewModel()
        {
            Cells = new ObservableCollection<NotebookCell>();
            CurrentNotebook = new NotebookNode { Title = "Untitled" };
        }

        public void AddCell()
        {
            var cell = new NotebookCell 
            { 
                CellType = CellType.Code,
                Code = "// Enter Node.js code here\n"
            };
            CurrentNotebook.Cells.Add(cell);
            Cells.Add(cell);
        }

        public void RunCells()
        {
            try
            {
                MessageBox.Show("Cell execution not implemented yet.\nWould execute with Node.js runtime.", 
                    "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running cells: {ex.Message}", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void SaveNotebook()
        {
            try
            {
                if (string.IsNullOrEmpty(_currentFilePath))
                {
                    MessageBox.Show("No file selected for saving.", 
                        "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(CurrentNotebook, options);
                File.WriteAllText(_currentFilePath, json);
                
                MessageBox.Show("Notebook saved successfully!", 
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving notebook: {ex.Message}", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void OpenFile(string filePath)
        {
            try
            {
                _currentFilePath = filePath;
                
                // Only open files with your custom extension
                if (File.Exists(filePath) && IsCustomNotebookFile(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    CurrentNotebook = JsonSerializer.Deserialize<NotebookNode>(json);
                    
                    Cells.Clear();
                    if (CurrentNotebook?.Cells != null)
                    {
                        foreach (var cell in CurrentNotebook.Cells)
                        {
                            Cells.Add(cell);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Only {CUSTOM_FILE_EXTENSION} files are supported.", 
                        "Invalid File Type", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CurrentNotebook = new NotebookNode { Title = "Untitled" };
                    Cells.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening file: {ex.Message}", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public FileSystemItemViewModel CreateFileTreeItem(string path)
        {
            var item = new FileSystemItemViewModel
            {
                Name = Path.GetFileName(path) ?? path,
                FullPath = path,
                IsFile = File.Exists(path),
                IsExpanded = true
            };

            if (Directory.Exists(path))
            {
                try
                {
                    var directories = Directory.GetDirectories(path);
                    var files = Directory.GetFiles(path);

                    foreach (var dir in directories)
                    {
                        if (!ShouldIgnoreFolder(Path.GetFileName(dir)))
                        {
                            item.Children.Add(CreateFileTreeItem(dir));
                        }
                    }

                    foreach (var file in files)
                    {
                        // Only show custom notebook files
                        if (IsCustomNotebookFile(file))
                        {
                            item.Children.Add(new FileSystemItemViewModel
                            {
                                Name = Path.GetFileName(file),
                                FullPath = file,
                                IsFile = true
                            });
                        }
                    }
                }
                catch { }
            }

            return item;
        }

        /// <summary>
        /// Check if file has the custom notebook extension
        /// </summary>
        public bool IsCustomNotebookFile(string filePath)
        {
            return Path.GetExtension(filePath).Equals(CUSTOM_FILE_EXTENSION, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Get the custom file extension
        /// </summary>
        public string GetCustomFileExtension()
        {
            return CUSTOM_FILE_EXTENSION;
        }

        private bool ShouldIgnoreFolder(string folderName)
        {
            var ignoredFolders = new[] { "node_modules", ".git", "bin", "obj", ".vscode" };
            return Array.Exists(ignoredFolders, f => f.Equals(folderName, StringComparison.OrdinalIgnoreCase));
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