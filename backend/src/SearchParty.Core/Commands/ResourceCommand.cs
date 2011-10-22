namespace SearchParty.Core.Commands
{
    using System.Linq;
    using Models;
    using NHibernate;
    using NHibernate.Criterion;

    public class ResourceCreateCommand
    {
        public object PerformAction(int? id, ISession dataSession)
        {
            return new {status = "failed"};
        }
    }

    public class ResourceCommand
    {
        public object PerformAction(int? id, ISession dataSession)
        {
            if (id.HasValue)
            {
                var resource = dataSession.CreateCriteria<Resource>()
                    .Add(Restrictions.IdEq(id)).UniqueResult<Resource>();
                if (resource == null)
                {
                    return new {};
                }
                return GenerateResource(resource);
            }
            else
            {
                var resource = dataSession.CreateCriteria<Resource>()
                    .List<Resource>().ToList();
                if (!resource.Any())
                {
                    return new {};
                }
                return resource.Select(GenerateResource).ToList();
            }
        }

        private static object GenerateResource(Resource resource)
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