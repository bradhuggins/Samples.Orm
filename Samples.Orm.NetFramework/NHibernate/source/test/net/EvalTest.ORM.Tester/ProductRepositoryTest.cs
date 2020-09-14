using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalTest.SimpleBLL.Domain;
using EvalTest.ORM.Repositories;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate;

namespace EvalTest.ORM.Tester
{
    /// <summary>
    /// Test Class to test the ProductRepository
    /// </summary>
    [TestClass]
    public class ProductRepositoryTest
    {
        #region NHibernate Specific
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
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }    
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepositoryTest"/> class.
        /// </summary>
        public ProductRepositoryTest()
        {
            // TODO: Add constructor logic here
        } 
        #endregion

        #region Initializations
        /// <summary>
        /// Used to Initialize the class before running the first test in the class.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
        }

        /// <summary>
        /// Used to run code before running each test 
        /// </summary>
        [TestInitialize]
        public void MyTestInitialize()
        {

        }
        #endregion

        #region Test Methods
        /// <summary>
        /// Adds this instance.
        /// </summary>
        [TestMethod]
        public void Add()
        {
            var product = new Product
            {
                ProductName = "Butter",
                Category = new CategoryRepository().GetById(2),
                UnitPrice = 3.99M,
                Discontinued = false
            };

            IProductRepository repository = new ProductRepository();
            repository.Add(product);

            // use session to try to load the item
            using (ISession session = SessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(product.ProductID);

                // Test that the item was successfully inserted
                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(product, fromDb);
                Assert.AreEqual(product.ProductName, fromDb.ProductName);
                Assert.AreEqual(product.UnitPrice, fromDb.UnitPrice);
                Assert.AreEqual(product.Discontinued, fromDb.Discontinued);
            }

        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        [TestMethod]
        public void Update()
        {
            var product = this._products[0];
            product.ProductName = "Red Apple";
            IProductRepository repository = new ProductRepository();
            repository.Update(product);

            // use session to try to load the item            
            using (ISession session = SessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(product.ProductID);

                // Test that the item was successfully updated
                Assert.AreEqual(product.ProductName, fromDb.ProductName);
            }
        }

        /// <summary>
        /// Removes this instance.
        /// </summary>
        [TestMethod]
        public void Remove()
        {
            var product = new Product
            {
                ProductName = "Butter",
                Category = new CategoryRepository().GetById(2),
                UnitPrice = 3.99M,
                Discontinued = false
            };
            IProductRepository repository = new ProductRepository();
            repository.Remove(product);

            // use session to try to load the item
            using (ISession session = SessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(product.ProductID);

                // Test that the item was successfully removed
                Assert.IsNull(fromDb);
            }
        }

        /// <summary>
        /// Gets the by ID.
        /// </summary>
        [TestMethod]
        public void GetByID()
        {
            IProductRepository repository = new ProductRepository();
            var fromDb = repository.GetById(this._products[1].ProductID);
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(this._products[1], fromDb);
            //Assert.AreEqual(this._products[1].ProductName, fromDb.ProductName); 
        }

        /// <summary>
        /// Gets the discontinued.
        /// </summary>
        [TestMethod]
        public void GetDiscontinued()
        {
            IProductRepository repository = new ProductRepository();
            var fromDb = repository.GetDiscontinued();
            Assert.IsNotNull(fromDb);
            Assert.AreEqual(true, fromDb.Count >= 0);

            Assert.AreEqual(1, fromDb.Count);
            Assert.IsTrue(this.IsInCollection(this._products[5], fromDb));
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        [TestMethod]
        public void GetAll()
        {
            IProductRepository repository = new ProductRepository();
            var fromDb = repository.GetAll();
            Assert.IsNotNull(fromDb);
            Assert.AreEqual(true, fromDb.Count >= 0);
        }

        /// <summary>
        /// Gets the by category.
        /// </summary>
        [TestMethod]
        public void GetByCategory()
        {
            IProductRepository repository = new ProductRepository();
            var fromDb = repository.GetByCategory(new CategoryRepository().GetById(1));
            Assert.IsNotNull(fromDb);
            Assert.AreEqual(true, fromDb.Count >= 0);
        } 

        #endregion

        #region Internal Methods
        /// <summary>
        /// Determines whether [is in collection] [the specified product].
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="results">The results.</param>
        /// <returns>
        /// <c>true</c> if [is in collection] [the specified product]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsInCollection(Product product, ICollection<Product> results)
        {
            foreach (var item in results)
            {
                if (product.ProductID == item.ProductID)
                {
                    return true;
                }
            }
            return false;
        } 
        #endregion
        
        #region Sample Data
        private readonly Product[] _products = new[] 
        { 
            new Product { ProductID = 1, ProductName = "Bread", Category = new CategoryRepository().GetById(1), UnitPrice = 1.79M, Discontinued = false },
            new Product { ProductID = 2, ProductName = "Raisin Bran", Category = new CategoryRepository().GetById(1), UnitPrice = 2.15M, Discontinued = false }, 
            new Product { ProductID = 3, ProductName = "Apple", Category = new CategoryRepository().GetById(3), UnitPrice = 0.99M, Discontinued = true}, 
            new Product { ProductID = 4, ProductName = "Orange", Category = new CategoryRepository().GetById(3), UnitPrice = 0.99M, Discontinued = false }, 
            new Product { ProductID = 5, ProductName = "Green Beans", Category = new CategoryRepository().GetById(3), UnitPrice = 1.55M, Discontinued = false  }, 
            new Product { ProductID = 6, ProductName = "Carrots", Category = new CategoryRepository().GetById(3), UnitPrice = 0.99M, Discontinued = true  }, 
            new Product { ProductID = 7, ProductName = "Ground Sirlion", Category = new CategoryRepository().GetById(4), UnitPrice = 5.99M, Discontinued = false  }, 
            new Product { ProductID = 8, ProductName = "Milk", Category = new CategoryRepository().GetById(2), UnitPrice = 1.99M, Discontinued = false  }, 
            new Product { ProductID = 9, ProductName = "Cheese", Category = new CategoryRepository().GetById(2), UnitPrice = 1.99M, Discontinued = false  }, 
        };  
        #endregion
        

    }
}
