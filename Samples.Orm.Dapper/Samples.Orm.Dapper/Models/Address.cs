namespace Samples.Orm.Dapper.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLabel { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public int PersonId { get; set; }

    }
}
