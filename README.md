# TflWebClient
Web API Client to get Road Status given a Road Id. Eg.: A1, A2

## Platform
.NET Framework 4.6.1+ (Windows)

## Prerequisites
C# with these runtimes / IDEs
Windows: .NET Framework 4.6.1+, Visual Studio 2017 or newer, Visual Studio Code

## Build TflWebClient on Windows:
Clone TflWebClient through git clone https://github.com/GabSys/TflWebClient

Open TFL.WebClientConsole\TFL.WebClientConsole.sln in Visual Studio.

Select the target Platform and Configuration (Debug/Release) and build the solution. The solution will need to pull 3 packages from nuget.

Build output will be under TFL.WebClientConsole\TFL.WebClientConsole\bin\Debug\ or TFL.WebClientConsole\TFL.WebClientConsole\bin\Release\.

## Running TflWebClient

Edit the TFL.WebClientConsole.exe.congif file in folder $\TFL.WebClientConsole\TFL.WebClientConsole\bin\Release to add you new app id and app key required to connect to the web api.

Open Windows Power Shell or Command Line (cmd).

Go to the git folder under $\TFL.WebClientConsole\TFL.WebClientConsole\bin\Release

Type Tfl.WebClientConsole.exe and provide one argument with a road id.

    Eg.: 
    PS C:\Users\user\source\repos\TFL.WebClientConsole\TFL.WebClientConsole\bin\release> .\TFL.WebClientConsole.exe a1

If the road is valid it will display status and ask to press a key if road is invalid it will show an informative error and will exit.

## Running Tests
Tfl.WebClient.Test is using MSTest Framework (.net) as the testing framework.
Under Visual Studio you should be able to run all the tests using Test Explorer.

## Dependencies
TFL.WebClientConsole uses Newtonsoft.Json to deserialize json strig from the Web Api response into an object.

TFL.WebClientConsole.Test uses Moq nuget package to Mock object for unit testing. Eg.: Mock an http client wrapper so that it returns
the a valid or invalid response without connecting to the Api Url.

TFL.WebClientConsole.Test contains 2 Json files with valid or invalid examples of responses in order to test the logic the "Client" class
without connecting to a web url.
