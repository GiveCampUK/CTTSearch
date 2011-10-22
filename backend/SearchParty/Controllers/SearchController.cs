using System;
using System.Diagnostics;
using System.Web.Mvc;
using NHibernate.Criterion;
using SearchParty.Models;

namespace SearchParty.Controllers
{
    public class SearchController : BaseController
    {
        //
        // GET: /Search/

        

        public JsonResult Index(string q)
        {
            var results = DataSession.CreateCriteria<Resource>()
                .Add(Restrictions.Eq("Title", "GiveCampUK"))
                .List<Resource>();

            Debug.Write(results);

            return Json(new
                            {
                                results = new
                                              {
                                                  result2 = new
                                                                {
                                                                    id = Guid.NewGuid().ToString(),
                                                                    title = "GiveCampUK",
                                                                    uri = "http://givecamp.org.uk",
                                                                    tags = "charity",
                                                                    shortDescription = "Generous Geeks",
                                                                    longDescription = "Generous geeks give their weekend to code",
                                                                    resultType = "uri"
                                                                }
                                              }
                            },
                        JsonRequestBehavior.AllowGet);
        }
    }
}