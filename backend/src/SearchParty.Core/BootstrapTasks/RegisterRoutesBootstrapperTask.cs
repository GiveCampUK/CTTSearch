namespace SearchParty.Core.BootstrapTasks
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using NBootstrap;

    public class RegisterRoutesBootstrapperTask : IBootstrapperTask
    {
        private readonly RouteCollection _routes;

        public RegisterRoutesBootstrapperTask(RouteCollection routes)
        {
            _routes = routes;
        }

        public void Execute()
        {
            _routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            _routes.IgnoreRoute("favicon.ico");

            _routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            _routes.MapRoute("resourceTags", "resource/listtags", new { controller = "Resource", action = "ListTags" });
            _routes.MapRoute("resourceIndex", "resource/index/{id}", new { controller = "Resource", action = "Index" });
            _routes.MapRoute("resourceUpdate", "resource/update/{id}", new { controller = "Resource", action = "Update" });
            _routes.MapRoute("categoryIndex", "category/index/{id}", new { controller = "Category", action = "Index" });
            _routes.MapRoute("categoryUpdate", "category/update/{id}", new {controller = "Category", action = "Update"});
            _routes.MapRoute("category", "category", new {controller = "Category", action = "Index"});
            _routes.MapRoute("searchLower", "search", new {controller = "Search", action = "SearchEngine"});
            _routes.MapRoute("search", "Search", new {controller = "Search", action = "SearchEngine"});
            _routes.MapRoute("searchQueries", "Search/Last/{count}", new {controller = "Search", action = "Last", count = 50});
            _routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );

            Console.WriteLine(GetType() + " completed OK.");
        }
    }
}