# Summary
These are instructions for building this project with a recent .NET SDK.

# Prerequisites
## .NET SDK
You can download one from Microsoft [here](https://dotnet.microsoft.com/en-us/download).  There are options for Windows, macOS, and Linux.

Unfortunately, these applications are pretty big (~700 MB).  But the entire SDK is required for the build, and for whatever you plan to do with the library later.  Note that the SDK is all you need; you don't need to install Visual Studio or anything.

I have tested this with .NET 8.0, but theoretically any supported release should work, so if you have some other version installed you should be able to just use that.

## Upgrade assistant tool
You will also need to download the upgrade assistant tool.  The official instructions are [here](https://learn.microsoft.com/en-us/dotnet/core/porting/upgrade-assistant-install#install-the-net-global-tool).

If you don't want to do a global install of the tool or are having trouble with it (I can't get it to work on macOS), you can do a local install.  On macOS/Linux, this looks like
```
cd PokemonGen1
dotnet new tool-manifest
dotnet tool install upgrade-assistant
```

## This repository
Clone the repo using this or your favorite other method:
```
git clone https://github.com/spacey-lacey/PokemonGen1.git
```
You also might want to create a new branch, since the upgraded code will be tied to a particular .NET version.

# Upgrading the project
Basically, follow the instructions from Microsoft [here](https://learn.microsoft.com/en-us/dotnet/core/porting/upgrade-assistant-overview#upgrade-with-the-cli-tool).

On macOS/Linux, the command to run the tool is
```
dotnet upgrade-assistant upgrade
```
This will open up an interactive interface that will guide you through a few options:

-For the `Source project` step, choose `PokemonGeneration1`.  This is where all the method and classes are.

-For `Upgrade Type`, choose `In-place project upgrade`.  This will overwrite the existing project, which is why you might want to make a new branch.  In any case, you can use `git checkout master` to get the original files back.

-For `Target Framework`, choose the one corresponding to the .NET version you have installed.

-For the confirmation step (`Upgrade`), input `y` or hit `Enter`.  (Unless you made a mistake, in which case you should input `n` and try again from the beginning.)

A whole bunch of stuff will be printed in the console.  If the process concludes with no errors, you're ready to go!

# Building the library
On macOS/Linux, you can run
```
dotnet msbuild PokemonGeneration1/PokemonGeneration1.csproj
```
This will build the library, and the console will print out the absolute path to the DLL.
