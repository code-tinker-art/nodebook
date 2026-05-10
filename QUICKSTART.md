# Quick Start: Clone and Run NodeBook

## 🚀 30-Second Setup

### Step 1: Clone the Repository
```bash
git clone https://github.com/code-tinker-art/nodebook.git
cd nodebook
```

### Step 2: Open in Visual Studio 2022
1. Open **Visual Studio 2022**
2. Click **File → Open → Project/Solution**
3. Navigate to the `nodebook` folder
4. Select **`nodebook.csproj`** and click **Open**

Visual Studio will automatically load everything with .NET 9 support.

### Step 3: Build & Run
Press **F5** to start debugging

That's it! 🎉

---

## ⌨️ Alternative: Command Line Only

If you prefer not to use Visual Studio:

```bash
# Clone
git clone https://github.com/code-tinker-art/nodebook.git
cd nodebook

# Build
dotnet build

# Run
dotnet run
```

---

## ✅ Expected Result

When the app launches, you'll see:
- ✅ Dark theme window with NodeBook title
- ✅ File explorer sidebar on the left (showing your Documents folder)
- ✅ Editor area on the right with toolbar buttons
- ✅ "No file selected" message in the tab bar

---

## 🎯 Next Steps

1. **Create a test notebook:**
   - Create a file named `test.nbjson` in your Documents folder
   - Paste this content:
   ```json
   {
     "id": "test-001",
     "title": "Test Notebook",
     "cells": []
   }
   ```

2. **Open it in NodeBook:**
   - Click the file in the left sidebar
   - It loads automatically in the editor

3. **Add a cell:**
   - Click **➕ Add Cell** button
   - Write some Node.js code

4. **Save:**
   - Click **💾 Save** button

---

## 🐛 If Something Goes Wrong

### "Project not found"
- Make sure you cloned into the right folder
- Check that `nodebook.csproj` exists

### ".NET 9 not installed"
```bash
dotnet --version
```
- If not 9.0+, download from: https://dotnet.microsoft.com/download/dotnet/9.0

### Build errors
```bash
# Clean and rebuild
dotnet clean
dotnet build
```

### App won't start
- Make sure no other instance is running
- Try: **Build → Clean Solution** then rebuild
- Press **Ctrl+Shift+F5** to force restart

---

## 📚 More Information

- Full setup guide: [SETUP_DOTNET9.md](SETUP_DOTNET9.md)
- Usage guide: [GETTING_STARTED.md](GETTING_STARTED.md)
- Project overview: [README.md](README.md)

---

**That's all! Happy coding! 🚀**
