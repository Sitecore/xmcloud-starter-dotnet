using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Exceptions;
using Sitecore.AspNetCore.SDK.RenderingEngine.Attributes;
using Sitecore.AspNetCore.SDK.RenderingEngine.Interfaces;

namespace Sitecore.AspNetCore.Starter.Controllers
{
    public class DefaultController(ILogger<DefaultController> logger) : Controller
    {
        [UseSitecoreRendering]
        public IActionResult Index()
        {
            IActionResult? result = null;
            ISitecoreRenderingContext? request = HttpContext.GetSitecoreRenderingContext();
            if (request?.Response?.HasErrors ?? false)
            {
                foreach (SitecoreLayoutServiceClientException error in request.Response.Errors)
                {
                    switch (error)
                    {
                        default:
                            logger.LogError(error, error.Message);
                            throw error;
                    }
                }
            }
            else
            {
                result = View();
            }

            return result;
        }
    }
}
