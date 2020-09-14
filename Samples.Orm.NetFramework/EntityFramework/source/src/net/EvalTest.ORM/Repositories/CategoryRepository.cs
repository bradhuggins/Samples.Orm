using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvalTest.SimpleBLL.Domain;

namespace EvalTest.ORM.Repositories
{
    /// <summary>
    /// Category Repository Implementation
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        #region Members     
        private  MyDatabaseContext _context;

        #endregion

        #region Ctor     
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        public CategoryRepository()     
        {
            this._context = new MyDatabaseContext();
        }     
        #endregion

        #region ICategoryRepository Members
        /// <summary>
        /// Adds the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Add(Category obj)
        {
            this._context.Categories.AddObject(obj);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Update(Category obj)
        {
            this._context.Categories.Attach(obj);
            this._context.Categories.ApplyCurrentValues(obj);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Remove(Category obj)
        {
            this._context.Categories.Attach(obj);
            this._context.Categories.DeleteObject(obj);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Category object</returns>
        public Category GetById(int id)
        {
            return this._context.Categories.
                    Where(c => c.CategoryID == id).
                    FirstOrDefault();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Collection of Category objects</returns>
        public ICollection<Category> GetAll()
        {
            return this._context.Categories.ToList();
        }
        
        #endregion

        #region IDisposable Members     
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()    
        {
            if (this._context != null)         
            {
                this._context.Dispose();         
            }         
            GC.SuppressFinalize(this);    
        }     
        #endregion

    }

}
