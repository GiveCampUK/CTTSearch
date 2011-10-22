// ReSharper disable CheckNamespace
namespace SearchParty.Api.ServiceLocation
{
    namespace MvcMiniProfiler
    {
        using global::MvcMiniProfiler;
        using Ninject.Modules;

        public class ServiceLocatorBindings
        {
            private readonly NinjectModule _module;

            public ServiceLocatorBindings(NinjectModule module)
            {
                _module = module;
            }

            /// <summary>
            ///   NOTE: BA; stop originally called in application_endrequest.
            /// </summary>
            public void BindAll()
            {
                _module.Bind<MiniProfiler>().ToMethod(x => MiniProfiler.Start()).InRequestScope();
                    //.OnDeactivation(x => MiniProfiler.Stop());
            }
        }
    }
}

// ReSharper restore CheckNamespace