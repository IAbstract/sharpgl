# SharpGLX

A port of SharpGL to .Net 6.0.

Unlock the power of OpenGL in any .NET application. SharpGL[X] wraps all modern OpenGL features, provides helpful wrappers for advanced objects like Vertex Buffer Arrays and shaders, as well as offering a powerful Scene Graph and utility library to help you build your projects. A new approach to DesktopApp & Game design and development.

![Example of SharpGL](https://github.com/dwmkerr/sharpgl/blob/master/assets/frontscreen.png?raw=true)

*Will be removing WinForm and WPF samples as I create a toolbox and a cross-platform implementation of DesktopApp for customary forms applications. If someone wants to update WinForm and WPF implementations as I update and modernize to newer features of C# 7.0, I'm good with that. Unit tests and projects will be updated to include a couple of libraries I've developed over time that make my life easier.*

<!-- vim-markdown-toc GFM -->

* [Getting Started](#getting-started)
* [Developer Guide](#developer-guide)
    * [Releasing](#releasing)
* [Documentation](#documentation)
* [SharpGL Visual Studio Extensions](#sharpgl-visual-studio-extensions)
* [Credits, Sponsorship & Thanks](#credits-sponsorship--thanks)
* [Built with SharpGL](#built-with-sharpgl)

<!-- vim-markdown-toc -->

## Getting Started

SharpGL is made up of a number of packages, you can install whichever package or packages you need!

| Package | Link | Overview |
|---------|------|----------|
| `SharpGL` | [![SharpGL Core](https://img.shields.io/nuget/v/SharpGL.svg)](https://www.nuget.org/packages/SharpGL) | All OpenGL functions wrapped and ready to execute, as well as all OpenGL extensions. |
| `SharpGL.SceneGraph` | [![SharpGL SceneGraph](https://img.shields.io/nuget/v/SharpGL.SceneGraph.svg)](https://www.nuget.org/packages/SharpGL.SceneGraph) | The SceneGraph library contains a full class library which models key 3D entities. |
| `SharpGL.Serialization` | [![SharpGL Serialization](https://img.shields.io/nuget/v/SharpGL.Serialization.svg)](https://www.nuget.org/packages/SharpGL.Serialization) | The Serialization library contains utilities to load data from Discreet, Wavefront and Caligari file formats. |
| `SharpGL.WPF` | [![SharpGL WPF](https://img.shields.io/nuget/v/SharpGL.WPF.svg)](https://www.nuget.org/packages/SharpGL.WPF) | SharpGL for WPF includes the Core as well as OpenGL controls to drop into your WPF app. |
| `SharpGL.WinForms` | [![SharpGL WinForms](https://img.shields.io/nuget/v/SharpGL.WinForms.svg)](https://www.nuget.org/packages/SharpGL.WinForms)       | SharpGL for WinForms includes the Core as well as OpenGL controls to drop into your WinForms app. |

Install SharpGL packages with NuGet, either by using the Package Explorer or the Package Manager tool, e.g:

```
PM> Install-Package SharpGL
```

## Compatibility

SharpGL has built in support for OpenGL support, newer functions can be loaded on demand as needed. The table below shows the compatibility across frameworks and platforms.

**OpenGL**

Currently SharpGL has built in bindings for **OpenGL 4.0** - functions from later versions can be loaded at runtime as needed.

**Framework Compatibility**

All components support the .NET Framework 4.0 onwards, .NET Core 3.0 onwards and .NET Standard 2.1 onwards. Some components also support earlier versions.

| Component | .NET Framework | .NET Core | .NET Standard |
|-----------|----------------|-----------|---------------|
| `SharpGL` | x | 6.0+ | x |
| `SharpGL.SceneGraph` | x | 6.0+ | x |
| `SharpGL.Serialization` | x | 6.0+ | x |

**Platform Comptability** *to be updated...*

*Compatability across platforms is supported via framework specific components.*

## Developer Guide

To build the code, clone the repo and open the SharpGL, Samples or Tools solution. The Extensions solution is used for the Visual Studio Project Templates and requires additional components - you can find out more on the Wiki on the '[Developing SharpGL](https://github.com/dwmkerr/sharpgl/wiki/Developing-SharpGL)' page.

You can also use the following scripts to run the processes:

| Script         | Notes                                                                                                                   |
|----------------|-------------------------------------------------------------------------------------------------------------------------|
| `config.ps1`   | Ensure your machine can run builds by installing necessary components such as `nunit`. Should only need to be run once. |
| `build.ps1`    | Build all solutions. Ensures that we build both 32/64 bit versions of native components.                                |
| `test.ps1`     | Run all tests, including those in samples.                                                                              |
| `coverage.ps1` | Create a coverage report. Reports are written to `./artifacts/coverage`                                                 |
| `pack.ps1`     | Create all of the SharpGL NuGet packages, which are copied to `./artifacts/packages`.                                   |

These scripts will generate various artifacts which may be useful to review:

```
artifacts\
  \tests                  # NUnit Test Reports
  \coverage               # Coverage Reports
  \packages               # NuGet Packages
```

### Releasing  *to be updated...*

To make and publish a release:

1. Update the `*.csproj` files with the new version number
2. Create the version tag (e.g. `git tag v3.2.1`)
3. Push the code and tags (e.g. `git push --follow-tags`)

AppVeyor will automatically push the release to NuGet and GitHub.

## Documentation *to be updated...*

All documentation is available on [the Wiki](https://github.com/dwmkerr/sharpgl/wiki).

## SharpGL Visual Studio Extensions *to be updated...*

There are project templates available for SharpGL WinForms and WPF projects - just search for SharpGL on the Visual Studio Extensions gallery, or get the extensions directly:

* [SharpGL for Visual Studio 2010](http://visualstudiogallery.msdn.microsoft.com/ba57efa3-4061-4cdf-97f5-51715c4f120a)
* [SharpGL for Visual Studio 2012/2013](http://visualstudiogallery.msdn.microsoft.com/b61cc443-4790-42b7-b7ab-2691119667d2)

Please be aware that these extensions have not been maintained over time and I am looking for support in maintaining them.

## Credits, Sponsorship & Thanks *to be updated...*

SharpGL is written and maintained by me. Special thanks go to the following contributors:

 * [`robinsedlaczek`](https://github.com/robinsedlaczek) - Code and documentation updates, tireless patience 
   while I get through a backlog of work!
 * [`odalet`](https://github.com/odalet) - amazing work on internationalization and making the serialization code work in all locales

**NDepend**

![NDepend](https://github.com/dwmkerr/sharpgl/blob/master/assets/sponsors/ndepend.png?raw=true "NDepend")

SharpGL is proudly sponsored by NDepend! Find out more at [www.NDepend.com](http://www.NDepend.com).

**Red Gate**

![Red Gate](https://github.com/dwmkerr/sharpgl/blob/master/assets/sponsors/redgate.png?raw=true "Red Gate")

Many thanks to [Red Gate](http://www.red-gate.com/) who have kindly provided SharpGL with a copy of their superb [.NET Developer Bundle](http://www.red-gate.com/products/dotnet-development/dotnet-developer-bundle/)

**JetBrains**

[![JetBrains](https://github.com/dwmkerr/sharpgl/blob/master/assets/sponsors/jetbrains.png?raw=true "JetBrains")](https://www.jetbrains.com/?from=sharpgl)

Thanks for [JetBrains](https://www.jetbrains.com/?from=sharpgl) for sponsoring SharpGL with [Resharper](http://www.jetbrains.com/resharper/)!

## Built with SharpGL

If you've got a project that uses SharpGL and you'd like to show it off, just add the details here in a PR!

**[Open Vogel](https://sites.google.com/site/gahvogel/)**

Checkout https://sites.google.com/site/gahvogel/ to see a free, open source project which supports aerodynamics!

**[AgOpenGPS](https://github.com/farmerbriantee/AgOpenGPS)**

This is the *very first* open source Precision Agricultural App! Built by [Brian Tischler](https://github.com/farmerbriantee), you can see [the discussions and excitement on this project with farmers across the world](http://www.thecombineforum.com/forums/31-technology/278810-agopengps.html)!
