namespace SearchParty.Api
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("search", "Search", new {controller = "Search", action = "SearchController"});
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        /////////////
        ///// private static readonly IServiceLocator ServiceLocator =
        //    NinjectServiceLocator<WizeratiNinjectModule>.GetInstance();

        ////this is run once per HttpApplication
        //protected void Application_Start()
        //{
        //    try
        //    {
        //        Bootstrapper.Run(ServiceLocator, BootstrapperHelper.GetBootstrapperTasks<BootstrapperTask>);
        //    }
        //    catch (Exception e)
        //    {
        //        e.Log();
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// NOTE 1: BA; this needs to happen here as the 
        ///// persistence of the results occurs, required 
        ///// for rendering.
        ///// </summary>
        //protected void Application_EndRequest()
        //{
        //    MiniProfiler.Stop(); //see note 1
        //}
    }
}