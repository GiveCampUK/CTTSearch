namespace SearchParty.Api.ServiceLocation
{
    namespace Bjma.Utility.Feature
    {
        using Core;
        using global::System;
        using NFeature;
        using NFeature.DefaultImplementations;
        using Ninject;
        using Ninject.Modules;
        using SearchParty.Core;

        public class ServiceLocatorBindings
        {
            private readonly NinjectModule _module;

            public ServiceLocatorBindings(NinjectModule module)
            {
                _module = module;
            }

            public void BindAll()
            {
                _module.Bind<IFeatureSettingRepository<Feature, Tenant>>().To
                    <AppConfigFeatureSettingRepository<Feature, Tenant>>();
                _module.Bind
                    <IFeatureSettingAvailabilityChecker<Feature, Tenant, Tuple<FeatureVisibilityMode, Tenant, DateTime>>
                        >()
                    .ToMethod(x => new FeatureSettingAvailabilityChecker<Feature,
                                        Tuple<FeatureVisibilityMode, Tenant, DateTime>,
                                        Tenant>(DefaultFunctions.AvailabilityCheckFunction));
                _module.Bind<IFeatureSettingService<Feature, Tenant, Tuple<FeatureVisibilityMode, Tenant, DateTime>>>()
                    .To<FeatureSettingService<Feature, Tenant, Tuple<FeatureVisibilityMode, Tenant, DateTime>>>();
                _module.Bind<IFeatureManifestCreationStrategy<Feature>>()
                    .To<ManifestCreationStrategyConsideringStateCookieTenantAndTime<Feature, Tenant>>();
                _module.Bind<IFeatureManifestService<Feature>>().To<FeatureManifestService<Feature>>();
                _module.Bind<IFeatureManifest<Feature>>()
                    .ToMethod(x => _module.Kernel.Get<IFeatureManifestService<Feature>>().GetManifest());
            }
        }
    }
}