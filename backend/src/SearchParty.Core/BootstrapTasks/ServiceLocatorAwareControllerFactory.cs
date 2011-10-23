namespace SearchParty.Core.BootstrapTasks
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using NServiceLocator;

    /// <summary>
    ///   TODO: BA; complete genericisation.
    ///   URI determines the type of IItem used to type the controller
    ///   (and hence sub-objects).
    ///   TODO: BA; test using Phil Haacks web server simulator?
    /// </summary>
    public class ServiceLocatorAwareControllerFactory : DefaultControllerFactory
    {
        private readonly string _controllerAssemblyName;
        private readonly string _controllerNamespace;
        private readonly IServiceLocator _serviceLocator;

        public ServiceLocatorAwareControllerFactory(IServiceLocator serviceLocator,
                                                    string controllerAssemblyName,
                                                    string controllerNamespace)
        {
            _serviceLocator = serviceLocator;
            _controllerAssemblyName = controllerAssemblyName;
            _controllerNamespace = controllerNamespace;
        }

        /// <summary>
        ///   This override adds the step of checking the IOC container 
        ///   for the controller before passing it off to the default 
        ///   controller creation functionality.
        ///   Performance here is important.
        /// </summary>
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            //using (_profiler.Step("CreateController"))
            //{
            try
            {
                var controllerTypeToLocate =
                    Type.GetType(_controllerNamespace + "." + controllerName + "Controller" + ", " +
                                 _controllerAssemblyName);

                var instance = _serviceLocator.Locate(controllerTypeToLocate);

                return instance as IController;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw new ControllerInstantiationException(controllerName, e);
            }
            //}
        }

        public override void ReleaseController(IController controller)
        {
            try
            {
                _serviceLocator.Release(controller);
            }
            catch (Exception e)
            {
                System.Console.Write(e.Message);
                ReleaseControllersAllocatedByDefaultFactory(controller);
            }
        }

        private void ReleaseControllersAllocatedByDefaultFactory(IController controller)
        {
            try
            {
                base.ReleaseController(controller);
            }
            catch (Exception)
            {
                //e.Log();
            }
        }
    }
}