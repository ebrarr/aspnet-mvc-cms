﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Web.Data.Entities
{
	public class UserEntity : EntityBase
	{
		public int RoleId { get; set; }
        public int? PolyclinicId { get; set; }

        [Required, MaxLength(50)]
		public string Name { get; set; }

		[Required, MaxLength(50)]
		public string LastName { get; set; }

		[Required, EmailAddress]
		public string Email { get; set; }

		[Required]
		public string PasswordHash { get; set; }

        [Required]
        public string? PasswordReset { get; set; }
        [Required]
        public DateTime? ResetTokenExpires { get; set; }
        public RoleEntity Role { get; set; }
	}
}
