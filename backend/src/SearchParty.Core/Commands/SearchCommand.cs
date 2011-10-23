using System.Collections;
using System.Collections.Generic;

namespace SearchParty.Core.Commands
{
    using System.Linq;
    using Models;
    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Linq;

    public class SearchCommand
    {
        private readonly ISession _dataSession;

        public SearchCommand(ISession dataSession)
        {
            _dataSession = dataSession;
        }

        public object PerformAction(string query, string tags, string queryString)
        {
            SearchCommandHelper.CreateDummyDataIfEmpty(_dataSession);

            var criteria = _dataSession.CreateCriteria<Resource>();
            if (!string.IsNullOrEmpty(query))
            {
                AddWordRestrictions(query, criteria);
            }
            if (!string.IsNullOrEmpty(tags))
            {
                foreach (var tag in tags.Split(','))
                {
                    criteria.Add(Restrictions.InsensitiveLike("Tags", string.Format(",{0},", tag), MatchMode.Anywhere));
                }
            }

            var results = criteria.List<Resource>().ToList();
            SaveSearchQuery(queryString, results);

            if (results.Any())
            {
                return CreateResources(results);
            }

            return new { results = new { } };
        }

        private void SaveSearchQuery(string queryString, ICollection results)
        {
            using (var tx = _dataSession.BeginTransaction())
            {
                var searchQuery = new SearchQuery
                                  {
                                      QueryString = queryString.Replace("?", ""),
                                      ResultsCount = results.Count
                                  };
                _dataSession.SaveOrUpdate(searchQuery); tx.Commit();
            }
        }

        private static object CreateResources(IEnumerable<Resource> results)
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

        private static void AddWordRestrictions(string query, ICriteria criteria)
        {
            query.Split(' ').ForEach(word => criteria.Add(
                Restrictions.Or(
                    Restrictions.InsensitiveLike("Title", word, MatchMode.Anywhere),
                    Restrictions.Or(
                        Restrictions.InsensitiveLike("ShortDescription", word, MatchMode.Anywhere),
                        Restrictions.InsensitiveLike("LongDescription", word, MatchMode.Anywhere))
                    )));
        }
    }
}