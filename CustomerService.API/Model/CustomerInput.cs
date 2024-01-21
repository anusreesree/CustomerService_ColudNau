using System.ComponentModel.DataAnnotations;

namespace CustomerService.API.Model
{
    public class CustomerInput
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string CustomerId { get; set; }

    }
}
