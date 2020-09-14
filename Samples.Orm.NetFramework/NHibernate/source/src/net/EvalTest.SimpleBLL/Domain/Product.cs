using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvalTest.SimpleBLL.Domain
{
    /// <summary>
    /// Product Class
    /// </summary>
    public class Product 
    {
        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        /// <value>The product ID.</value>
        public virtual int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.</value>
        public virtual string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public virtual decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Product"/> is discontinued.
        /// </summary>
        /// <value><c>true</c> if discontinued; otherwise, <c>false</c>.</value>
        public virtual bool Discontinued { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        /// <value>The category ID.</value>
        public virtual int CategoryID { get; set; }

    }


}
