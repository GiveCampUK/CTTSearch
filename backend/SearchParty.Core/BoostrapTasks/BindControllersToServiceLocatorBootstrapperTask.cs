namespace SearchParty.Core.BoostrapTasks
{
    using System;
    using NBootstrap;
    using NFeature;
    using NServiceLocator;

    public class BindControllersToServiceLocatorBootstrapperTask : IBootstrapperTask
    {
        private readonly IFeatureManifest<Feature> _featureManifest;
        private readonly IServiceLocator _serviceLocator;

        public BindControllersToServiceLocatorBootstrapperTask(IServiceLocator serviceLocator,
                                                               IFeatureManifest<Feature> featureManifest)
        {
            _serviceLocator = serviceLocator;
            _featureManifest = featureManifest;
        }

        public void Execute()
        {
            var controllerAssemblyNameLeftPart =
                Feature.ServiceLocatorAwareControllerFactory.Setting(
                    FeatureSettingNames.ServiceLocatorAwareControllerFactory
                        .ControllerAssemblyNameLeftPart, _featureManifest);

            var controllerTypesInThisAssembly =
                ControllerFactoryHelper.GetAllControllerTypesInAssembly(controllerAssemblyNameLeftPart);

            foreach (var t in controllerTypesInThisAssembly)
            {
                _serviceLocator.BindToSelf(t);
            }

            Console.WriteLine(GetType() + " completed OK.");
        }
    }
}