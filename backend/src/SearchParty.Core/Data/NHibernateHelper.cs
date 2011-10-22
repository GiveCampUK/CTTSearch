namespace SearchParty.Core.Data
{
    using System;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Conventions.Helpers;
    using Models;
    using NHibernate;
    using NHibernate.Cfg;

    public class NHibernateHelper
    {
        private static readonly ISessionFactory SessionFactory;

        private static Configuration _configuration;

        static NHibernateHelper()
        {
            SessionFactory = Fluently
                .Configure(Configuration)
                .Mappings(m => m.AutoMappings.Add(
                    AutoMap.AssemblyOf<IEntity>()
                        .UseOverridesFromAssemblyOf<IEntity>()
                        .Conventions.Add(DefaultCascade.None())
                        .OverrideAll(map => map.IgnoreProperty("IsIgnored"))
                        .Where(t =>
                               (
                                   t.Namespace == "SearchParty.Core.Models"
                               )
                               && !t.IsSubclassOf(typeof (Exception))
                               && !t.IsSubclassOf(typeof (Attribute)))))
                .BuildSessionFactory();
        }

        public static Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new Configuration();
                    _configuration.Configure();
                    _configuration.AddAssembly(typeof (IEntity).Assembly);
                }
                return _configuration;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}