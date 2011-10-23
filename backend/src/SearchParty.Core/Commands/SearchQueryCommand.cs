using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using SearchParty.Core.Models;

namespace SearchParty.Core.Commands
{
    public class SearchQueryCommand
    {
        private readonly ISession _dataSession;

        public SearchQueryCommand(ISession dataSession)
        {
            _dataSession = dataSession;
        }

        public object PerformAction(int count)
        {
            var results =_dataSession.CreateCriteria<SearchQuery>()
                .AddOrder(new Order("TimeStamp", false))
                .SetMaxResults(count).List<SearchQuery>();
            return results.Select(s => new
                                           {
                                               query = s.QueryString,
                                               timeStamp = s.TimeStamp,
                                               count = s.ResultsCount
                                           });
        }
    }
}