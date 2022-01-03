using System.ComponentModel.DataAnnotations;

namespace BetCommerce.Models.Authentication
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}