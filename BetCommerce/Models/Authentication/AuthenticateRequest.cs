using System.ComponentModel.DataAnnotations;

namespace BetCommerce.Models.Authentication
{
    public class AuthenticateRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}