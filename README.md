# XM Cloud ASP.NET Core Starter Kit
This repository contains the ASP.NET Core Starter Kit for Sitecore XM Cloud Development. It is intended to get developers up and running quickly with a new ASP.NET Core project that is integrated with Sitecore XM Cloud.

## GitHub Template
This Github repository is a template that can be used to create your own repository. To get started, click the `Use this template` button at the top of the repository. 

### Prerequisites
- Access to an Sitecore XM Cloud Environment
- DotNet 8.0 (https://dotnet.microsoft.com/en-us/download)

### Getting Started Guide
For developers new to XM Cloud you can follow the Getting Started Guide on the [Sitecore Documentation Site](https://doc.sitecore.com/xmc) to get up and running with XM Cloud. This will walk you through the process of creating a new XM Cloud Project, provisioning an Environment, deploying the ASP.Net Core Starter Kit, and finally creating your first Component.

### Temporary Pre-req
Download the nupkg files from the following locations and place them in the `/headapps/lib` folder: https://github.com/Sitecore/ASP.NET-Core-SDK/releases/tag/0.0.4

### Running the ASP.NET Core Starter Kit
TODO: Add steps for running the ASP.NET Core Starter Kit locally.

## Disconnected offline development
It is possible to mock a small subset of the XM Cloud Application elements to enable offline development. This can allow for a disconnected development experience, however it is recommend to work in the default connected mode.

You can find more information about how setup the offline development experience [here](./localContainers/README.md)