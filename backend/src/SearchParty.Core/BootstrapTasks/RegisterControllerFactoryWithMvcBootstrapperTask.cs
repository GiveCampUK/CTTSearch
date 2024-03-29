﻿namespace SearchParty.Core.BootstrapTasks
{
    using System;
    using System.Web.Mvc;
    using NBootstrap;
    using NFeature;
    using NHibernate;
    using NServiceLocator;

    public class RegisterControllerFactoryWithMvcBootstrapperTask : IBootstrapperTask
    {
        private readonly ControllerBuilder _currentControllerBuilder;
        private readonly IFeatureManifest<Feature> _featureManifest;
        private readonly ISession _session;
        //private readonly MiniProfiler _miniProfiler;
        private readonly IServiceLocator _serviceLocator;


        public RegisterControllerFactoryWithMvcBootstrapperTask(IServiceLocator serviceLocator,
                                                                ControllerBuilder currentControllerBuilder,
                                                                IFeatureManifest<Feature> featureManifest)
            //MiniProfiler miniProfiler)
        {
            _serviceLocator = serviceLocator;
            _currentControllerBuilder = currentControllerBuilder;
            _featureManifest = featureManifest;
            //_miniProfiler = miniProfiler;
        }

        public void Execute()
        {
            var controllerAssemblyNameLeftPart = Feature.ServiceLocatorAwareControllerFactory
                .Setting(FeatureSettingNames.ServiceLocatorAwareControllerFactory
                             .ControllerAssemblyNameLeftPart, _featureManifest);

            var controllerNamespace = Feature.ServiceLocatorAwareControllerFactory
                .Setting(FeatureSettingNames.ServiceLocatorAwareControllerFactory
                             .ControllerNamespace, _featureManifest);

            _currentControllerBuilder
                .SetControllerFactory(new ServiceLocatorAwareControllerFactory(_serviceLocator,
                                                                               controllerAssemblyNameLeftPart,
                                                                               controllerNamespace));
            //_miniProfiler));
            _currentControllerBuilder.DefaultNamespaces.Add("SearchParty.Api.Controllers");


            Console.WriteLine(GetType() + " completed OK.");
        }
    }
}