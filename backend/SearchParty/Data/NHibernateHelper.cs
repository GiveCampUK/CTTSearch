﻿using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using SearchParty.Models;

namespace SearchParty.Data
{
    public class NHibernateHelper
    {
        private static readonly ISessionFactory SessionFactory;

        private static Configuration _configuration;
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

        static NHibernateHelper()
        {
            SessionFactory = Fluently
                .Configure(Configuration)
                .Mappings(m => m.AutoMappings.Add(
                    AutoMap.AssemblyOf<IEntity>()
                        .Conventions.Add(DefaultCascade.None())
                        .OverrideAll(map => map.IgnoreProperty("IsIgnored"))
                    .Where(t =>
                        (
                        t.Namespace == "SearchParty.Models"
                        )
                        && !t.IsSubclassOf(typeof(Exception))
                        && !t.IsSubclassOf(typeof(Attribute)))))
            .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}