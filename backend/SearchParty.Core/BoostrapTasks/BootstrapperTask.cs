namespace SearchParty.Core.BoostrapTasks
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
        ImportLucidViews,
    }
}