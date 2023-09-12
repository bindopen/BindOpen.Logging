# BindOpen.Kernel.Logging

![BindOpen logo](https://storage.bindopen.org/img/logos/logo_bindopen.png)

![Github release version](https://img.shields.io/nuget/v/BindOpen.Kernel.Abstractions.svg?style=plastic)


BindOpen is a framework that enables the development of highly extensible applications. It allows you to enhance your .NET projects with custom script functions, connectors, entities, and tasks.

## About

BindOpen.Kernel.Logging offers a simple and multidimensional logging system, perfect to monitor nested task executions.

This repository contains the BindOpen.Kernel.Logging code source.

A [full list of all the BindOpen.Kernel repos](https://www.nuget.org/packages?q=bindopen.kernel) is available as well.


## Install

To get started, install the BindOpen.Kernel.Logging module you want to use.

Note: We recommend that later on, you install only the package you need.

### From Visual Studio

| Module | Instruction |
|--------|-----|
| [BindOpen.Kernel.Logging](https://www.nuget.org/packages/BindOpen.Kernel.Logging) | ```PM> Install-Package BindOpen.Kernel.Logging``` |

### From .NET CLI

| Module | Instruction |
|--------|-----|
| [BindOpen.Kernel.Logging](https://www.nuget.org/packages/BindOpen.Kernel.Logging) | ```> dotnet add package BindOpen.Kernel.Logging``` |

## Get started

### Dynamic tracking logs

```csharp
    ...

    var log = BdoLogging.NewLog().WithDisplayName("A test log");

    TestMethodA(-1, log);

    if (log.HasErrors()) { Debug.Console(String.Format("Errors found ({0})", log.ToString())); }

    ...

private void TestMethodA(int num, IBdoLog log = null)
{
    if (num>0) { log?.AddWarning("Number should be negative"); return; }

    ...

    var subLog = log.InsertChild(BdoLogging.NewLog().WithDisplayName("Sub test log"));

    TestMethodA1("B" + num, subLog);
}

private void TestMethodA1(string st, IBdoLog log = null)
{
    if (!st?.StartWith("A")) { log?.InsertError("String must start with 'A'").WithResultCode("500"); return; }

    ...
}

```

### Native loggers

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

var log = logger.NewLog();
log.AddCheckpoint("Checkpoint A");
            
logger.Log(log);
```

## License

This project is licensed under the terms of the MIT license. [See LICENSE](https://github.com/bindopen/BindOpen.Kernel.Logging/blob/master/LICENSE).

## Packages

This BindOpen.Kernel.Logging module contains the following Nuget packages:

| Package | Provision |
|----------|-----|
| [BindOpen.Kernel.Logging.Abstractions](https://www.nuget.org/packages/BindOpen.Kernel.Logging.Abstractions) | Interfaces and enumerations |
| [BindOpen.Kernel.Logging](https://www.nuget.org/packages/BindOpen.Kernel.Data) | Core package |
| [BindOpen.Kernel.Logging.IO](https://www.nuget.org/packages/BindOpen.Kernel.Logging.IO) | Serialization / Deserialization |
| [BindOpen.Kernel.Logging.IO.Dtos](https://www.nuget.org/packages/BindOpen.Kernel.Logging.IO.Dtos) | Data transfer classes |

The atomicity of these packages allows you install only what you need respecting your solution's architecture.

All of our NuGet packages are available from [our NuGet.org profile page](https://www.nuget.org/profiles/bindopen).


## Other repos and Projects

[BindOpen.Kernel](https://github.com/bindopen/BindOpen.Kernel) provides the core packages of BindOpen.

[BindOpen.Kernel.Hosting](https://github.com/bindopen/BindOpen.Kernel.Hosting) enables you to integrate a BindOpen agent within the .NET service builder.

[BindOpen.Labs](https://github.com/bindopen/BindOpen.Labs) is a collection of projects based on BindOpen.Kernel.


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


