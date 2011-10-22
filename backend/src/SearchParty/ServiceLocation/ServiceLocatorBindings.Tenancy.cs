// ReSharper disable CheckNamespace
namespace SearchParty.Api.ServiceLocation
{
    namespace Bjma.Utility.Tenancy
    {
        using Core;
        using NFeature;
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
                _module.Bind<ITenancyContext<Tenant>>().To
                    <TenancyContext>();
            }
        }
    }
}

// ReSharper restore CheckNamespace