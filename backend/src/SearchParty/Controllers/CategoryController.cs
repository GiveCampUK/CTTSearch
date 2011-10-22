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
        public ViewResult Update(int? id)
        {
            if (id.HasValue)
            {
                return View(_categoryUpdateCommand.PerformAction(new Category
                {
                    Id = id.Value,
                    Tags = "",
                    Title = "",
                    Blurb = "",
                    SubCategories = new List<Category> { },
                    SearchResultLinks = new List<SearchResultLink> { }
                }, DataSession));
            }
            else
            {
                return View(_categoryUpdateCommand.PerformAction(new Category
                {
                    Id = id.Value,
                    Tags = "",
                    Title = "",
                    Blurb = "",
                    SubCategories = new List<Category> { },
                    SearchResultLinks = new List<SearchResultLink> { }
                }, DataSession));
            }
        }

    }
}