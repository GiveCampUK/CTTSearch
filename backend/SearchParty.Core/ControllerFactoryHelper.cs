namespace SearchParty.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ControllerFactoryHelper
    {
        public static IEnumerable<Type> GetAllControllerTypesInAssembly(string assemblyNameLeftPart)
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                // ReSharper disable PossibleNullReferenceException
                .Where(assembly => assembly.FullName.Split(',')[0] == assemblyNameLeftPart)
                // ReSharper restore PossibleNullReferenceException
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.Name.EndsWith("Controller")); //remove magic string
        }
    }
}