using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using SearchParty.Core.Models;

namespace SearchParty.Core.Commands
{
    public class ResourceCommand : ResourceCommandBase
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
                    return new { };
                }
                return resource.Select(GenerateResource).ToList();
            }
        }
    }
}