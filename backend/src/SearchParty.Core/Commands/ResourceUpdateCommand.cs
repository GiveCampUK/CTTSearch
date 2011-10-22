using System;
using NHibernate;
using NHibernate.Criterion;
using SearchParty.Core.Models;

namespace SearchParty.Core.Commands
{
    public class ResourceUpdateCommand : ResourceCommandBase
    {
        public object PerformAction(Resource resource, ISession dataSession)
        {
            if (resource.Id == 0)
            {
                try
                {
                    FixTags(resource);
                    dataSession.SaveOrUpdate(resource);
                    return GenerateResource(resource);
                }
                catch (Exception exception)
                {
                    return new { status = "failed", exception = exception.ToString() };
                }
            }

            return UpdateExistingResource(resource, dataSession);
        }

        private static void FixTags(Resource resource)
        {
            if (!resource.Tags.StartsWith(","))
            {
                resource.Tags = "," + resource.Tags;
            }
            if (!resource.Tags.EndsWith(","))
            {
                resource.Tags = resource.Tags + ",";
            }
        }

        private static object UpdateExistingResource(Resource resource, ISession dataSession)
        {
            using (var tx = dataSession.BeginTransaction())
            {

                var existing = dataSession.CreateCriteria<Resource>()
                    .Add(Restrictions.IdEq(resource.Id)).UniqueResult<Resource>();
                if (existing == null)
                {
                    return new { status = "failed", message = "Resource does not exist" };
                }
                existing.LongDescription = resource.LongDescription;
                existing.ResourceType = resource.ResourceType;
                existing.ShortDescription = resource.ShortDescription;
                existing.Title = resource.Title;
                existing.Uri = resource.Uri;
                FixTags(existing);
                dataSession.SaveOrUpdate(existing);
                tx.Commit();
            }

            return GenerateResource(resource);
        }
    }
}