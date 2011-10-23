namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Bjma.Utility.DataAccess;
    using Core;
    using Core.Commands;
    using Core.Models;
    using NHibernate;

    public class SearchController : BaseController
    {
        private readonly SearchCommand _searchCommand;

        public SearchController(SearchCommand searchCommand, ISession dbSession, IRepository<Resource> resourceRepo)
        {
            _searchCommand = new SearchCommand(dbSession, resourceRepo);
        }

        public JsonResult SearchEngine(string q)
        {
            return Json(_searchCommand.Execute(q),
                        JsonRequestBehavior.AllowGet);
        }
    }
}