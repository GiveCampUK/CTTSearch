namespace SearchParty.Core.BootstrapTasks
{
    using System;
    using NHelpfulException;

    public class ControllerInstantiationException : HelpfulException
    {
        private const string DefaultMessageFormat = "Unable to load controller with the name \"{0}\".";

        public ControllerInstantiationException(string controllerName)
            : base(string.Format(DefaultMessageFormat, controllerName)) {}

        public ControllerInstantiationException(string controllerName, Exception innerException)
            : base(string.Format(DefaultMessageFormat, controllerName), innerException:innerException) {}
    }
}