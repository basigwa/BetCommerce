using System.ComponentModel.DataAnnotations;

namespace BetCommerce.Models.Authentication
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}