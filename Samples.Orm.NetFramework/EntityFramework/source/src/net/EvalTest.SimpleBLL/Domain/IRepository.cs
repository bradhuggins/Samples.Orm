using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace EvalTest.SimpleBLL.Domain
{
    /// <summary>
    /// Sample Generic Repository
    /// </summary>
    /// <typeparam name="T">a generic object</typeparam>
    public interface IRepository<T> 
    {
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>a generic object</returns>
        T GetById(int id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>a collection of generic objects</returns>
        T[] GetAll();

        /// <summary>
        /// Queries the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>a collection of generic objects that can be further queried</returns>
        IQueryable<T> Query(Expression<Func<T, bool>> filter);                                
    }
}
