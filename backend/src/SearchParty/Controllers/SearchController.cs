namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Core;
    using Core.Commands;

    public class SearchController : BaseController
    {
        private readonly SearchCommand _searchCommand;

        public SearchController(SearchCommand searchCommand)
        {
            _searchCommand = searchCommand;// = new SearchCommand(null, null);//searchCommand;
        }

        public JsonResult SearchEngine(string q)
        {
            return Json(_searchCommand.Execute(q),
                        JsonRequestBehavior.AllowGet);
        }
    }
}