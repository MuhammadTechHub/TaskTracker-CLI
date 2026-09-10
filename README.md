<<<<<<< HEAD
# Task Tracker CLI

A command-line application for tracking tasks. It stores task data locally in a JSON file.

This project was built as part of the [roadmap.sh Task Tracker project](https://roadmap.sh/projects/task-tracker).

## Features

- Add, update, and delete tasks
- Mark tasks as `todo`, `in-progress`, or `done`
- List all tasks
- Filter tasks by status
- Store data locally in a JSON file

## Requirements

- .NET 10 SDK

## Run the project

```bash
dotnet run -- <command>
```

## Commands

| Action | Command |
| --- | --- |
| Add a task | `dotnet run -- add "Buy groceries"` |
| Update a task | `dotnet run -- update 1 "Buy groceries and cook dinner"` |
| Delete a task | `dotnet run -- delete 1` |
| Mark as in progress | `dotnet run -- mark-in-progress 1` |
| Mark as done | `dotnet run -- mark-done 1` |
| List all tasks | `dotnet run -- list` |
| List completed tasks | `dotnet run -- list done` |
| List todo tasks | `dotnet run -- list todo` |
| List in-progress tasks | `dotnet run -- list in-progress` |

## Data storage

Tasks are stored locally in `tasks.json`. This file is created automatically when needed and is excluded from Git so personal task data is not published.

## Project structure

```text
TaskTracker-CLI/
├── Models/           # Task model
├── Services/         # Task-related business logic
├── StorageBroker/    # JSON file storage
├── Program.cs        # Command-line entry point
└── TaskTracker-CLI.csproj
```
=======
Hello
>>>>>>> 9b0c55c7c396ea242c64974890f605173da0c73b
