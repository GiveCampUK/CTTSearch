namespace SearchParty.Core.Commands
{
    using System.Linq;
    using Bjma.Utility.DataAccess;
    using Infrastructure;
    using Models;
    using NHibernate;
    using NHibernate.Criterion;
    using NHibernate.Linq;

    public class SearchCommand : ActionCommand<object, string>
    {

        private readonly ISession _dataSession;
        private readonly IRepository<Resource> _resourceRepo;

        public SearchCommand(ISession dataSession, IRepository<Resource> resourceRepo)
        {
            _dataSession = dataSession;
            _resourceRepo = resourceRepo;
        }

        public override object PerformAction(string query)
        {
            SearchCommandHelper.CreateDummyDataIfEmpty(_dataSession);
            //_resourceRepo.GetByFreeText(query,);

            var terms = query.Split(' ');
            const string tagIndicator = "^";
            var words = terms.Where(t => !t.StartsWith(tagIndicator)).ToArray();
            var tags = terms.Where(t => t.StartsWith(tagIndicator)).Select(t => t.Replace(tagIndicator, "")).ToArray();
            var criteria = _dataSession.CreateCriteria<Resource>();
            words.ForEach(word => criteria.Add(
                Restrictions.Or(
                    Restrictions.InsensitiveLike("Title", word, MatchMode.Anywhere),
                    Restrictions.Or(
                        Restrictions.InsensitiveLike("ShortDescription", word, MatchMode.Anywhere),
                        Restrictions.InsensitiveLike("LongDescription", word, MatchMode.Anywhere))
                    )));
            if (tags.Any())
            {
                foreach (var tag in tags)
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
                                                                   tags = resource.Tags.Tagify(),
                                                                   shortDescription = resource.ShortDescription,
                                                                   longDescription = resource.LongDescription,
                                                                   resourceType = "uri"
                                                               }
                                                       })
                           };
            }

            return new {results = new {}};
        }
    }
}