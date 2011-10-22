using System.Web.Mvc;
using SearchParty.Core.Commands;

namespace SearchParty.Api.Controllers
{
    public class ResourceController : BaseController
    {
        private readonly ResourceCommand _resourceCommand;

        public ResourceController() : this(new ResourceCommand())
        {
            
        }

        private ResourceController(ResourceCommand resourceCommand)
        {
            _resourceCommand = resourceCommand;
        }

        public JsonResult Index(int? id)
        {
            return Json(_resourceCommand.PerformAction(id, DataSession),
                            JsonRequestBehavior.AllowGet);
        }



    }
}
