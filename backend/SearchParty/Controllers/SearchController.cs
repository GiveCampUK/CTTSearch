using System.Web.Mvc;

namespace SearchParty.Controllers
{
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
                                                                    title = "GiveCampUK",
                                                                    url = "http://givecamp.org.uk",
                                                                    tags = "charity"
                                                                }
                                              }
                            },
                        JsonRequestBehavior.AllowGet);
        }
    }
}