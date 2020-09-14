using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvalTest.SimpleBLL.Domain;

namespace EvalTest.ORM.Repositories
{
    /// <summary>
    /// Product Repository Implementation
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        #region Members     
        private  MyDatabaseContext _context;

        #endregion

        #region Ctor     
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        public ProductRepository()     
        {
            _context = new MyDatabaseContext();
        }     
        #endregion

        #region IProductRepository Members

        /// <summary>
        /// Adds the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Add(Product obj)
        {
            _context.Products.AddObject(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Update(Product obj)
        {
            _context.Products.Attach(obj);
            _context.Products.ApplyCurrentValues(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified obj.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void Remove(Product obj)
        {
            _context.Products.Attach(obj);
            _context.Products.DeleteObject(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Product object</returns>
        public Product GetById(int id)
        {
            return _context.Products.
                    Where(p => p.ProductID == id).
                    FirstOrDefault();
        }

        /// <summary>
        /// Gets the discontinued.
        /// </summary>
        /// <returns>Collection of Product objects</returns>
        public ICollection<Product> GetDiscontinued()
        {
            return (ICollection<Product>)_context.Products.
                                    Where(p => p.Discontinued == true).
                                    ToList();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Collection of Product objects</returns>
        public ICollection<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        /// <summary>
        /// Gets the by category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Collection of Product objects</returns>
        public ICollection<Product> GetByCategory(Category category)
        {
            return _context.Products.
                    Where(p => p.Category.CategoryID == category.CategoryID).
                    ToList();
        }
        
        #endregion

        #region IDisposable Members     
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()    
        {        
            if (_context != null)         
            {             
                _context.Dispose();         
            }         
            GC.SuppressFinalize(this);    
        }     
        #endregion

    }

}
