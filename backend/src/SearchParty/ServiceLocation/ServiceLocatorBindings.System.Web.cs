// ReSharper disable CheckNamespace
namespace SearchParty.Api.ServiceLocation
{
    namespace System.Web
    {
        using global::System.Web;
        using global::System.Web.Mvc;
        using global::System.Web.Routing;
        using Ninject.Modules;

        public class ServiceLocatorBindings
        {
            private readonly NinjectModule _registrationModule;

            public ServiceLocatorBindings(NinjectModule registrationModule)
            {
                _registrationModule = registrationModule;
            }

            public void BindAll()
            {
                _registrationModule.Bind<HttpContext>().ToMethod(x => HttpContext.Current);
                _registrationModule.Bind<HttpContextBase>().ToMethod(x => new HttpContextWrapper(HttpContext.Current));
                _registrationModule.Bind<HttpRequestBase>().ToMethod(
                    x => new HttpRequestWrapper(HttpContext.Current.Request));
                _registrationModule.Bind<ControllerBuilder>().ToMethod(x => ControllerBuilder.Current);
                _registrationModule.Bind<GlobalFilterCollection>().ToSelf();
                _registrationModule.Bind<RouteCollection>().ToMethod(x => RouteTable.Routes);
            }
        }
    }
}

// ReSharper restore CheckNamespace