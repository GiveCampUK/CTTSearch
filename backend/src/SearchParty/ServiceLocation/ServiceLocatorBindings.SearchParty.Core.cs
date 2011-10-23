// ReSharper disable CheckNamespace
namespace SearchParty.Api.ServiceLocation
{
    namespace SearchParty.Core
    {
        using global::Bjma.Utility.DataAccess;
        using global::SearchParty.Core.Commands;
        using global::SearchParty.Core.Models;
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
                _module.Bind<IServiceLocator>().ToMethod(x => NinjectServiceLocator<SearchPartyNinjectModule>.GetInstance()); 
                _module.Bind<IRepository<Resource>>().To<ResourceRepository>();
                _module.Bind<SearchCommand>().ToSelf();
                _module.Bind<CategoryCommand>().ToSelf();
                _module.Bind<CategoryUpdateCommand>().ToSelf();
                _module.Bind<ResourceCommand>().ToSelf();
                _module.Bind<ResourceUpdateCommand>().ToSelf();
            }
        }
    }
}
// ReSharper restore CheckNamespace