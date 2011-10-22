using SearchParty.Core.Models;

namespace SearchParty.Core.Commands
{
    public class ResourceCommandBase
    {
        protected static object GenerateResource(Resource resource)
        {
            return new
                       {
                           id = resource.Id,
                           uri = resource.Uri,
                           title = resource.Title,
                           tags = resource.Tags.Tagify(),
                           shortDescription = resource.ShortDescription,
                           longDescription = resource.LongDescription,
                           resourceType = resource.ResourceType
                       };
        }
    }
}