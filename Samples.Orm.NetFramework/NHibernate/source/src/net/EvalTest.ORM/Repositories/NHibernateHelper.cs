using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvalTest.SimpleBLL.Domain;
using NHibernate;
using NHibernate.Cfg;

namespace EvalTest.ORM.Repositories
{
    /// <summary>
    /// NHibernate Helper (SessionFactory) Class
    /// </summary>
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory; 
        private static ISessionFactory SessionFactory 
        { 
            get 
            { 
                if (_sessionFactory == null) 
                { 
                    var configuration = new Configuration(); 
                    configuration.Configure(); 
                    configuration.AddAssembly(typeof(Product).Assembly);
                    configuration.AddAssembly(typeof(Category).Assembly); 
                    _sessionFactory = configuration.BuildSessionFactory();
                } 
                return _sessionFactory; 
            } 
        }

        /// <summary>
        /// Opens the session.
        /// </summary>
        /// <returns>Session object</returns>
        public static ISession OpenSession() 
        { 
            return SessionFactory.OpenSession(); 
        }
    }

}
