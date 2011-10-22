using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;

namespace SearchParty.Api.Controllers
{
    using Core.Commands;

    public class SearchController : BaseController
    {
        public SearchController() : this(new SearchCommand())
        {
            
        }
        private readonly SearchCommand _searchCommand;

        public SearchController(SearchCommand searchCommand)
        {
            _searchCommand = searchCommand;
        }

        public JsonResult SearchEngine(string q)
        {
            return Json(_searchCommand.Execute(new Tuple<string, ISession> {First = q, Second = DataSession}), JsonRequestBehavior.AllowGet);
        }
    }
}