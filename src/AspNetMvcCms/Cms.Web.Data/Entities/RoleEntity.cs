﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Web.Data.Entities
{
	public class RoleEntity : EntityBase
	{
		[Key] // Primary key annotation ekleyin
		public int Id { get; set; }

		[Required, MaxLength(10)]
		public string Name { get; set; }
	}
}
