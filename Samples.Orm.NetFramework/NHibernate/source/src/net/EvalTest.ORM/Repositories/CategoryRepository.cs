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
    /// Category Repository Implementation
    /// </summary>
    public class CategoryRepository : ICategoryRepository 
    {
        #region ICategoryRepository Members
        /// <summary>
        /// Adds the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Add(Category obj)
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
        public void Update(Category obj)
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
        public void Remove(Category obj)
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
        /// <returns>Category object</returns>
        public Category GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Category>(id);
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Collection of Category objects</returns>
        public ICollection<Category> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var categories = session.CreateCriteria(typeof(Category))
                                    .List<Category>();
                return categories;
            }
        }  
        #endregion

    }

}
