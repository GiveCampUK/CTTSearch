    using System;
    using SearchParty.Core.Models;
    using SearchParty.Infrastructure;

namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Core;
    using Core.Commands;

    public class ResourceController : BaseController
    {
        private readonly ResourceCommand _resourceCommand;
        private readonly ResourceUpdateCommand _resourceUpdateCommand;

        public ResourceController(ResourceCommand resourceCommand, 
                                  ResourceUpdateCommand resourceUpdateCommand)
        {
            _resourceCommand = resourceCommand;
            _resourceUpdateCommand = resourceUpdateCommand;
        }

        public JsonResult Index(int? id)
        {
            try
            {
                return Json(_resourceCommand.PerformAction(id),
                                JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return new JsonErrorResult(e);
            }
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View(new Resource
            {
                Id = 0,
                LongDescription = "Long description",
                ShortDescription = "Short description",
                Uri = "http://givecamp.org.uk",
                ResourceType = "Uri",
                Tags = "charity,event",
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