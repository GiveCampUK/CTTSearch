// ReSharper disable CheckNamespace
namespace SearchParty.Api.ServiceLocation
{
    namespace SearchParty.Core
    {
        using global::SearchParty.Core.Commands;
        using Ninject.Modules;
        using NServiceLocator;
        using NServiceLocator.Ninject;

        public class ServiceLocatorBindings
        {
            private readonly NinjectModule _module;

            public ServiceLocatorBindings(NinjectModule module)
            {
                _module = module;
            }

            public void BindAll()
            {
                _module.Bind<IServiceLocator>().ToMethod(
                    x => NinjectServiceLocator<SearchPartyNinjectModule>.GetInstance()); //singleton, no public ctor
                _module.Bind<SearchCommand>().ToSelf();
            }
        }
    }
}

// ReSharper restore CheckNamespace