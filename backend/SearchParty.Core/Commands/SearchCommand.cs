namespace SearchParty.Core.Commands
{
    using System;
    using Infrastructure;

    public class SearchCommand : ActionCommand<SearchResponse>
    {
        public override void Validate(object[] validationErrors)
        {
            throw new NotImplementedException();
        }

        public override SearchResponse PerformAction()
        {
            return new SearchResponse
                       {};
        }
    }
}