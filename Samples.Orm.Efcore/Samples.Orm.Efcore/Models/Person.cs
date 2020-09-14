using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Samples.Orm.Efcore.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string DisplayName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public List<TelephoneNumber> TelephoneNumbers { get; set; }
        public List<Address> Addresses { get; set; }

    }
}
