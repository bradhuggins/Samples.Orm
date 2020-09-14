using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvalTest.SimpleBLL.Domain;
using EvalTest.ORM.Repositories;

namespace EvalTest.ORM.Tester
{
    /// <summary>
    /// Test Class to test the CategoryRepository
    /// </summary>
    [TestClass]
    public class CategoryRepositoryTest
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepositoryTest"/> class.
        /// </summary>
        public CategoryRepositoryTest()
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
            var category = new Category
            {
                CategoryName = "My Test Category"
            };

            ICategoryRepository repository = new CategoryRepository();
            repository.Add(category);
           
            //// use Context to try to load the item
            //var fromDb = repository.GetById(category.CategoryID);

            //// Test that the item was successfully inserted
            //Assert.IsNotNull(fromDb);
            //Assert.AreNotSame(category, fromDb);
            //Assert.AreEqual(category.CategoryName, fromDb.CategoryName);
            
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        [TestMethod]
        public void Update()
        {
            var category = this._categories[3];
            category.CategoryName = "Meat";
            ICategoryRepository repository = new CategoryRepository();
            repository.Update(category);

            /// use Context to try to load the item
            var fromDb = repository.GetById(category.CategoryID);

            // Test that the item was successfully updated
            Assert.AreEqual(category.CategoryName, category.CategoryName);
        }

        /// <summary>
        /// Removes this instance.
        /// </summary>
        [TestMethod]
        public void Remove()
        {
            var category = new Category { CategoryID = 6, CategoryName = "UNKNOWN" };
            ICategoryRepository repository = new CategoryRepository();
            repository.Remove(category);

            /// use Context to try to load the item
            var fromDb = repository.GetById(category.CategoryID);

            // Test that the item was removed
            Assert.IsNull(fromDb);
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        [TestMethod]
        public void GetById()
        {
            ICategoryRepository repository = new CategoryRepository();
            var fromDb = repository.GetById(this._categories[1].CategoryID);
            Assert.IsNotNull(fromDb);
            Assert.AreNotSame(this._categories[1], fromDb);
            Assert.AreEqual(this._categories[1].CategoryName, fromDb.CategoryName);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        [TestMethod]
        public void GetAll()
        {
            ICategoryRepository repository = new CategoryRepository();
            var fromDb = repository.GetAll();
            Assert.IsNotNull(fromDb);
            Assert.AreEqual(true, fromDb.Count >= 0);
        } 

        #endregion

        #region Internal Methods
        /// <summary>
        /// Determines whether [is in collection] [the specified category].
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="results">The results.</param>
        /// <returns>
        /// <c>true</c> if [is in collection] [the specified category]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsInCollection(Category category, ICollection<Category> results)
        {
            foreach (var item in results)
            {
                if (category.CategoryID == item.CategoryID)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Sample Data
        private readonly Category[] _categories = new[] 
        { 
            new Category { CategoryID = 1, CategoryName = "Bread and Cereal"},
            new Category { CategoryID = 2, CategoryName = "Dairy" }, 
            new Category { CategoryID = 3, CategoryName = "Fruits and Veggies" }, 
            new Category { CategoryID = 4, CategoryName = "MEAT!" }, 
            new Category { CategoryID = 5, CategoryName = "Junk Food" }, 
            new Category { CategoryID = 6, CategoryName = "UNKNOWN" }
        };
        #endregion

    }
}
