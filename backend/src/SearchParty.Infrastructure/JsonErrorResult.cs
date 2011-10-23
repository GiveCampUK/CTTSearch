using System;
using System.Web.Mvc;

namespace SearchParty.Infrastructure
{
    public class JsonErrorResult : JsonResult
    {
        public JsonErrorResult(Exception e)
        {
            Data = new { error = e.Message };
        }

        public JsonErrorResult(string message)
        {
            Data = new {error = message};
        }
    }
}
