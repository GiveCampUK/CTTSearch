// ReSharper disable CheckNamespace
namespace SearchParty.Api.ServiceLocation
{
    namespace SearchParty.Core
    {
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
            }
        }
    }

    namespace System.Web
    {
        using global::System.Web;
        using global::System.Web.Mvc;
        using global::System.Web.Routing;
        using Ninject.Modules;

        public class ServiceLocatorBindings
        {
            private readonly NinjectModule _registrationModule;

            public ServiceLocatorBindings(NinjectModule registrationModule)
            {
                _registrationModule = registrationModule;
            }

            public void BindAll()
            {
                _registrationModule.Bind<HttpContext>().ToMethod(x => HttpContext.Current);
                _registrationModule.Bind<HttpContextBase>().ToMethod(x => new HttpContextWrapper(HttpContext.Current));
                _registrationModule.Bind<HttpRequestBase>().ToMethod(
                    x => new HttpRequestWrapper(HttpContext.Current.Request));
                _registrationModule.Bind<ControllerBuilder>().ToMethod(x => ControllerBuilder.Current);
                _registrationModule.Bind<GlobalFilterCollection>().ToSelf();
                _registrationModule.Bind<RouteCollection>().ToMethod(x => RouteTable.Routes);
            }
        }
    }

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

    namespace Bjma.Utility.Time
    {
        using NFeature;
        using NFeature.DefaultImplementations;
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
                _module.Bind<IApplicationClock>().To
                    <ApplicationClock>();
            }
        }
    }

    namespace MvcMiniProfiler
    {
        using global::MvcMiniProfiler;
        using Ninject.Modules;

        public class ServiceLocatorBindings
        {
            private readonly NinjectModule _module;

            public ServiceLocatorBindings(NinjectModule module)
            {
                _module = module;
            }

            /// <summary>
            /// NOTE: BA; stop originally called in application_endrequest.
            /// </summary>
            public void BindAll()
            {
                _module.Bind<MiniProfiler>().ToMethod(x => MiniProfiler.Start()).InRequestScope();//.OnDeactivation(x => MiniProfiler.Stop());
            }
        }
    }

    namespace Bjma.Utility.Feature
    {
        using Core;
        using global::System;
        using NFeature;
        using NFeature.DefaultImplementations;
        using Ninject;
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

                ////var availabilityChecker = new FeatureSettingAvailabilityChecker<Feature, Tenant>(fn); //from step 2      
                ////var featureSettingService = new FeatureSettingService<Feature, Tenant, EmptyArgs>(availabilityChecker, featureSettingRepo);
                ////var manifestCreationStrategy = new ManifestCreationStrategyDefault<Feature,Tenant>(featureSettingRepo, featureSettingService); //we use the default for this example
                ////var featureManifestService = new FeatureManifestService<Utility.Feature>(manifestCreationStrategy);
                //var featureManifest = featureManifestService.GetManifest(); 


                //_module.Bind<IFeatureSettingDependencyChecker>().To<FeatureSettingDependencyChecker>();
                //_module.Bind<IFeatureSettingRepository>().To<WebConfigFeatureSettingRepository>();
                //_module.Bind<IFeatureSettingService>().To<FeatureSettingService<Utility.Feature>>();
                //_module.Bind<IFeatureManifestCreationStrategy>().To<DefaultFeatureManifestCreationStrategy>();
                //_module.Bind<IFeatureManifestService>().To<FeatureManifestService>();
                //_module.Bind<IFeatureManifest>()
                //    .ToMethod(x => _module.Kernel.Get<IFeatureManifestService>().GetManifest());
            }
        }
    }
}

// ReSharper restore CheckNamespace