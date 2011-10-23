using System;
using System.Web.Mvc;

namespace SearchParty.Infrastructure
{
    public class JsonErrorResult : JsonResult
    {
        public JsonErrorResult(Exception e)
        {
            SetProperties(e.Message);
        }

        public JsonErrorResult(string message)
        {
            SetProperties(message);
        }

        private void SetProperties(string message)
        {
            Data = new {error = message};
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

    }
}
