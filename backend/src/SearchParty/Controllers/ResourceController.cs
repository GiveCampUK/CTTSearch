using System.Web.Mvc;

namespace SearchParty.Api.Controllers
{
    public class ResourceController : BaseController
    {
        public JsonResult Index()
        {
            return Json(new { result = "undefined" },
                            JsonRequestBehavior.AllowGet);
        }

    }
}
