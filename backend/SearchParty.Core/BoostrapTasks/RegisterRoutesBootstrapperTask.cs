namespace SearchParty.Core.BoostrapTasks
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

            _routes.MapRoute(
                "Default", // Route name
                "{itemType}/{controller}/{action}/{id}", // URL with parameters
                new {itemType = new NullDto(), controller = "Home", action = "Index", id = UrlParameter.Optional});
                // Parameter defaults;

            Console.WriteLine(GetType() + " completed OK.");
        }
    }

    public class NullDto {}
}