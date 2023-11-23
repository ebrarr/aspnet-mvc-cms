using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Web.Models.Dto
{
    public class ResetPasswordDto 
    {
        [Required]
        public string Token { get; set; }

        [Required, MinLength(1)]
        public string Password { get; set; }
        [Required, MinLength(1)]
        public string NewPassword { get; set; } // Yeni şifreyi ekleyin
    }
}
