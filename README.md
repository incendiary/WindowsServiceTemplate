# WindowsServiceTemplate

A minimal C# (.NET 8) Windows Service template demonstrating the classic `ServiceBase` pattern. Intended as a starting point — clone it, rename the namespace, and add your own logic to `OnStart` and `OnStop`.

> **Note:** This repository was prepared with heavy assistance from Claude Code (Anthropic). Things should work, but in some cases the output hasn't been verified on a live Windows machine. PRs and fixes are very welcome.

---

## What it does

On service start, writes `hello world` to `C:\test.txt`. That's it — the point is the scaffold, not the business logic.

---

## Prerequisites

- Windows 10/11 or Windows Server 2016+
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)
- Visual Studio 2022 **or** the `dotnet` CLI
- PowerShell (Administrator) for service installation

---

## Setup

### Option A — Visual Studio 2022

1. Open the `.sln` (or create a new **Windows Service (.NET)** project and copy in `Program.cs` and `FileWriterService.cs`).
2. Right-click the project → **Properties** → **Application** → set **Output type** to `Windows Application`.
3. Build: **Build → Build Solution** (`Ctrl+Shift+B`).

### Option B — dotnet CLI

```powershell
dotnet build -c Release
```

The executable lands in `bin\Release\net8.0-windows\`.

### Installing the service

Open PowerShell as **Administrator** and run:

```powershell
New-Service `
  -Name "MyFileWriterService" `
  -BinaryPathName "C:\path\to\WindowsServiceTemplate.exe" `
  -DisplayName "My File Writer Service" `
  -Description "Writes 'hello world' to C:\test.txt on start" `
  -StartupType Automatic

Start-Service -Name "MyFileWriterService"
```

Replace the path with the actual output directory (`bin\Release\net8.0-windows\` or `bin\Debug\net8.0-windows\`).

### Stopping and uninstalling the service

```powershell
Stop-Service  -Name "MyFileWriterService"
Remove-Service -Name "MyFileWriterService"
```

> `Remove-Service` requires PowerShell 6+ or Windows PowerShell on Windows Server 2019+. On older hosts use `sc.exe delete MyFileWriterService`.

---

## Pre-commit hooks (recommended)

This repo ships a `.pre-commit-config.yaml` that runs [GitLeaks](https://github.com/gitleaks/gitleaks) (secret scanning) and `dotnet format` before every commit.

```powershell
# Install pre-commit (once, requires Python)
pip install pre-commit
pre-commit install
```

After that, hooks run automatically on `git commit`.

---

## Roadmap

| # | Status | Description |
|---|--------|-------------|
| [#1](https://github.com/incendiary/WindowsServiceTemplate/issues/1) | ✅ Done | Add `.gitignore`, `.editorconfig`, and pre-commit hooks |
| [#2](https://github.com/incendiary/WindowsServiceTemplate/issues/2) | ✅ Done | Update README with setup instructions and roadmap |
| [#3](https://github.com/incendiary/WindowsServiceTemplate/issues/3) | 🔲 Open | Enable branch protection on `main` |
| [#4](https://github.com/incendiary/WindowsServiceTemplate/issues/4) | 🔲 Open | Add unit/integration tests for `FileWriterService` |

---

## Contributing

PRs welcome. Please run `pre-commit install` before your first commit so the hooks catch formatting and secret issues early.
