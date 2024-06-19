using System.ComponentModel.DataAnnotations;

namespace Pinewood.DMS.API.DTO
{
    public class CreateCustomerRequest
    {
        [Required]
        public string FirstName { get; set; }=string.Empty;

        [Required]
        public string LastName { get; set; }=string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Mobile { get; set; } = string.Empty;

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public string Address1 { get; set; } = string.Empty;

        [Required]
        public string Address2 { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string State { get; set; } = string.Empty;

        [Required]
        public string PostCode { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;

        [Required]
        public int CustomerStatus { get; set; }
    }
}
