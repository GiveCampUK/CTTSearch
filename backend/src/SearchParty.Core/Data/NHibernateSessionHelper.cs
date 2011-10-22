namespace SearchParty.Core.Data
{
    using System;
    using System.Diagnostics;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Conventions.Helpers;
    using Models;
    using NHibernate;
    using NHibernate.Cfg;

    //public class SessionProvider : ISessionProvider
    //{
    //    public static ISessionProvider Instance { get; private set; }
    //    public ISessionFactory SessionFactory { get; private set; }
    //    private readonly ILog _logger = LogManager.GetLogger("SessionProvider");

    //    static SessionProvider()
    //    {
    //        Instance = new SessionProvider();
    //    }
    //    private SessionProvider()
    //    {
    //        try
    //        {
    //            SessionFactory = CreateSessionFactory();
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.Fatal("Could not create NHibernate session factory", ex);
    //            Debug.Write(ex);
    //            throw; // we should always throw otherwise the error that gets thrown will be confusing e.g: NullReferenceException
    //        }
    //    }

    //    public ISession OpenSession()
    //    {
    //        return SessionFactory.OpenSession();
    //    }

    //    public ISession OpenSession(IDbConnection connection)
    //    {
    //        return SessionFactory.OpenSession(connection);
    //    }

    //    private class FluentMappingAssembly
    //    {
    //    }

    //    private static ISessionFactory CreateSessionFactory()
    //    {
            

    //        var sessionFactory = Fluently.Configure()
    //          .Database(MsSqlConfiguration
    //                            .MsSql2005.ShowSql()
    //                            .ConnectionString(c => c.FromConnectionStringWithKey("BB01"))
    //                            .Cache(cache => cache.UseQueryCache().ProviderClass<SysCacheProvider>()))
    //          .Mappings(m =>
    //                    m.FluentMappings.AddFromAssemblyOf<FluentMappingAssembly>()
    //                        .Conventions.Add(Table.Is(x => "BB01_" + x.EntityType.Name))
    //                        .Conventions.Add(DefaultLazy.Always())
    //                        .Conventions.Add(DefaultAccess.Property())
    //                        .Conventions.Add(DefaultCascade.All())
    //                        .Conventions.Add(PrimaryKey.Name.Is(x => x.EntityType.Name + "ID")))
    //          .BuildSessionFactory();

    //        return sessionFactory;
    //    }

    //    public static bool ProfilerEnabled
    //    {
    //        get
    //        {
    //            bool enableProfiler;
    //            bool.TryParse(ConfigurationManager.AppSettings["EnableNhProfiler"], out enableProfiler);
    //            return enableProfiler;
    //        }
    //    }

    //}

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
                return Fluently
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
                               && !t.IsSubclassOf(typeof(Exception))
                               && !t.IsSubclassOf(typeof(Attribute)))))
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