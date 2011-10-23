using System;
using SearchParty.Infrastructure;

namespace SearchParty.Api.Controllers
{
    using System.Web.Mvc;
    using Core;
    using Core.Commands;
    using NHibernate;

    public class SearchController : BaseController
    {
        private readonly SearchCommand _searchCommand;
        private readonly SearchQueryCommand _searchQueryCommand;

        public SearchController(SearchCommand searchCommand,
                                SearchQueryCommand searchQueryCommand,
                                ISession session)
        {
            _searchCommand = searchCommand;
            _searchQueryCommand = new SearchQueryCommand(session);
        }

        public JsonResult SearchEngine(string q, string tags)
        {
            try
            {
                return Json(_searchCommand.PerformAction(q, tags, Request.Url.Query),
                            JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return new JsonErrorResult(e);
            }
        }

        public JsonResult Last(int count)
        {
            try
            {
                return Json(_searchQueryCommand.PerformAction(count),
                            JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return new JsonErrorResult(e);
            }
        }
    }
}