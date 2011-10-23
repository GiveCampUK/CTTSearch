namespace SearchParty.Core.Commands
{
    using System.Linq;
    using Bjma.Utility.DataAccess;
    using Infrastructure;
    using Models;
    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Linq;

    public class SearchCommand
    {

        private readonly ISession _dataSession;
        private readonly IRepository<Resource> _resourceRepo;

        public SearchCommand(ISession dataSession, IRepository<Resource> resourceRepo)
        {
            _dataSession = dataSession;
            _resourceRepo = resourceRepo;
        }

        public object PerformAction(string query, string tags)
        {
            SearchCommandHelper.CreateDummyDataIfEmpty(_dataSession);

            var criteria = _dataSession.CreateCriteria<Resource>();
            if (!string.IsNullOrEmpty(query))
            {
                query.Split(' ').ForEach(word => criteria.Add(
                    Restrictions.Or(
                        Restrictions.InsensitiveLike("Title", word, MatchMode.Anywhere),
                        Restrictions.Or(
                            Restrictions.InsensitiveLike("ShortDescription", word, MatchMode.Anywhere),
                            Restrictions.InsensitiveLike("LongDescription", word, MatchMode.Anywhere))
                        )));
            }
            if (!string.IsNullOrEmpty(tags))
            {
                foreach (var tag in tags.Split(','))
                {
                    criteria.Add(Restrictions.InsensitiveLike("Tags", string.Format(",{0},", tag), MatchMode.Anywhere));
                }
            }

            var results = criteria.List<Resource>().ToList();
            if (results.Any())
            {
                return new
                           {
                               results = results
                                   .Select(
                                       resource => new[]
                                                       {
                                                           new
                                                               {
                                                                   id = resource.Id,
                                                                   title = resource.Title,
                                                                   uri = resource.Uri,
                                                                   tags = resource.Tags.UnwrapCommas(),
                                                                   shortDescription = resource.ShortDescription,
                                                                   longDescription = resource.LongDescription,
                                                                   resourceType = "uri"
                                                               }
                                                       })
                           };
            }

            return new { results = new { } };
        }
    }
}