using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using SearchParty.Api.Data.Overrides;
using SearchParty.Api.Models;

namespace SearchParty.Api.Controllers
{
    using Core.Commands;

    public class SearchController : BaseController
    {
        private readonly SearchCommand _searchCommand;

        public SearchController(SearchCommand searchCommand)
        {
            _searchCommand = searchCommand;
        }

        public JsonResult SearchEngine(string q)
        {
            return Json(_searchCommand.Execute(new Tuple<string, ISession>(){First = q, Second = DataSession}));
        }
    }
}