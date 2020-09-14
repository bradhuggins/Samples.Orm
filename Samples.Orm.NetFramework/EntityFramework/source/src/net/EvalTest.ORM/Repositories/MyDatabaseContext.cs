using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using EvalTest.SimpleBLL.Domain;

namespace EvalTest.ORM.Repositories
{
    /// <summary>
    /// ObjectContext helper for entity framework
    /// </summary>
    public class MyDatabaseContext : ObjectContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyDatabaseContext"/> class.
        /// </summary>
        public MyDatabaseContext()
            : base("name=MyDatabaseEntities", "MyDatabaseEntities")  
        {
            this._categories = CreateObjectSet<Category>();
            this._products = CreateObjectSet<Product>();
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public ObjectSet<Category> Categories
        {
            get
            {
                return this._categories;
            }
        }
        private ObjectSet<Category> _categories;


        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>The products.</value>
        public ObjectSet<Product> Products
        {
            get
            {
                return this._products;
            }
        }
        private ObjectSet<Product> _products;

    }
}
