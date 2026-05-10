# Running NodeBook with Visual Studio 2022 and .NET 9

This guide will walk you through setting up and running NodeBook with Visual Studio 2022 and .NET 9.

## 📋 Prerequisites

Before you begin, ensure you have:

- **Visual Studio 2022** (version 17.8 or later)
  - Download: https://visualstudio.microsoft.com/vs/
- **.NET 9 SDK** (installed via Visual Studio or standalone)
  - Download: https://dotnet.microsoft.com/download/dotnet/9.0
- **Git** (to clone the repository)

## ✅ Installation Steps

### Step 1: Verify .NET 9 Installation

Open PowerShell or Command Prompt and check:

```bash
dotnet --version
```

You should see `9.0.x` or higher.

If not installed:
1. Open Visual Studio 2022 Installer
2. Click "Modify"
3. Go to "Workloads"
4. Select "Desktop development with C++" (includes .NET 9)
5. Click "Modify"

### Step 2: Clone the Repository

```bash
git clone https://github.com/code-tinker-art/nodebook.git
cd nodebook
```

### Step 3: Open in Visual Studio 2022

1. **Open Visual Studio 2022**
2. Click **File → Open → Project/Solution**
3. Navigate to the `nodebook` folder
4. Select **`nodebook.csproj`** and click **Open**

> The solution will automatically load with .NET 9 support

### Step 4: Restore Dependencies

Visual Studio should automatically restore NuGet packages. If not:

1. Click **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**
2. Or right-click the project → **Restore NuGet Packages**

### Step 5: Build the Project

**Method 1: Using Visual Studio**
- Press **Ctrl + Shift + B** or
- Click **Build → Build Solution**

**Method 2: Using Command Line** (in project directory)
```bash
dotnet build
```

Expected output:
```
Build succeeded.
```

### Step 6: Run the Application

**Method 1: From Visual Studio**
- Press **F5** (Debug mode) or
- Press **Ctrl + F5** (Release mode) or
- Click **Debug → Start Debugging**

**Method 2: From Command Line**
```bash
dotnet run
```

## 🎉 Success!

You should see the NodeBook window appear with:
- ✅ Dark theme enabled
- ✅ File explorer sidebar on the left
- ✅ Editor area on the right
- ✅ Toolbar with Add Cell, Run, and Save buttons

## 📁 Project Structure in Visual Studio

```
nodebook
├── nodebook.csproj           ← Project file (.NET 9)
├── App.xaml                  ← Application configuration
├── MainWindow.xaml           ← Main UI
├── Models/
│   ├── NotebookNode.cs
│   ├── NotebookCell.cs
│   └── FileSystemItem.cs
├── ViewModels/
│   └── MainWindowViewModel.cs
├── Themes/
│   └── DarkTheme.xaml
└── README.md
```

## 🛠️ Development Tips

### Visual Studio 2022 Features

1. **Hot Reload** (Press Alt + F10 while debugging)
   - Edit XAML and see changes instantly
   - Modify C# code and continue debugging

2. **Debugger**
   - Set breakpoints by clicking line numbers
   - Press F10 to step through code
   - Press F11 to step into functions

3. **NuGet Package Manager**
   - Tools → NuGet Package Manager → Package Manager Console
   - Type `Get-Help NuGet` for commands

### Useful Keyboard Shortcuts

| Shortcut | Action |
|----------|--------|
| F5 | Start Debug |
| Ctrl+F5 | Start Without Debug |
| Ctrl+Shift+B | Build Solution |
| Ctrl+Shift+F5 | Restart Debug |
| F10 | Step Over |
| F11 | Step Into |
| Ctrl+Alt+W | Watch Window |

## 🐛 Troubleshooting

### Issue: "The name 'Guid' does not exist in the current context"

**Solution:** Add using statement at the top of the file:
```csharp
using System;
```

### Issue: XAML Designer not showing

**Solution:**
1. Close the file
2. Clean Solution: **Build → Clean Solution**
3. Rebuild: **Ctrl + Shift + B**
4. Reopen the XAML file

### Issue: ".NET 9 SDK not found"

**Solution:**
1. Open **Tools → Options → Projects and Solutions → .NET**
2. Check "Use the latest .NET SDK"
3. Restart Visual Studio

### Issue: NuGet packages fail to restore

**Solution:**
```bash
dotnet nuget locals all --clear
dotnet restore
```

### Issue: Build fails with strange errors

**Solution:**
```bash
# Clean everything
dotnet clean
# Restore packages
dotnet restore
# Build fresh
dotnet build
```

## 📝 Project Configuration

### Target Framework

The project is configured for **.NET 9** in `nodebook.csproj`:

```xml
<TargetFramework>net9.0-windows</TargetFramework>
<UseWPF>true</UseWPF>
```

### Output Type

Configured as **Windows Desktop Application**:
```xml
<OutputType>WinExe</OutputType>
```

### Key Properties

```xml
<AssemblyName>NodeBook</AssemblyName>
<RootNamespace>VSCodeNodeEditor</RootNamespace>
<LangVersion>latest</LangVersion>
<Nullable>enable</Nullable>
```

## 🚀 Building for Release

To create a release build optimized for distribution:

```bash
dotnet publish -c Release -o ./publish
```

The executable will be in `./publish/NodeBook.exe`

## 📦 NuGet Dependencies

Currently included:
- **System.Text.Json** (v9.0.0) - For JSON serialization

No external WPF packages required! We're using the built-in WPF framework.

## 🔄 Keeping Updated

To update the .NET 9 SDK:

```bash
# Check latest version
dotnet sdk check

# Update through Visual Studio
# Tools → Extensions and Updates → Update Visual Studio
```

## 📚 Additional Resources

- [.NET 9 Release Notes](https://github.com/dotnet/core/releases/tag/v9.0.0)
- [WPF Documentation](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/)
- [Visual Studio 2022 Guide](https://learn.microsoft.com/en-us/visualstudio/ide/)
- [MVVM Pattern](https://learn.microsoft.com/en-us/dotnet/architecture/maui/mvvm)

## 💡 Tips for Success

1. **Keep Visual Studio Updated**
   - Check for updates regularly (Help → Check for Updates)

2. **Use Git for Version Control**
   - Visual Studio has built-in Git integration
   - View changes: View → Git Changes

3. **Enable Source Link**
   - Tools → Options → Debugging → Enable Source Link
   - Debug into .NET Framework code

4. **Use Solution Explorer**
   - View → Solution Explorer (Ctrl+Alt+L)
   - Drag and drop files to organize

## ✨ You're Ready!

Your NodeBook development environment is now fully set up with Visual Studio 2022 and .NET 9. Happy coding! 🎉

---

**Need Help?**
- Check [GETTING_STARTED.md](GETTING_STARTED.md) for usage guide
- Open an issue on [GitHub](https://github.com/code-tinker-art/nodebook/issues)
