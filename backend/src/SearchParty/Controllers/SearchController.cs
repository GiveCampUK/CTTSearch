namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Core;
    using Core.Commands;
    using NHibernate;
    using NHibernate.Linq;

    public class SearchController : BaseController
    {
        private readonly SearchCommand _searchCommand;
        public SearchController() : this(new SearchCommand()) {}

        public SearchController(SearchCommand searchCommand)
        {
            _searchCommand = searchCommand;
        }

        public JsonResult SearchEngine(string q)
        {
            return Json(_searchCommand.Execute(new Tuple<string, ISession> {First = q, Second = DataSession}),
                        JsonRequestBehavior.AllowGet);
        }
    }
}