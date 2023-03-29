# WindowsServiceTemplate

## Instructions

- Open Visual Studio 2022 and create a new project.
- In the "Create a new project" window, select "Windows Service (.NET)" and click "Next".
- Enter your project name, location, and solution name, then click "Create".
- Right-click on the project in the Solution Explorer, and click "Add" > "New Item".
- In the "Add New Item" window, select "Class" and name it "FileWriterService.cs" and click "Add".
- Modify FileWriterService.cs per FileWriterService.cs
- Modify Program.cs per Program.cs
- Set the project to build as a Windows Application. Right-click on the project in the Solution Explorer, and click "Properties". In the "Application" tab, change the "Output type" to "Windows Application".
- Build the solution by clicking "Build" > "Build Solution" in the menu or by pressing `Ctrl+Shift+B`.
- To install and start the service, you can use the `New-Service` PowerShell cmdlet. Open PowerShell with Administrator privileges and navigate to the output directory of your project (usually `bin\Debug` or `bin\Release`).
- Run the following command to install and start the service:
```
New-Service -Name "MyFileWriterService" -BinaryFilePath "C:\path\to\your\WindowsService.exe" -DisplayName "My File Writer Service" -Description "This service writes 'hello world' to a file at C:\test.txt" -StartupType Automatic
```
- Replace "C:\path\to\your\project" with the actual path to your project's output directory.
- Press `Enter` to install and start the service. If successful, the service should create the "C:\test.txt" file with the content "hello world".
- To stop and uninstall the service, first stop the service by running:
Then, uninstall the service using:
```
Get-WmiObject -Class
```