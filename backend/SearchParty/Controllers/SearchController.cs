namespace SearchParty.Controllers
{
    using System;
    using System.Web.Mvc;

    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public JsonResult Index(string q)
        {
            return Json(new
                            {
                                results = new
                                              {
                                                  result1 = new
                                                                {
                                                                    id = Guid.NewGuid().ToString(),
                                                                    title = "GiveCampUK",
                                                                    uri = "http://givecamp.org.uk",
                                                                    tags = "charity",
                                                                    shortDescription = "Generous Geeks",
                                                                    longDescription =
                            "Generous geeks give their weekend to code",
                                                                    resultType = "uri"
                                                                }
                                              }
                            },
                        JsonRequestBehavior.AllowGet);
        }
    }
}