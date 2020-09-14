namespace Samples.Orm.Dapper.Models
{
    public class TelephoneNumber
    {
        public int TelephoneNumberId { get; set; }
        public string TelephoneNumberLabel { get; set; }
        public string TelephoneNumberValue { get; set; }

        public int PersonId { get; set; }
    }
}
