namespace SearchParty.Core.BootstrapTasks
{
    /// <summary>
    ///   Defines the ordering of the tasks to 
    ///   run at boot-up.
    /// </summary>
    public enum BootstrapperTask
    {
        BindControllersToServiceLocator,
        RegisterControllerFactoryWithMvc,
        RegisterGlobalFilters,
        RegisterRoutes,
    }
}