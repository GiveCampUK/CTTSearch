namespace SearchParty.Core.BootstrapTasks
{
    using System;
    using System.Web.Mvc;
    using NBootstrap;

    public class RegisterGlobalFiltersBootstrapperTask : IBootstrapperTask
    {
        private readonly GlobalFilterCollection _filters;

        public RegisterGlobalFiltersBootstrapperTask(GlobalFilterCollection filters)
        {
            _filters = filters;
        }

        public void Execute()
        {
            _filters.Add(new HandleErrorAttribute());

            Console.WriteLine(GetType() + " completed OK.");
        }
    }
}