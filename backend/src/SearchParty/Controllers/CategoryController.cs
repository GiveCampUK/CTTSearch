using System;
using SearchParty.Infrastructure;

namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Core;
    using Core.Commands;
    using Core.Models;
    using System.Collections.Generic;

    public class CategoryController : BaseController
    {
        private readonly CategoryCommand _categoryCommand;
        private readonly CategoryUpdateCommand _categoryUpdateCommand;

        public CategoryController(CategoryCommand categoryCommand,
                                   CategoryUpdateCommand categoryUpdateCommand)
        {
            _categoryCommand = categoryCommand;
            _categoryUpdateCommand = categoryUpdateCommand;
        }

        public JsonResult Index(int? id)
        {
            try
            {

                return Json(_categoryCommand.PerformAction(id, DataSession), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return new JsonErrorResult(e);
            }
        }

        [HttpPost]
        public JsonResult Update(Category category)
        {
            try
            {
                return Json(_categoryUpdateCommand.PerformAction(category, DataSession));
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
                // Only here for the test form - DELETE
                return View(new Category
                {
                    Id = 0,
                    Title = "Long description",
                    Blurb = "Short description",
                    Tags = "test,data",
                    Parent = null,
                    SearchResultLinks = new List<SearchResultLink> { },
                    SubCategories = new List<Category> { }
                });
            }
            catch (Exception e)
            {
                return new JsonErrorResult(e);
            }

        }

    }
}