using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IPAddressMediator.Models
{
    [Keyless]
    public class IPAddressModel
    {
        public string? CountryName { get; set; }

        [StringLength(2)]
        public string? TwoLetterCode { get; set; }

        [StringLength(3)]
        public string? ThreeLetterCode { get; set; }

    }
}
