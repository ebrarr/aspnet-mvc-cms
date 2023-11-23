using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Web.Data.Entities
{
	public class RoleEntity : EntityBase
	{
		

		[Required, MaxLength(10)]
		public string Name { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress, MaxLength(100)] // MaxLength değerini artırabilirsiniz
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
