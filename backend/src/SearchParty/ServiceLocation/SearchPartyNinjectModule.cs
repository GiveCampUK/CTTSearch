namespace SearchParty.Api.ServiceLocation
{
    using Ninject.Modules;

    public class SearchPartyNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bindings.Clear();
            new SearchParty.Core.Data.ServiceLocatorBindings(this).BindAll();
            new SearchParty.Core.ServiceLocatorBindings(this).BindAll();
            new System.Web.ServiceLocatorBindings(this).BindAll();
            new Bjma.Utility.Feature.ServiceLocatorBindings(this).BindAll();
            new Bjma.Utility.Tenancy.ServiceLocatorBindings(this).BindAll();
            new Bjma.Utility.Time.ServiceLocatorBindings(this).BindAll();
            
        }
    }
}