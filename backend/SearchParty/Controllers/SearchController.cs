using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NHibernate.Criterion;
using SearchParty.Api.Models;

namespace SearchParty.Api.Controllers
{
    using Core.Commands;

    public class SearchController : BaseController
    {
        private readonly SearchCommand _searchCommand;

        public SearchController(SearchCommand searchCommand)
        {
            _searchCommand = searchCommand;
        }

        //
        // GET: /Search/

        //modify to expose as was /
        public JsonResult SearchEngine(string q)
        {
            //return _searchCommand.Execute(q);

            var results = DataSession.CreateCriteria<Resource>()
                .List<Resource>();

            // Quick hacky write something into the database
            if (!results.Any())
            {
                using (var tx = DataSession.BeginTransaction())
                {
                    var tag = new Tag { Name = "Windows7" };
                    DataSession.Save(tag);
                    var resource = new Resource
                                       {
                                           Tags = new List<Tag> { tag },
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
                results = DataSession.CreateCriteria<Resource>()
                    .Add(Restrictions.Eq("Title", "GiveCampUK"))
                    .List<Resource>();
            }
            if (results.Any())
            {
                return Json(new
                                {
                                    results = results.Select(resource => new []
                                                  {
                                                      new
                                                                    {
                                                                        id = resource.Id,
                                                                        title = resource.Title,
                                                                        uri = resource.Uri,
                                                                        tags =
                                string.Join(",", resource.Tags.Select(t => t.Name)),
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
    }
}