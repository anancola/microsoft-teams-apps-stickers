//----------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------

namespace StickersTemplate.Configuration
{
    using System;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

#pragma warning disable SA1649 // File name must match first type name
    /// <summary>
    /// Mvc Application
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
#pragma warning restore SA1649 // File name must match first type name
    {
        /// <summary>
        /// Application Start
        /// </summary>
        protected void Application_Start()
        {            
            // AntiForgeryConfig.RequireSsl = false;
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private void Application_EndRequest(object sender, EventArgs e)
        {
            Response.Headers["X-FRAME-OPTIONS"] = string.Empty;
        }
    }
}
