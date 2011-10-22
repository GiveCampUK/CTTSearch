// ReSharper disable CheckNamespace
namespace SearchParty.Api.ServiceLocation
{
    namespace SearchParty.Core.Data
    {
        using global::SearchParty.Core.Data;
        using Moq;
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

                //if you need to get up and running locally for the time being
                //_module.Bind<ISession>().ToMethod(x => new Mock<ISession>().Object).InRequestScope();
            }
        }
    }
}
// ReSharper restore CheckNamespace