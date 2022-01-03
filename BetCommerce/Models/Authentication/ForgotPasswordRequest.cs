using System.ComponentModel.DataAnnotations;

namespace BetCommerce.Models.Authentication
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}