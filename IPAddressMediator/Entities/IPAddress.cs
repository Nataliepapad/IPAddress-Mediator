using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAddressMediator.Entities
{
    public class IPAddress
    {

        public string IP { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CountryId { get; set; } 

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Country? Country { get; set; }
    }
}
