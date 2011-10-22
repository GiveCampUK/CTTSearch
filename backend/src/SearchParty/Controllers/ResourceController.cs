namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Core;
    using Core.Commands;

    public class ResourceController : BaseController
    {
        private readonly ResourceCommand _resourceCommand;

        public ResourceController() : this(new ResourceCommand()) {}

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