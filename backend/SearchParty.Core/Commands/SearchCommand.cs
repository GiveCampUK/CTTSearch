using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using SearchParty.Api.Models;
using SearchParty.Infrastructure;

namespace SearchParty.Core.Commands
{

    public class SearchCommand : ActionCommand<object, Tuple<string, ISession>>
    {
        public override object PerformAction(Tuple<string, ISession> args)
        {
            var query = args.First;
            var dataSession = args.Second;
            CreateDummyDataIfEmpty(dataSession);
            var terms = query.Split(' ');
            const string tagIndicator = "^";
            var words = terms.Where(t => !t.StartsWith(tagIndicator)).ToArray();
            var tags = terms.Where(t => t.StartsWith(tagIndicator)).Select(t => t.Replace(tagIndicator, "")).ToArray();
            var criteria = dataSession.CreateCriteria<Resource>();
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
                                                            tags = string.Join(",", resource.Tags.Replace(",", " ").Trim().Replace(" ", ",")),
                                                            shortDescription = resource.ShortDescription,
                                                            longDescription = resource.LongDescription,
                                                            resultType = "uri"
                                                        }
                                                  })
                };
            }

            return new { results = new { } };
        }

        private static void CreateDummyDataIfEmpty(ISession dataSession)
        {
            if (dataSession.CreateCriteria<Resource>().List<Resource>().Any()) return;
            using (var tx = dataSession.BeginTransaction())
            {
                //var tag1 = new Tag { Name = "Windows7" };
                //DataSession.Save(tag1);
                var resource = new Resource
                {
                    Tags = ",Windows7,Upgrade,",
                    Title = "Should I Upgrade To Windows 7?",
                    Uri =
                        "http://www.ctt.org/resource_centre/getting_started/learning/windows7upgrade",
                    ShortDescription =
                        "Four questions to ask before acquiring and deploying Windows 7 at your organisation.",
                    LongDescription =
                        "Four questions to ask before acquiring and deploying Windows 7 at your organisation. In this first article in a two-part guide to Windows 7, we’ll help you decide whether Windows 7 is right for your organisation.",
                    ResultType = "link"
                };
                dataSession.Save(resource);
                tx.Commit();
            }
        }
    }
}