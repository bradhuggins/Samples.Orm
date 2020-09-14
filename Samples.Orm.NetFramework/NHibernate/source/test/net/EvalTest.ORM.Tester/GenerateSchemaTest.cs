using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalTest.SimpleBLL.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace EvalTest.ORM.Tester
{
    /// <summary>
    /// Test Class to test generating the database schema
    /// </summary>
    [TestClass]
    public class GenerateSchemaTest
    {
        /// <summary>
        /// Determines whether this instance [can generate schema].
        /// </summary>
        [TestMethod]
        public void GenerateSchema()
        { 
            var cfg = new Configuration(); 
            cfg.Configure(); 
            cfg.AddAssembly(typeof(Product).Assembly); 
            new SchemaExport(cfg).Execute(false, true, false); 
        }


    }

}
