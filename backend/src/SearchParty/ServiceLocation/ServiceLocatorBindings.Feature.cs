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
                    <IFeatureSettingAvailabilityChecker<Feature, Tenant, EmptyArgs>>()
                    .ToMethod(x => new FeatureSettingAvailabilityChecker<Feature,
                                        EmptyArgs,
                                        Tenant>((f,t) => true));
                _module.Bind<IFeatureSettingService<Feature, Tenant, EmptyArgs>>()
                    .To<FeatureSettingService<Feature, Tenant, EmptyArgs>>();
                _module.Bind<IFeatureManifestCreationStrategy<Feature>>()
                    .To<ManifestCreationStrategyDefault<Feature, Tenant>>();
                _module.Bind<IFeatureManifestService<Feature>>().To<FeatureManifestService<Feature>>();
                _module.Bind<IFeatureManifest<Feature>>()
                    .ToMethod(x => _module.Kernel.Get<IFeatureManifestService<Feature>>().GetManifest());
            }
        }
    }
}