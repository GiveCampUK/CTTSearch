namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Core;
    using Core.Commands;

    public class CategoryController : BaseController
    {
        private readonly CategoryCommand _categoryCommand;

        public CategoryController()
            : this(new CategoryCommand()) {}

        private CategoryController(CategoryCommand categoryCommand)
        {
            _categoryCommand = categoryCommand;
        }

        public JsonResult Index(int? id)
        {
            return Json(_categoryCommand.PerformAction(id, DataSession), JsonRequestBehavior.AllowGet);
        }
    }
}