#region Using Statements
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Samples.Orm.Efcore.Models;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Samples.Orm.Efcore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {      
        private readonly ILogger<PersonController> _logger;
        private readonly AppDbContext _context;

        public PersonController(ILogger<PersonController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Read all (select all persons but do not include child entities)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("", Name = "GetAll")]
        public IActionResult GetAll()
        {
            var results = new List<Person>();
            results = _context.People
                     .ToList();
            return Ok(results);
        }

        /// <summary>
        /// Read a specific person by id and includ child entities
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}", Name = "GetPersonById")]
        public IActionResult Get(int id)
        {
            var result = _context.People
                    .Include(a => a.Addresses)
                    .Include(t => t.TelephoneNumbers)
                    .FirstOrDefault(m => m.PersonId == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Create/Insert a new person along with all entities in bulk transaction 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] Person entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            var result = _context.People.Add(entity);
            _context.SaveChanges();
            return CreatedAtRoute("GetPersonById", new { id = result.Entity.PersonId }, (Person)result.Entity);
        }

        /// <summary>
        /// Update an existing person along with all entities in bulk transaction
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] Person entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            // add custom code here to attach to existing entity and update properties
            // attaching to an existing entity is required because web service calls are stateless and do not track entity changes.
            var result = _context.People.Update(entity);
            _context.SaveChanges();
            return Ok(result.Entity);
        }

        /// <summary>
        /// Delete a person and all child entities
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var existingRecord = _context.People
                    .Include(a => a.Addresses)
                    .Include(t => t.TelephoneNumbers)
                    .FirstOrDefault(m => m.PersonId == id);
            if (existingRecord == null)
            {
                return NotFound();
            }
            _context.People.Remove(existingRecord);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("deletewithsql/{id}")]
        public IActionResult DeleteWithSql(int id)
        {
            var existingRecord = _context.People
                    .Include(a => a.Addresses)
                    .Include(t => t.TelephoneNumbers)
                    .FirstOrDefault(m => m.PersonId == id);
            if (existingRecord == null)
            {
                return NotFound();
            }

            var personId = new SqlParameter("PersonId", System.Data.SqlDbType.Int);
            personId.Value = id;
            _context.Database.ExecuteSqlCommand("EXEC sp_DeletePerson @PersonId", personId);

            return Ok();
        }

    }
}
