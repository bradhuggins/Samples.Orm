using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvalTest.SimpleBLL.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace EvalTest.ORM.Repositories
{
    /// <summary>
    /// Product Repository Implementation
    /// </summary>
    public class ProductRepository : IProductRepository 
    {
        #region IProductRepository Members
        /// <summary>
        /// Adds the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Add(Product obj)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(obj);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Updates the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Update(Product obj)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(obj);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Removes the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Remove(Product obj)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(obj);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Product object</returns>
        public Product GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Product>(id);
            }
        }

        /// <summary>
        /// Gets the discontinued.
        /// </summary>
        /// <returns>Collection of Product objects</returns>
        public ICollection<Product> GetDiscontinued()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var objs = session.CreateCriteria(typeof(Product))
                                    .Add(Restrictions.Eq("Discontinued", true))
                                    .List<Product>();
                return objs;
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Collection of Product objects</returns>
        public ICollection<Product> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var objs = session.CreateCriteria(typeof(Product))
                                    .List<Product>();
                return objs;
            }
        }

        /// <summary>
        /// Gets the by category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Collection of Product objects</returns>
        public ICollection<Product> GetByCategory(Category category)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var objs = session.CreateCriteria(typeof(Product))
                                    .Add(Restrictions.Eq("Category", category))
                                    .List<Product>();
                return objs;
            }
        } 
        #endregion

    }

}
