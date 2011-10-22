namespace SearchParty.Core.Commands
{
    using System.Web.Mvc;
    using Infrastructure;

    public class ResourceCommand : ActionCommand<JsonResult, object>    // TODO NullDto
    {
        public override JsonResult PerformAction(object o)      // TODO NullDto
        {
            return new JsonResult { };
        }
    }
}