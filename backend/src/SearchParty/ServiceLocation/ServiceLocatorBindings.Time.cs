// ReSharper disable CheckNamespace
namespace SearchParty.Api.ServiceLocation
{
    namespace Bjma.Utility.Time
    {
        using NFeature;
        using NFeature.DefaultImplementations;
        using Ninject.Modules;

        public class ServiceLocatorBindings
        {
            private readonly NinjectModule _module;

            public ServiceLocatorBindings(NinjectModule module)
            {
                _module = module;
            }

            public void BindAll()
            {
                _module.Bind<IApplicationClock>().To
                    <ApplicationClock>();
            }
        }
    }
}

// ReSharper restore CheckNamespace