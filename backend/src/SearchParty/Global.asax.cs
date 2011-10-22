namespace SearchParty.Api
{
    using System;
    using System.Web;
    using Core.BootstrapTasks;
    using NBootstrap;
    using NServiceLocator;
    using NServiceLocator.Ninject;
    using ServiceLocation;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        private static readonly IServiceLocator ServiceLocator =
            NinjectServiceLocator<SearchPartyNinjectModule>.GetInstance();

        //this is run once per HttpApplication
        protected void Application_Start()
        {
            try
            {
                Bootstrapper.Run(ServiceLocator, BootstrapperHelper.DefaultTaskRetrievalFunction<BootstrapperTask>);
            }
            catch (Exception e)
            {
                //log
                throw;
            }
        }

        ///// <summary>
        ///// NOTE 1: BA; this needs to happen here as the 
        ///// persistence of the results occurs, required 
        ///// for rendering.
        ///// </summary>
        protected void Application_EndRequest()
        {
            //MiniProfiler.Stop(); //see note 1
        }
    }
}