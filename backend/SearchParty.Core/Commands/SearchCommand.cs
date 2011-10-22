namespace SearchParty.Core.Commands
{
    using System.Web.Mvc;
    using Infrastructure;

    public class SearchCommand : ActionCommand<JsonResult, string>
    {
        public override JsonResult PerformAction(string query)
        {
            return new JsonResult {};
        }
    }

    public class GetAllResourcesCommand : SimpleActionCommand<JsonResult>
    {
        public override JsonResult PerformAction()
        {
            return new JsonResult {};
        }
    }
}