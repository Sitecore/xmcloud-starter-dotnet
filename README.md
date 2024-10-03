# XM Cloud ASP.NET Core Starter Kit
This repository contains the ASP.NET Core Starter Kit for Sitecore XM Cloud Development. It is intended to get developers up and running quickly with a new ASP.NET Core project that is integrated with Sitecore XM Cloud.

## Pre-release & Known Issues
> [!CAUTION]
> This is a pre-release version of the starter kit and is built against the pre-release version of the ASP.NET Core SDK. As such, there may be some issues with the project that are not yet resolved. If you encounter any issues, please report them in the [Issues](https://github.com/Sitecore/xmcloud-starter-aspnetcore/issues) section of the repo.

The following are known issues that are being worked on:
- **Front End as a Service (FEaaS)** - The FEaaS components are not yet available in the pre-release version of the Starter Kit.
- **Forms** - The Forms components are not yet available in the pre-release version of the Starter Kit.

## GitHub Template
This Github repository is a template that can be used to create your own repository. To get started, click the `Use this template` button at the top of the repository. 

## Prerequisites
- Access to an Sitecore XM Cloud Environment
- DotNet 8.0 (https://dotnet.microsoft.com/en-us/download)

## Getting Started Guide
> [!NOTE]
> The XM Cloud Getting Started Guide currently only caters for Next.js applications. As part of the work in getting the ASP.NET Core Starter Kit ready for release, the documentation will be updated to include the steps required to get started with the ASP.NET Core Starter Kit. For now a temporary section has been added below which will quickly walk through the process.

~~For developers new to XM Cloud you can follow the Getting Started Guide on the [Sitecore Documentation Site](https://doc.sitecore.com/xmc) to get up and running with XM Cloud. This will walk you through the process of creating a new XM Cloud Project, provisioning an Environment, deploying the ASP.Net Core Starter Kit, and finally creating your first Component.~~

### Running the ASP.NET Core Starter Kit
> [!NOTE]
> Temporary steps to get the ASP.NET Core Starter Kit up and running. This will be removed when the documentation Getting Started Guide is updated to include the ASP.NET Core Starter Kit steps.

1. Create a repository from this template.
2. Log into the [Sitecore Deploy Portal](https://deploy.sitecorecloud.io/)
3. Create a new project using the 'bring your code' option, and select the repository you created in step 1.
4. When the deployment has finished click the "Go to XM Cloud" button to open the XM Cloud Environment.
5. Click on the Sites link in the top menu
6. Click the Create Site button
7. Select the 'Empty Site' template

8. Return to the Deploy application, and find the Environment you created earlier.
9. Ensure the `Context` toggle is set to `Preview` otherwise you wont see any changes you make till they're published.
10. Click on the Developer Settings tab and make note of the `JSS_EDITING_SECRET` and `SITECORE_EDGE_CONTEXT_ID` values shown.
11. Clone the repository to your local machine.
12. Open the `./headapps/aspnet-core-starter.sln` solution in Visual Studio.
13. Make a copy the `appsettings.json` file in the `aspnet-core-starter` project, and name it `appsettings.Development.json`.
14. Set the following values in the `Sitecore` section of the `appsettings.json` file:
    - `EdgeContextId` - The `SITECORE_EDGE_CONTEXT_ID` value from step 10.
    - `EditingSecret` - The `JSS_EDITING_SECRET` value from step 10.
15. Run the application from within Visual Studio by hitting F5, or using the dotnet CLI with `dotnet run`.
16. You will now be able to access the application at `https://localhost:5001/`.

### Connecting Pages to your locally running application
> [!NOTE]
> Temporary steps to connect Pages to your locally running application. This will be updated Meta Page Editing mode is supported.

1. Open `./headapps/aspnet-core-starter.sln` in Visual Studio then Create a local dev tunnel by following this [guide](https://learn.microsoft.com/en-us/connectors/custom-connectors/port-tunneling)
2. Hit F5 to run the application from Visual Studio, ensuring you have enabled your dev tunnel.
3. When the page loads make a note of the URL, it should in the format `https://XXXX.devtunnels.ms/`. If successful you should see a plan white page rendered.
4. Return to the Content Editor
5. Navigate to the `/sitecore/system/Settings/Services/Rendering Hosts/Default` item, and set the following values, ensuring you save the changes:
    - `Server side rendering engine endpoint URL` - `https://<<TUNNEL_URL>>/jss-render`
    - `Server side rendering engine application URL` - `https://<<TUNNEL_URL>>`
    - `Server side rendering engine configuration URL` - `https://<<TUNNEL_URL>>/api/editing/config`
6. Click the Home icon in the top left corner of the Content Editor (the nine square grid icon).
7. Click on the Pages icon
8. You will be taken to your Pages instance, which is now connected to the head application running on your local devleoper machine. You can now add and remove components from the page and see the changes reflected in real-time. Please note the known issues stated above to see which components are not yet supported.

## Disconnected offline development
It is possible to mock a small subset of the XM Cloud Application elements to enable offline development. This can allow for a disconnected development experience, however it is recommend to work in the default connected mode.

You can find more information about how setup the offline development experience [here](./local-containers/README.md)