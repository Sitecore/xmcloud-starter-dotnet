# XM Cloud ASP.NET Core Starter Kit
This repository contains the ASP.NET Core Starter Kit for Sitecore XM Cloud Development. It is intended to get developers up and running quickly with a new ASP.NET Core project that is integrated with Sitecore XM Cloud.

## Pre-release & Known Issues
> [!CAUTION]
> This is a pre-release version of the starter kit and is built against the pre-release version of the ASP.NET Core SDK. As such, there may be some issues with the project that are not yet resolved. If you encounter any issues, please report them in the [Issues](https://github.com/Sitecore/xmcloud-starter-aspnetcore/issues).

The following are known issues that are being worked on:
- **Navigation Component** - The OOTB Navigation component provided by XM Cloud currently isn't supported. This is being worked on and will be available in a future release. If you add the component to a page it can break deserialisation of the layout object and stop the page from rendering. In that scenario you will need to remove the layout via the Content Editor.
- **Front End as a Service (FEaaS)** - The FEaaS components are not yet available in the pre-release version of the Starter Kit.
- **Forms** - The Forms components are not yet available in the pre-release version of the Starter Kit.

## GitHub Template
This Github repository is a template that can be used to create your own repository. To get started, click the `Use this template` button at the top of the repository. 

## Prerequisites
- Access to an Sitecore XM Cloud Environment
- DotNet 8.0 (https://dotnet.microsoft.com/en-us/download)

## Getting Started Guide
For developers new to XM Cloud you can follow the Getting Started Guide on the [Sitecore Documentation Site](https://doc.sitecore.com/xmc) to get up and running with XM Cloud. This will walk you through the process of creating a new XM Cloud Project, provisioning an Environment, deploying the ASP.Net Core Starter Kit, and finally creating your first Component.

### Running the ASP.NET Core Starter Kit
> [!NOTE]
> the following steps will be rewritten and moved on to the documentation site in the future and linked to from here. The current steps assume the use of Visual Studio DevTunnels to enable the Pages editor. This approach may be revisited in the future.
> This is also current using the "old" connection method and needs to be updated to use the newer "ContextID" approach.

1. Create a repository from this template.
2. Log into the [Sitecore Deploy Portal](https://deploy.sitecorecloud.io/)
3. Create a new project using the 'bring your code' option, and select the repository you created in step 1.
4. When the deployment has finished click the "Go to XM Cloud" button to open the XM Cloud Environment.
5. Click on the Sites link in the top menu
6. Click the Create Site button
7. Select the 'Empty Site' template
8. Enter a name for the site and click the Create site button
9. When completed click the `Tools` link in the top menu/
10. Click the `Content Editor` button
11. When the Content Editor loads, make a note the URL loads under.
12. Navigate to `/sitecore/system/Settings/Services/API Keys`
13. Right-click on the API Keys Folder Item and choose `Insert -> API Key`.
14. Give the API Key a name and click the OK button.
15. Set the following Field values on the API Key
    - `CORS Origins` - `*`
    - `Allowed Controllers` - `*`
16. Make a note of the generated Item ID.
17. Return to the Deploy application, and find the Environment you created earlier.
18. Click on the Developer Settings button and make note of the `JSS_EDITING_SECRET` value shown.
19. Clone the repository to your local machine.
20. Open the `./headapps/aspnet-core-starter.sln` solution in Visual Studio.
21. Open the `appsettings.json` file in the `aspnetcore-starter` project.
22. Set the following values in the `Sitecore` section
    - `InstanceUri` - The url to the XM Cloud CM instance, which you recorded earlier. It should be in the format: `https://xmc-XXX-XXX-XXX.sitecorecloud.io/`
    - `DefaultSiteName` - The name of the Site created in step 8.
    - `ExperienceEdgeToken` - The Item ID of the API Key created in step 14.
    - `EditingSecret` - The JSS_EDITING_SECRET value from step 17.
23. Create a local dev tunnel in Visual Studio by following this [Guide](https://learn.microsoft.com/en-us/connectors/custom-connectors/port-tunneling)
24. Hit F5 to run the application from Visual Studio, ensuring you have enabled your dev tunnel.
25. When the page loads make a note of the URL, it should in the format `https://XXXX.devtunnels.ms/`
26. Return to the Content Editor
27. Navigate to the `/sitecore/system/Settings/Services/Rendering Hosts/Default` item, and set the following values
    - `Server side rendering engine endpoint URL` - `https://<<TUNNEL_URL>>/jss-render`
    - `Server side rendering engine application URL` - `https://<<TUNNEL_URL>>`
    - `Server side rendering engine configuration URL` - `https://<<TUNNEL_URL>>/api/editing/config`
28. Return to the Content Editor tab and Home icon in the top left corner (the nine square grid icon).
29. Click on the Pages icon
30. You will be taken to Pages connected to the head application running on your local devleoper machine. You can now add and remove components from the page and see the changes reflected in real-time. Please note the known issues stated above to see which components are not yet supported.

## Building SASS Stylesheet
TODO: Add steps to build scss assets.

## Disconnected offline development
It is possible to mock a small subset of the XM Cloud Application elements to enable offline development. This can allow for a disconnected development experience, however it is recommend to work in the default connected mode.

You can find more information about how setup the offline development experience [here](./local-containers/README.md)