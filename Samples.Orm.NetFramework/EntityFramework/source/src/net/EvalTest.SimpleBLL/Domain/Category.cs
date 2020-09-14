using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvalTest.SimpleBLL.Domain
{
    /// <summary>
    /// Category Class
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        /// <value>The category ID.</value>
        public virtual int CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>The name of the category.</value>
        public virtual string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public virtual List<Product> Products { get; set; }
        
    }
}

