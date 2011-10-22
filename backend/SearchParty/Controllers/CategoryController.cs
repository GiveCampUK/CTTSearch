using System.Web.Mvc;
using SearchParty.Core.Commands;

namespace SearchParty.Api.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly CategoryCommand _categoryCommand;

        public CategoryController()
            : this(new CategoryCommand())
        {

        }

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