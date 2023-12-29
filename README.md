# godot-dotnet-template
A general template for Godot 4 Mono. Includes:
- Project Settings and General Configuration for Export and Development.
- CI/CD builds for Linux and Windows.
- Core System Managers (Video, Audio, Scenes, Input) with persistent and atomic configurations.
- Loading Screens with Multithreaded Loading.
- Barebones Main and Pause Menu with Video, Audio and Input Settings.
- Simple and Performant Logging plugin
- Miscellaneous Utilities

Using .NET 8.0 and the latest stable release of Godot Mono.

## Prerequisites
- Godot Mono (Latest Stable Release)
- .NET 8.0
- Visual Studio Code and/or JetBrains Rider

## How to use this template
1. Create new repository using template.
2. Clone repository locally
3. Change project name in Project Settings/Config/Name and Dotnet/Project/Assembly Name (in advanced settings)
4. Regenerate solution file in Tools/C#/Create C# Solution
5. Edit the .csproj file to change the NET version to 8.0
6. Rename the DotSettings files to the new assembly name
7. Delete .idea/.idea.NetTemplate, NetTemplate.sln and NetTemplate.csproj
8. Change text editor to Rider in Editor Settings/Dotnet/Editor/External Editor
9. Open and run the project in Rider (with tracing)
10. Change the editor back to VS Code
11. Open and run the project in VS Code
12. Uncomment relevant lines from .gitignore
13. Give actions more permissions in the github repository
14. Git commit and push, verify that everything is working

## TODO
- ~~Improve Input Management (ensure the configuration file is more readable)~~
- ~~Add Input Settings Functionality~~
- ~~Fix Video Manager's handling of WindowMode~~
- ~~Make Video, Audio, Scene and Input Managers Static~~
- ~~Adjust Configuration's saving functionality to minimize the performance cost of file writes while maintaining atomic writes~~
- ~~Add comments explaining design decisions and weird code~~
- ~~Refactor code to avoid Exceptions~~
- ~~Profile and Optimize~~
- ~~Try cloning and creating a new project to identify any potential issues~~

### Potential TODO
- Create a `setup.sh` script
- Add Unit Testing with automatic testing via Github Actions
- Create plug-in to easily change the logging level
- Incorporate CLI arguments into configuration setup
- Improve build action to include build versions and use rcedit
- Create a documentation system
