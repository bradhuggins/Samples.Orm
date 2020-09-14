using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvalTest.SimpleBLL.Domain
{
    /// <summary>
    /// Product Repository Interface
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Adds the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        void Add(Product product);

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        void Update(Product product);

        /// <summary>
        /// Removes the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        void Remove(Product product);

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Product object</returns>
        Product GetById(int id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Collection of >Product objects</returns>
        ICollection<Product> GetAll();

        /// <summary>
        /// Gets the discontinued.
        /// </summary>
        /// <returns>Collection of >Product objects</returns>
        ICollection<Product> GetDiscontinued();

        /// <summary>
        /// Gets the by category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Collection of >Product objects</returns>
        ICollection<Product> GetByCategory(Category category);
    }
}
