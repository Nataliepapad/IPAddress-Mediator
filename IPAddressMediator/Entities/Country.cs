using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAddressMediator.Entities
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }

        [StringLength(2)]
        public string? TwoLetterCode { get; set; }

        [StringLength(3)]
        public string? ThreeLetterCode { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
