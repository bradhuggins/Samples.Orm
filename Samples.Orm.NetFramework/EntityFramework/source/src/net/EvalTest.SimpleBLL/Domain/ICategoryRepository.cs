using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvalTest.SimpleBLL.Domain
{
    /// <summary>
    /// Category Repository Interface
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Adds the specified category.
        /// </summary>
        /// <param name="category">The category.</param>
        void Add(Category category);

        /// <summary>
        /// Updates the specified category.
        /// </summary>
        /// <param name="category">The category.</param>
        void Update(Category category);

        /// <summary>
        /// Removes the specified category.
        /// </summary>
        /// <param name="category">The category.</param>
        void Remove(Category category);

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Category object</returns>
        Category GetById(int id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Collection of Category objects</returns>
        ICollection<Category> GetAll();
    }
}
