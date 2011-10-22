using System;
using System.Web.Mvc;
using SearchParty.Core.Commands;
using SearchParty.Core.Models;

namespace SearchParty.Api.Controllers
{
    public class ResourceController : BaseController
    {
        private readonly ResourceCommand _resourceCommand;
        private readonly ResourceUpdateCommand _resourceUpdateCommand;

        public ResourceController() : this(new ResourceCommand(), new ResourceUpdateCommand())
        {
            
        }

        private ResourceController(ResourceCommand resourceCommand, ResourceUpdateCommand resourceUpdateCommand)
        {
            _resourceCommand = resourceCommand;
            _resourceUpdateCommand = resourceUpdateCommand;
        }

        public JsonResult Index(int? id)
        {
            return Json(_resourceCommand.PerformAction(id, DataSession),
                            JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update()
        {
            return View(new Resource
                            {
                                Id=2,
                                LongDescription = "Longer description",
                                ShortDescription = "Short description",
                                Uri = "http://givecamp.org.uk",
                                ResourceType = "Uri",
                                Tags="charity,event",
                                Title = "GiveCamp UK"
                            });
        }

        [HttpPost]
        public ActionResult Update(Resource resource)
        {
            return Json(_resourceUpdateCommand.PerformAction(resource, DataSession));
        }
    }
}
