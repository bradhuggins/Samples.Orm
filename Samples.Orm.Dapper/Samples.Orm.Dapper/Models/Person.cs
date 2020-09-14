#region Using Statements
using System.Collections.Generic;
#endregion

namespace Samples.Orm.Dapper.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<TelephoneNumber> TelephoneNumbers { get; set; }
        public List<Address> Addresses { get; set; }

    }
}
