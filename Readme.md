# BindOpen.Logging

![BindOpen logo](https://storage.bindopen.org/img/logos/logo_bindopen.png)

![Github release version](https://img.shields.io/nuget/v/BindOpen.Abstractions.svg?style=plastic)


BindOpen is a framework that enables the development of highly extensible applications. It allows you to enhance your .NET projects with custom script functions, connectors, entities, and tasks.

## About

BindOpen.Logging offers a simple and multidimensional logging system, perfect to monitor nested task executions.

This repository contains the BindOpen.Logging code source.

A [full list of all the BindOpen.Kernel repos](https://www.nuget.org/packages?q=bindopen.kernel) is available as well.


## Install

To get started, install the BindOpen.Logging module you want to use.

Note: We recommend that later on, you install only the package you need.

### From Visual Studio

| Module | Instruction |
|--------|-----|
| [BindOpen.Logging](https://www.nuget.org/packages/BindOpen.Logging) | ```PM> Install-Package BindOpen.Logging``` |

### From .NET CLI

| Module | Instruction |
|--------|-----|
| [BindOpen.Logging](https://www.nuget.org/packages/BindOpen.Logging) | ```> dotnet add package BindOpen.Logging``` |

## Get started

### Dynamic logs

```csharp
    ...

    var log = BdoLogging.NewLog().WithTitle("A test log");

    TestMethodA(-1, log);

    if (log.HasErrors()) { Debug.Console(String.Format("Errors found ({0})", log.ToString())); }

    ...

private void TestMethodA(int num, IBdoLog log = null)
{
    if (num>0) { log?.AddWarning("Number should be negative"); return; }

    ...

    var subLog = log.InsertChild(BdoLogging.NewLog().WithTitle("Sub test log"));

    TestMethodA1("B" + num, subLog);
}

private void TestMethodA1(string st, IBdoLog log = null)
{
    if (st?.StartsWith("A") != true) { log?.InsertError("String must start with 'A'").WithResultCode("500"); return; }

    ...
}

```

### Basic loggers

```csharp
var logger = BdoLogging.NewLogger<BdoTraceLogger>();

var log = logger.NewRootLog();
log.AddCheckpoint("Checkpoint A");
            
logger.Log(log);
```

### External loggers

```csharp
// Example with Serilog

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(_filePath_serilog, rollingInterval: RollingInterval.Day)
    .CreateLogger();

var loggerFactory = new LoggerFactory();
loggerFactory.AddSerilog(Log.Logger);

var logger = BdoLogging.NewLogger(loggerFactory);

var log = BdoLogging.NewLog();
log.AddCheckpoint("Checkpoint A");
            
logger.Log(log);
```

## License

This project is licensed under the terms of the MIT license. [See LICENSE](https://github.com/bindopen/BindOpen.Logging/blob/master/LICENSE).

## Packages

This BindOpen.Logging module contains the following Nuget packages:

| Package | Provision |
|----------|-----|
| [BindOpen.Logging.Abstractions](https://www.nuget.org/packages/BindOpen.Logging.Abstractions) | Interfaces and enumerations |
| [BindOpen.Logging](https://www.nuget.org/packages/BindOpen.Logging) | Core package |
| [BindOpen.Logging.IO](https://www.nuget.org/packages/BindOpen.Logging.IO) | Serialization / Deserialization |
| [BindOpen.Logging.IO.Dtos](https://www.nuget.org/packages/BindOpen.Logging.IO.Dtos) | Data transfer classes |

The atomicity of these packages allows you install only what you need respecting your solution's architecture.

All of our NuGet packages are available from [our NuGet.org profile page](https://www.nuget.org/profiles/bindopen).


## Other repos and Projects

[BindOpen.Kernel](https://github.com/bindopen/BindOpen.Kernel) provides the core packages of BindOpen.

[BindOpen.Hosting](https://github.com/bindopen/BindOpen.Hosting) enables you to integrate a BindOpen agent within the .NET service builder.

[BindOpen.Labs](https://github.com/bindopen/BindOpen.Labs) is a collection of projects based on BindOpen.


A [full list of all the repos](https://github.com/bindopen?tab=repositories) is available as well.


## Documentation and Further Learning

### [BindOpen Docs](https://docs.bindopen.org/)

The BindOpen Docs are the ideal place to start if you are new to BindOpen. They are categorized in 3 broader topics:

* [Articles](https://docs.bindopen.org/articles) to learn how to use BindOpen;
* [Notes](https://docs.bindopen.org/notes) to follow our releases;
* [Api](https://docs.bindopen.org/api) to have an overview of BindOpen APIs.

### [BindOpen Blog](https://www.bindopen.org/blog)

The BindOpen Blog is where we announce new features, write engineering blog posts, demonstrate proof-of-concepts and features under development.


## Feedback

If you're having trouble with BindOpen, file a bug on the [BindOpen Issue Tracker](https://github.com/bindopen/BindOpen/issues). 

## Donation

You are welcome to support this project. All donations are optional but are greatly appreciated.

[![Please donate](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/donate/?hosted_button_id=PHG3WSUFYSMH4)


