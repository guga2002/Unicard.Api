using System.ComponentModel.DataAnnotations;

namespace GA.UniCard.Domain.Identity.HelperModels
{
    public class TokenRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
