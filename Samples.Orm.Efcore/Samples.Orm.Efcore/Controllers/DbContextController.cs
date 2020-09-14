#region Using Statements
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Samples.Orm.Efcore.Models;
#endregion

namespace Samples.Orm.Efcore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DbContextController : ControllerBase
    {      
        private readonly ILogger<DbContextController> _logger;
        private readonly AppDbContext _context;

        public DbContextController(ILogger<DbContextController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Drop and Recreate the database using the models
        /// </summary>
        [HttpGet]
        [Route("dropandcreatedatabase")]
        public void DropAndCreateDatabase()
        {
            _context.DropAndCreateDatabase();
            return;
        }
                
    }
}
