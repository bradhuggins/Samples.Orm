using System.Text.Json.Serialization;

namespace Samples.Orm.Efcore.Models
{
    public class TelephoneNumber
    {
        public int TelephoneNumberId { get; set; }
        public string TelephoneNumberLabel { get; set; }
        public string TelephoneNumberValue { get; set; }

    }
}
