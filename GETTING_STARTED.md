# Getting Started with NodeBook

## Quick Start Guide

### Step 1: Open the Project
1. Clone the repository:
   ```bash
   git clone https://github.com/code-tinker-art/nodebook.git
   cd nodebook
   ```

2. Open in Visual Studio:
   - Open Visual Studio 2019 or later
   - File → Open → Project/Solution
   - Select `nodebook.sln`

### Step 2: Build & Run
1. Build the solution: `Ctrl+Shift+B`
2. Run the application: `F5` or `Debug → Start Debugging`

### Step 3: Create Your First Notebook

1. **Navigate to a folder** in the Explorer sidebar (left panel)
2. **Create a new notebook file** with `.nbjson` extension:
   ```json
   {
     "id": "550e8400-e29b-41d4-a716-446655440000",
     "title": "My First Node.js Notebook",
     "cells": []
   }
   ```

3. **Open the file** by clicking it in the explorer

4. **Add cells** by clicking the "➕ Add Cell" button

5. **Write Node.js code** in the cell editor

6. **Save** your work with the "💾 Save" button

## Example Notebook

Create a file named `express-app.nbjson`:

```json
{
  "id": "app-001",
  "title": "Express Server Setup",
  "cells": [
    {
      "id": "cell-001",
      "cellType": "Code",
      "code": "const express = require('express');\nconst app = express();\n\n// Middleware\napp.use(express.json());\n\nconsole.log('Express app created');",
      "output": ""
    },
    {
      "id": "cell-002",
      "cellType": "Code",
      "code": "// Define routes\napp.get('/', (req, res) => {\n  res.json({ message: 'Welcome to NodeBook!' });\n});\n\napp.post('/api/data', (req, res) => {\n  res.json({ received: req.body });\n});",
      "output": ""
    },
    {
      "id": "cell-003",
      "cellType": "Code",
      "code": "// Start server\nconst PORT = process.env.PORT || 3000;\napp.listen(PORT, () => {\n  console.log(`Server is running on port ${PORT}`);\n});",
      "output": ""
    }
  ]
}
```

## Project Structure

```
VSCodeNodeEditor/
├── Models/                 # Data models
│   ├── NotebookNode.cs
│   ├── NotebookCell.cs
│   └── FileSystemItem.cs
├── ViewModels/             # Business logic
│   └── MainWindowViewModel.cs
├── Views/                  # Future UI components
├── Services/               # File and notebook services
├── Themes/                 # Dark theme styling
├── App.xaml                # Application entry
├── MainWindow.xaml         # Main UI
└── MainWindow.xaml.cs      # UI logic
```

## Key Features to Explore

### File Explorer
- Click folders to expand/collapse
- Only `.nbjson` files are shown
- Double-click to open a notebook

### Editor Toolbar
- **➕ Add Cell**: Creates a new code cell
- **▶ Run**: Executes all cells (in development)
- **💾 Save**: Persists changes to `.nbjson` file

### Dark Theme
- Default dark theme inspired by VS Code
- No theme switching needed
- Comfortable for long coding sessions

## Customization

### Change File Extension
Edit `MainWindowViewModel.cs`:
```csharp
private const string CUSTOM_FILE_EXTENSION = ".nbjson";
```
Change to: `.notebook`, `.njsn`, or any other extension

### Change Ignored Folders
Edit the `ShouldIgnoreFolder()` method:
```csharp
private bool ShouldIgnoreFolder(string folderName)
{
    var ignoredFolders = new[] { "node_modules", ".git", "bin", "obj", ".vscode" };
    // Add or remove as needed
}
```

## Troubleshooting

### Files not showing in explorer
- Ensure files have `.nbjson` extension
- Check that parent folders aren't in the ignore list
- Restart the application

### Cannot open notebook
- Verify the file has valid JSON structure
- Check file permissions
- Ensure it has the correct `.nbjson` extension

### Save not working
- Ensure you have a file open
- Check file system permissions
- Verify the file path is valid

## Next Steps

1. **Create notebooks** for your Node.js projects
2. **Explore the code** to understand MVVM architecture
3. **Customize the theme** colors in `DarkTheme.xaml`
4. **Contribute** - fork and submit pull requests!

## Resources

- [WPF Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
- [MVVM Pattern Guide](https://docs.microsoft.com/en-us/dotnet/architecture/maui/mvvm)
- [Node.js Documentation](https://nodejs.org/docs/)

Happy coding! 🚀