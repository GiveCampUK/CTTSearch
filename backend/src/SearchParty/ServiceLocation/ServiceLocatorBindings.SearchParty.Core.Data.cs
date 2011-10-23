// ReSharper disable CheckNamespace
namespace SearchParty.Api.ServiceLocation
{
    namespace SearchParty.Core.Data
    {
        using global::SearchParty.Core.Data;
        using NHibernate;
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
                _module.Bind<ISession>().ToMethod(x => NHibernateSessionHelper.OpenSession()).InRequestScope();

            }
        }
    }
}
// ReSharper restore CheckNamespace