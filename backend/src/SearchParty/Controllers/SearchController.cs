namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Core;
    using Core.Commands;
    using Core.Data;

    public class SearchController : BaseController
    {
        private readonly SearchCommand _searchCommand;
        private readonly SearchQueryCommand _searchQueryCommand;

        public SearchController(SearchCommand searchCommand)
        {
            var session = NHibernateSessionHelper.OpenSession();
            _searchCommand = new SearchCommand(session);//searchCommand;
            _searchQueryCommand = new SearchQueryCommand(session);
        }

        public JsonResult SearchEngine(string q, string tags)
        {
            return Json(_searchCommand.PerformAction(q, tags, Request.Url.Query),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult Last(int count)
        {
            return Json(_searchQueryCommand.PerformAction(count),
                        JsonRequestBehavior.AllowGet);
        }
    }
}