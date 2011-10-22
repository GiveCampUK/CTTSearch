namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Core;
    using Core.Commands;

    public class SearchController : BaseController
    {
        private SearchCommand _searchCommand;

        public SearchController() 
        {
            
        }

        public SearchController(SearchCommand searchCommand)
        {
            _searchCommand = searchCommand;
        }

        public JsonResult SearchEngine(string q)
        {
            if (_searchCommand == null)
            {
                _searchCommand=new SearchCommand(DataSession, null);
            }
            return Json(_searchCommand.Execute(q),
                        JsonRequestBehavior.AllowGet);
        }
    }
}