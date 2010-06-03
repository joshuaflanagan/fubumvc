using System;
using System.Web;
using System.Web.Routing;
using FubuMVC.Core.Diagnostics;

namespace FubuMVC.Core.Web
{
    public class WebResourceRouteHandler : IRouteHandler
    {
        private readonly Type _resourcePathType;
        private readonly string _resourcePath;
        private readonly string _contentType;

        public WebResourceRouteHandler(Type typeInSameFolderAsResource, string resourcePath, string contentType)
        {
            _resourcePathType = typeInSameFolderAsResource;
            _resourcePath = resourcePath;
            _contentType = contentType;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new WebResourceHandler(this);
        }
        
        class WebResourceHandler : IHttpHandler
        {
            private readonly WebResourceRouteHandler _routeHandler;

            public WebResourceHandler(WebResourceRouteHandler routeHandler)
            {
                _routeHandler = routeHandler;
            }

            public void ProcessRequest(HttpContext context)
            {
                var resourceText = DiagnosticHtml.GetResourceText(_routeHandler._resourcePathType, _routeHandler._resourcePath);
                context.Response.Clear();
                context.Response.ContentType = _routeHandler._contentType;
                context.Response.Write(resourceText);
            }

            public bool IsReusable
            {
                get { return false; }
            }
        }
    }
}