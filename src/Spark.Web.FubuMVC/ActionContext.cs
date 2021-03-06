﻿using System.Web;
using System.Web.Routing;

namespace Spark.Web.FubuMVC
{
    public class ActionContext
    {
        private readonly string _actionNamespace;
        private readonly HttpContextBase _httpContext;
        private readonly RouteData _routeData;

        public ActionContext(HttpContextBase httpContext, RouteData routeData, string actionNamespace)
        {
            _httpContext = httpContext;
            _routeData = routeData;
            _actionNamespace = actionNamespace;
        }

        public RouteData RouteData
        {
            get { return _routeData; }
        }

        public string ActionNamespace
        {
            get { return _actionNamespace; }
        }

        public HttpContextBase HttpContext
        {
            get { return _httpContext; }
        }
    }
}