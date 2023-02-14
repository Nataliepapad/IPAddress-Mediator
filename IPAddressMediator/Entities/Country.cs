using System.ComponentModel.DataAnnotations;

namespace IPAddressMediator.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [StringLength(2)]
        public string? TwoLetterCode { get; set; }

        [StringLength(3)]
        public string? ThreeLetterCode { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
