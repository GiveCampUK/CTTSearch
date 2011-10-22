namespace SearchParty.Api
{
    using Ninject.Modules;
    using ServiceLocation.SearchParty.Core;

    /// <summary>
    ///   Bind<ISession>().ToMethod(x => SessionProvider.Instance.OpenSession()).InRequestScope();
    /// </summary>
    public class SearchPartyNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bindings.Clear();
            new ServiceLocatorBindings(this).BindAll();
            new ServiceLocation.System.Web.ServiceLocatorBindings(this).BindAll();
            new ServiceLocation.Bjma.Utility.Feature.ServiceLocatorBindings(this).BindAll();
            new ServiceLocation.Bjma.Utility.Tenancy.ServiceLocatorBindings(this).BindAll();
            new ServiceLocation.Bjma.Utility.Time.ServiceLocatorBindings(this).BindAll();
        }
    }
}