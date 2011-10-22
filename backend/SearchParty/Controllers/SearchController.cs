using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using NHibernate.Transform;
using SearchParty.Api.Data.Overrides;
using SearchParty.Api.Models;

namespace SearchParty.Api.Controllers
{
    public class SearchController : BaseController
    {
        //
        // GET: /Search/


        public JsonResult Index(string q)
        {
            CreateDummyDataIfEmpty();

            var terms = q.Split(' ');
            const string tagIndicator = "^";
            var words = terms.Where(t => !t.StartsWith(tagIndicator)).ToArray();
            var tags = terms.Where(t => t.StartsWith(tagIndicator)).Select(t => t.Replace(tagIndicator, "")).ToArray();

            var criteria = DataSession.CreateCriteria<Resource>();
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
            Debug.WriteLine(criteria.ToSql(DataSession));

            var results = criteria.List<Resource>().ToList();
            if (results.Any())
            {
                return Json(new
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
                                },
                            JsonRequestBehavior.AllowGet);
            }

            return Json(new { results = new { } }, JsonRequestBehavior.AllowGet);
        }

        private void CreateDummyDataIfEmpty()
        {
            if (DataSession.CreateCriteria<Resource>().List<Resource>().Any()) return;

            // Quick hacky write something into the database
            using (var tx = DataSession.BeginTransaction())
            {
                //var tag1 = new Tag { Name = "Windows7" };
                //var tag2 = new Tag { Name = "Upgrade" };
                //DataSession.Save(tag1);
                //DataSession.Save(tag2);
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
                DataSession.Save(resource);
                tx.Commit();
            }
        }
    }
}