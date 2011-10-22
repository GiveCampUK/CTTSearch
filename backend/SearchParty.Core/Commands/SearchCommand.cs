namespace SearchParty.Core.Commands
{
    using System.Web.Mvc;
    using Infrastructure;

    public class SearchCommand : ActionCommand<JsonResult, string>
    {
        public override JsonResult PerformAction(string query)
        {
            return new JsonResult { };
        }
    }
}