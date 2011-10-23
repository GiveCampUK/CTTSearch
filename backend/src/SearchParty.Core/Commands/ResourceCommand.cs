using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using SearchParty.Core.Models;

namespace SearchParty.Core.Commands
{
    public class ResourceCommand : ResourceCommandBase
    {
        private readonly ISession _dbSession;

        public ResourceCommand(ISession dbSession)
        {
            _dbSession = dbSession;
        }

        public object PerformAction(int? id)
        {
            if (id.HasValue)
            {
                var resource = _dbSession.CreateCriteria<Resource>()
                    .Add(Restrictions.IdEq(id)).UniqueResult<Resource>();
                if (resource == null)
                {
                    return new {};
                }
                return GenerateResource(resource);
            }
            else
            {
                var resource = _dbSession.CreateCriteria<Resource>()
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