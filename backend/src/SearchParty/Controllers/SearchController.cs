namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Core;
    using Core.Commands;
    using Core.Data;

    public class SearchController : BaseController
    {
        private readonly SearchCommand _searchCommand;

        public SearchController(SearchCommand searchCommand)
        {
            _searchCommand = new SearchCommand(NHibernateSessionHelper.OpenSession(), new ResourceRepository());//searchCommand;
        }

        public JsonResult SearchEngine(string q, string tags)
        {
            return Json(_searchCommand.PerformAction(q, tags),
                        JsonRequestBehavior.AllowGet);
        }
    }
}