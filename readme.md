## Vements Client Library for C#

The Vements Client Library for C# is a C# library for accessing the Vements API.  It also includes a command line tool that can be used to interact with the API in scripts or in a terminal.


### Documentation

See the [C# API docs]() for more information on how to use this library.

### Installation

To install the Vements Client Library for C#, use the following command:

```bash
$ dotnet add package vements
```

### Usage 

The following example shows how to use the Vements Client Library for C# to create a new Vements client, and then use that client to create a new Vements scoreboard.

```c#
using Vements.API;

... 

var client = vements.Client();
var scoreboard = client.create_scoreboard(display="My Scoreboard", rank_dir="desc", public=False);
```

### Command Line Tool

The Vements Client Library for C# includes a command line tool that can be used to interact with the Vements API. The command line tool supports all of the same operations as the API.

#### Build 

To build the CLI:

```bash
$ dotnet publish -c release -r osx-arm64 --self-contained
```

Substitute `osx-arm64` with the appropriate runtime identifier for your platform, e.g.: `linux-x64`, `linux-arm64`, `win-x64`, `win-arm64`, etc.

#### Usage

```bash 
$ vements --help
Achievements and scoreboards for everyone

Usage: vements [command] [options]

Options:
  --api-key       API Key
  --verbose       Verbose output
  -?|-h|--help    Show help information.

Commands:
  achievement     Achievement operations
  api-version     Show API version
  client-version  Show client library version
  participant     Participant operations
  scoreboard      Scoreboard operations

Run 'vements [command] -?|-h|--help' for more information about a command.
```

The C# CLI tool supports all of the same operations as the CLI tool in other languages:

* achievement CRUD, list, leaderboard, record progress
* participant CRUD, list, progress, scores
* scoreboard CRUD, list, scoreboard, record score

The above commands all support the following options:

* `--api-key` to specify the API key
* `--verbose` to show verbose output

In addition to resource commands, these common commands are also supported:

* `api-version` to show the API version
* `client-version` to show the client library version

The library and CLI both support the following environment variables:

* `API_KEY` to specify the API key
* `SERVER_TAGS` to specify the tags used to select the server URL

