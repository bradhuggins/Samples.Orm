#region Using Statements
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Samples.Orm.Dapper.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
#endregion

namespace Samples.Orm.Dapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {      
        private readonly ILogger<PersonController> _logger;
        private readonly IConfiguration _configuration;
        private string ConnectionString
        {
            get
            {
                return _configuration.GetConnectionString("DefaultConnection");
            }
        }

        public PersonController(ILogger<PersonController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Read all (select all persons but do not include child entities)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("", Name = "GetAll")]
        public IActionResult GetAll()
        {
            List<Person> results = new List<Person>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                results = connection.Query<Person>("SELECT PersonId, FirstName, LastName FROM People (NOLOCK) ")
                    .ToList();
            }
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
            Person result = null;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                result = connection.QuerySingleOrDefault<Person>(
                    "SELECT PersonId, FirstName, LastName FROM People (NOLOCK) WHERE PersonId = @Id",
                    new
                    {
                        Id = id
                    });
            }
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                //populate addresses
                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    result.Addresses = connection.Query<Address>(
                        "SELECT AddressId, AddressLabel, StreetAddress1, StreetAddress2, City, State, PostalCode FROM Addresses (NOLOCK) WHERE PersonId = @PersonId",
                        new
                        {
                            PersonId = id
                        })
                        .ToList();
                }
                //populate telephone
                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    result.TelephoneNumbers = connection.Query<TelephoneNumber>(
                        "SELECT TelephoneNumberId, TelephoneNumberLabel, TelephoneNumberValue FROM TelephoneNumbers (NOLOCK) WHERE PersonId = @PersonId",
                        new
                        {
                            PersonId = id
                        })
                        .ToList();
                }
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
            Person toReturn = null;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                toReturn = connection.QuerySingleOrDefault<Person>("sp_CreatePerson",
                   new
                   {
                       FirstName = entity.FirstName,
                       LastName = entity.LastName
                   }, commandType: System.Data.CommandType.StoredProcedure); 

                //add addresses
                if (entity.Addresses != null)
                {
                    entity.Addresses = entity.Addresses.Select(c => { c.PersonId = toReturn.PersonId; return c; }).ToList();
                    toReturn.Addresses = new List<Address>();
                    foreach (var address in entity.Addresses)
                    {
                        toReturn.Addresses.Add(
                            connection.QuerySingleOrDefault<Address>("sp_CreateAddress", 
                            new {
                                PersonId = toReturn.PersonId,
                                AddressLabel = address.AddressLabel,
                                StreetAddress1 = address.StreetAddress1,
                                StreetAddress2 = address.StreetAddress2,
                                City = address.City,
                                State = address.State,
                                PostalCode = address.PostalCode
                            }, commandType: System.Data.CommandType.StoredProcedure)
                            );
                    }
                }

                //add telephone
                if (entity.TelephoneNumbers != null)
                {
                    entity.TelephoneNumbers =  entity.TelephoneNumbers.Select(c => { c.PersonId = toReturn.PersonId; return c; }).ToList();
                    toReturn.TelephoneNumbers = new List<TelephoneNumber>();
                    foreach (var phone in entity.TelephoneNumbers)
                    {
                        toReturn.TelephoneNumbers.Add(
                            connection.QuerySingleOrDefault<TelephoneNumber>("sp_CreateTelephoneNumber", 
                            new {
                                PersonId = toReturn.PersonId,
                                TelephoneNumberLabel = phone.TelephoneNumberLabel,
                                TelephoneNumberValue = phone.TelephoneNumberValue
                            }, commandType: System.Data.CommandType.StoredProcedure)
                            );
                    }
                }
            }

            return CreatedAtRoute("GetPersonById", new { id = toReturn.PersonId }, (Person)toReturn);
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
            

            return Ok();
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
            int result = -1;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                result = connection.ExecuteScalar<int>("sp_DeletePerson ",
                    new
                    {
                        PersonId = id
                    }, commandType: System.Data.CommandType.StoredProcedure);
            }
            return Ok();
        }

    }
}
