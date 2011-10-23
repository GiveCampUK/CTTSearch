namespace SearchParty.Core.Data
{
    using System;
    using System.Diagnostics;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Conventions.Helpers;
    using Models;
    using NHibernate;
    using NHibernate.Cfg;

    public class NHibernateSessionHelper
    {
        public static NHibernateSessionHelper Instance { get; private set; }

        public static ISessionFactory SessionFactory { get; private set; }

        private static Configuration _configuration;

        static NHibernateSessionHelper()
        {
            Instance = new NHibernateSessionHelper();
        }

        private NHibernateSessionHelper()
        {
            SessionFactory = CreateSessionFactory();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                return Configuration
                .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                    Debug.WriteLine(ex.Message);
                throw;
            }
            
        }

        public static Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {

                    _configuration = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(_=>_.FromConnectionStringWithKey("SearchParty")))
                        .Mappings(m => m.AutoMappings.Add(
                        AutoMap.AssemblyOf<IEntity>()
                            .UseOverridesFromAssemblyOf<IEntity>()
                            .Conventions.Add(DefaultCascade.None())
                            .OverrideAll(map => map.IgnoreProperty("IsIgnored"))
                            .Where(t =>
                                   (
                                       t.Namespace == "SearchParty.Core.Models"
                                   )
                                   && !t.IsSubclassOf(typeof(Exception))
                                   && !t.IsSubclassOf(typeof(Attribute))))).BuildConfiguration();
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