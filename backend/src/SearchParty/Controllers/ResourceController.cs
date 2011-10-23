using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Update(int id = 0)
        {
            try
            {
                return View(new Resource
                {
                    Id = id,
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
                newUrl = newUrl.Replace("?success=true", "");
                newUrl = newUrl.Replace("?success=false", "");
            }
            var separator = (newUrl.Contains("?") ? "&" : "?");
            newUrl += string.Format("{0}success={1}", separator, success.ToString().ToLower());
            return Redirect(newUrl);
        }

        public ActionResult ListTags()
        {
            // TODO: Refactor into command
            var tagList = new List<string>();
            var resourceTags = DataSession.CreateCriteria<Resource>()
                .List<Resource>()
                .ToList().Select(r => r.Tags);
            foreach (var tag in resourceTags)
            {
                tagList.AddRange(tag.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }
            var categoryTags = DataSession.CreateCriteria<Category>()
                .List<Category>()
                .ToList().Select(c => c.Tags);
            foreach (var tag in categoryTags)
            {
                tagList.AddRange(tag.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }

            return Json(new { tags = tagList.Distinct().OrderBy(s => s).Select(s => s.Trim()) }, JsonRequestBehavior.AllowGet);
        }
    }
}