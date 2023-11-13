using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Models.Dto
{
    public class LoginDto
    {
        [Required, MinLength(1), EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(1)]
        public string Password { get; set; }
    }
}
