# NodeBook - VS Code-like Node.js Notebook Editor

A sophisticated WPF C# desktop application that brings the power of Jupyter-style notebooks to Node.js development. NodeBook provides a VS Code-inspired interface with a file explorer sidebar, dark theme by default, and seamless JSON-based notebook management.

![Version](https://img.shields.io/badge/version-1.0.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)
![Platform](https://img.shields.io/badge/platform-Windows%20(.NET)-blue)
![Language](https://img.shields.io/badge/language-C%23-blue)

## 🎯 Features

- **VS Code-inspired UI** - Familiar layout with sidebar explorer and editor tabs
- **Dark Theme** - Beautiful dark theme enabled by default
- **Custom File Format** - `.nbjson` files for Node.js notebook projects
- **File Explorer** - Browse and open notebook files directly from the sidebar
- **Code Cells** - Organize Node.js code into executable cells
- **JSON Serialization** - Save and load notebook content as structured JSON
- **Multi-cell Support** - Create, edit, and manage multiple code cells
- **Quick Actions** - Add cells, run code, and save with one click

## 🏗️ Technology Stack

- **Framework**: WPF (Windows Presentation Foundation)
- **Language**: C# (.NET Framework 4.7.2+)
- **Architecture**: MVVM Pattern
- **Data Format**: JSON

## 📁 Project Structure

```
nodebook/
├── App.xaml                          # Application root XAML
├── App.xaml.cs                       # Application code-behind
├── MainWindow.xaml                   # Main window UI
├── MainWindow.xaml.cs                # Main window code-behind
├── Models/
│   ├── NotebookNode.cs              # Notebook data model
│   ├── NotebookCell.cs              # Individual cell model
│   └── FileSystemItem.cs            # File system model
├── ViewModels/
│   ├── MainWindowViewModel.cs       # Main view logic and file operations
│   ├── FileTreeViewModel.cs         # File tree operations
│   └── EditorViewModel.cs           # Editor operations
├── Views/
│   ├── FileTreeView.xaml            # File tree component
│   ├── EditorView.xaml              # Editor component
│   └── NotebookEditor.xaml          # Notebook editor component
├── Services/
│   ├── FileService.cs               # File I/O operations
│   └── NotebookService.cs           # Notebook management
├── Themes/
│   └── DarkTheme.xaml               # Dark theme resource dictionary
├── Converters/
│   └── BooleanToVisibilityConverter.cs  # XAML converters
└── nodebook.csproj                  # Project file
```

## 🚀 Getting Started

### Prerequisites

- Windows 10 or later
- .NET Framework 4.7.2 or later
- Visual Studio 2019 or later (Community Edition works fine)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/code-tinker-art/nodebook.git
   cd nodebook
   ```

2. **Open in Visual Studio**
   - Open `nodebook.sln` in Visual Studio
   - Restore NuGet packages (if any)

3. **Build the project**
   ```
   Build → Build Solution (Ctrl+Shift+B)
   ```

4. **Run the application**
   ```
   Debug → Start Debugging (F5)
   ```

## 💻 Usage

### Creating a New Notebook

1. Launch NodeBook
2. Navigate to your desired folder in the File Explorer (left sidebar)
3. Create a new `.nbjson` file:
   ```json
   {
     "id": "uuid-here",
     "title": "My Node.js Project",
     "cells": []
   }
   ```

### Opening a Notebook

1. Click on any `.nbjson` file in the File Explorer
2. The notebook loads automatically in the editor
3. View and edit all cells in the main editor area

### Adding Code Cells

1. Click the **➕ Add Cell** button in the toolbar
2. Write your Node.js code in the new cell
3. Each cell is independent and can be executed separately

### Running Cells

1. Click the **▶ Run** button to execute selected cells
2. Output appears in the output cell below the code
3. Support for Node.js runtime execution (implementation in progress)

### Saving Your Work

1. Click the **💾 Save** button
2. Changes are persisted to the `.nbjson` file
3. All cell content and metadata is preserved

## 📋 Notebook File Format

NodeBook uses `.nbjson` (Node Book JSON) as its custom file extension. Here's an example structure:

```json
{
  "id": "550e8400-e29b-41d4-a716-446655440000",
  "title": "Express Server Setup",
  "cells": [
    {
      "id": "cell-001",
      "cellType": "Code",
      "code": "const express = require('express');\nconst app = express();\n\napp.listen(3000, () => {\n  console.log('Server running on port 3000');\n});",
      "output": ""
    },
    {
      "id": "cell-002",
      "cellType": "Code",
      "code": "app.get('/', (req, res) => {\n  res.send('Hello World!');\n});",
      "output": ""
    }
  ]
}
```

### Cell Types

- **Code**: Executable Node.js code
- **Markdown**: Documentation and notes
- **Output**: Results from code execution

## 🎨 UI Components

### Dark Theme

The application uses a sophisticated dark theme inspired by VS Code:

| Component | Color |
|-----------|-------|
| Background | #1E1E1E |
| Sidebar | #252526 |
| Editor | #1E1E1E |
| Text | #D4D4D4 |
| Accent | #007ACC |
| Border | #3E3E42 |
| Hover | #2D2D30 |
| Selection | #094771 |

### Sidebar Features

- File tree with folder expansion
- Instant file preview
- Filtered view (only shows `.nbjson` files and relevant folders)
- Smart folder ignoring (node_modules, .git, bin, obj, .vscode)

### Editor Features

- Tab-based interface
- Syntax highlighting ready
- Multi-line code editing
- JSON serialization toolbar

## 🔧 Configuration

### Custom File Extension

To change the file extension, edit `MainWindowViewModel.cs`:

```csharp
private const string CUSTOM_FILE_EXTENSION = ".nbjson";
```

Change `.nbjson` to your preferred extension (e.g., `.njsn`, `.notebook`, etc.)

### Ignored Folders

To customize which folders are hidden in the explorer, modify `ShouldIgnoreFolder()` in `MainWindowViewModel.cs`:

```csharp
private bool ShouldIgnoreFolder(string folderName)
{
    var ignoredFolders = new[] { "node_modules", ".git", "bin", "obj", ".vscode" };
    return Array.Exists(ignoredFolders, f => f.Equals(folderName, StringComparison.OrdinalIgnoreCase));
}
```

## 📈 Roadmap

- [ ] Node.js runtime integration for cell execution
- [ ] Syntax highlighting for JavaScript/TypeScript
- [ ] Markdown preview for documentation cells
- [ ] Output cell beautification (JSON formatting, colored logs)
- [ ] Cell execution history and debugging
- [ ] Export to JavaScript files
- [ ] Package management UI (npm integration)
- [ ] Split view for code and output
- [ ] Theme customization options
- [ ] Keyboard shortcuts documentation

## 🐛 Known Issues

- Cell execution requires manual Node.js runtime implementation
- Syntax highlighting not yet implemented
- No markdown preview support
- Output formatting is plain text

## 🤝 Contributing

Contributions are welcome! Here's how to help:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

Created by [code-tinker-art](https://github.com/code-tinker-art)

## 🙏 Acknowledgments

- Inspired by Jupyter Notebooks and Visual Studio Code
- Built with WPF and C#
- Dark theme colors inspired by VS Code

## 📧 Support

For issues, questions, or suggestions, please open a [GitHub Issue](https://github.com/code-tinker-art/nodebook/issues).

---

**Happy coding with NodeBook! 🚀**