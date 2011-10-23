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
            try
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
            catch (Exception e)
            {
                return new JsonErrorResult(e);
            }

        }

        [HttpPost]
        public ActionResult Update(Resource resource)
        {
            var urlReferrer = Request.UrlReferrer;
            string newUrl = Request.UrlReferrer.ToString();
            bool success = true;
            try
            {
                _resourceUpdateCommand.PerformAction(resource, DataSession);
            }
            catch
            {
                success = false;
            }
            if (newUrl.Contains("success"))
            {
                newUrl = newUrl.Replace("&success=true", "");
                newUrl = newUrl.Replace("&success=false", "");
            }
            newUrl += "&success=" + success.ToString().ToLower();
            return Redirect(newUrl);
        }
    }
}