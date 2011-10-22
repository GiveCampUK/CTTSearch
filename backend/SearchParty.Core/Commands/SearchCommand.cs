namespace SearchParty.Core.Commands
{
    using System;
    using Infrastructure;

    public class SearchCommand : ActionCommand<SearchResponse>
    {
        public override void Validate(object[] validationErrors)
        {
            //nothing for now
        }

        public override SearchResponse PerformAction()
        {
            return new SearchResponse
                       {};
        }
    }
}