namespace SearchParty.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models;
    using NHibernate.Criterion;

    public class SearchController : BaseController
    {
        //
        // GET: /Search/


        public JsonResult Index(string q)
        {
            var results = DataSession.CreateCriteria<Resource>()
                .List<Resource>();

            // Quick hacky write something into the database
            if (!results.Any())
            {
                var tag = new Tag {Name = "Windows7"};
                DataSession.Save(tag);
                var resource = new Resource
                                   {
                                       Tags = new List<Tag> {tag},
                                       Title = "Should I Upgrade To Windows 7?",
                                       Uri =
                                           "http://www.ctt.org/resource_centre/getting_started/learning/windows7upgrade",
                                   };
                DataSession.Save(resource);
                results = DataSession.CreateCriteria<Resource>()
                    .Add(Restrictions.Eq("Title", "GiveCampUK"))
                    .List<Resource>();
            }
            if (results.Any())
            {
                var resource = results.First();
                return Json(new
                                {
                                    results = new
                                                  {
                                                      result2 = new
                                                                    {
                                                                        id = Guid.NewGuid().ToString(),
                                                                        title = resource.Title,
                                                                        uri = resource.Uri,
                                                                        tags =
                                string.Join(",", resource.Tags.Select(t => t.Name)),
                                                                        shortDescription = "Generous Geeks",
                                                                        longDescription =
                                "Generous geeks give their weekend to code",
                                                                        resultType = "uri"
                                                                    }
                                                  }
                                },
                            JsonRequestBehavior.AllowGet);
            }

            return Json(new {results = new {}}, JsonRequestBehavior.AllowGet);
        }
    }
}