#region Using Statements
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samples.Orm.Efcore.Controllers;
using Samples.Orm.Efcore.Models;
using Samples.Orm.Efcore.Tests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Samples.Orm.Efcore.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTests : ControllerTestsBase
    {
        private ILogger<PersonController> _mockLogger = new Logger<PersonController>(new NullLoggerFactory());

        [TestMethod]
        public void GetAll()
        {
           // Arrange
            PersonController target = new PersonController(_mockLogger, _context);

            // Act
            var actual = target.GetAll() as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(
                ((List<Person>)actual.Value).ToList().Count == 1);

        }

    }
}
