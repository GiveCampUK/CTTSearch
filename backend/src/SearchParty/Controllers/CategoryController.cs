namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Core;
    using Core.Commands;
    using SearchParty.Core.Models;
    using System.Collections.Generic;

    public class CategoryController : BaseController
    {
        private readonly CategoryCommand _categoryCommand;
        private readonly CategoryUpdateCommand _categoryUpdateCommand;

        public CategoryController()
            : this(new CategoryCommand(), new CategoryUpdateCommand()) {}

        private CategoryController(CategoryCommand categoryCommand,
                                        CategoryUpdateCommand categoryUpdateCommand)
        {
            _categoryCommand = categoryCommand;
            _categoryUpdateCommand = categoryUpdateCommand;
        }

        public JsonResult Index(int? id)
        {
            return Json(_categoryCommand.PerformAction(id, DataSession), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Category category)
        {
            return Json(_categoryUpdateCommand.PerformAction(category, DataSession));
        }

        [HttpGet]
        public ActionResult Update()
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

    }
}