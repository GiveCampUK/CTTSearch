namespace SearchParty.Api.ServiceLocation
{
    using Ninject.Modules;
    using SearchParty.Core;

    /// <summary>
    ///   Bind<ISession>().ToMethod(x => SessionProvider.Instance.OpenSession()).InRequestScope();
    /// </summary>
    public class SearchPartyNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bindings.Clear();
            new ServiceLocatorBindings(this).BindAll();
            new System.Web.ServiceLocatorBindings(this).BindAll();
            new Bjma.Utility.Feature.ServiceLocatorBindings(this).BindAll();
            new Bjma.Utility.Tenancy.ServiceLocatorBindings(this).BindAll();
            new Bjma.Utility.Time.ServiceLocatorBindings(this).BindAll();
        }
    }
}