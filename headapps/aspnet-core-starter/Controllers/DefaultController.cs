using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Exceptions;
using Sitecore.AspNetCore.SDK.RenderingEngine.Attributes;
using Sitecore.AspNetCore.SDK.RenderingEngine.Interfaces;

namespace Sitecore.AspNetCore.Starter.Controllers
{
    public class DefaultController(ILogger<DefaultController> logger) : Controller
    {
        private const string EDITING_PATH = "/api/editing/config";

        [UseSitecoreRendering]
        public IActionResult Index()
        {
            IActionResult? result = null;
            ISitecoreRenderingContext? request = HttpContext.GetSitecoreRenderingContext();
            if ((request?.Response?.HasErrors ?? false) && !IsPageEditingRequest(request))
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

        private bool IsPageEditingRequest(ISitecoreRenderingContext request)
        {
            return request?.Controller?.HttpContext.Request.Path == EDITING_PATH;
        }
    }
}
