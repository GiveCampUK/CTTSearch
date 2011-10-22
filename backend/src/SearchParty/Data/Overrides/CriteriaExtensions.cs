using NHibernate;
using NHibernate.Impl;
using NHibernate.Loader.Criteria;
using NHibernate.Persister.Entity;

namespace SearchParty.Api.Data.Overrides
{
    /// <summary>
    /// Usage: Console.WriteLine(criteria.GetExecutableCriteria(Session).ToSql());
    /// </summary>
    public static class CriteriaExtensions
    {
        public static string ToSql(this ICriteria c, ISession session)
        {
            var criteriaImpl = (CriteriaImpl)c;
            var sessionImpl = (SessionImpl)session;
            var factory = (SessionFactoryImpl)session.SessionFactory;
            var translator = new CriteriaQueryTranslator(factory, criteriaImpl, criteriaImpl.EntityOrClassName, CriteriaQueryTranslator.RootSqlAlias);
            var implementors = factory.GetImplementors(criteriaImpl.EntityOrClassName);

            var walker = new CriteriaJoinWalker((IOuterJoinLoadable)factory.GetEntityPersister(implementors[0]),
                                                translator,
                                                factory,
                                                criteriaImpl,
                                                criteriaImpl.EntityOrClassName,
                                                sessionImpl.EnabledFilters);



            return walker.SqlString.ToString();
        }
    }
}