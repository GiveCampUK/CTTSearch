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
            _routes.MapRoute("search", "Search", new {controller = "Search", action = "SearchEngine"});
            _routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );

				
            Console.WriteLine(GetType() + " completed OK.");
        }
    }
}