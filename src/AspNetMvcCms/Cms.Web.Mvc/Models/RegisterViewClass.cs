using System.ComponentModel.DataAnnotations;

namespace Cms.Web.Mvc.Models
{
	public class RegisterViewModel
	{
		[Required, EmailAddress]
		public string Email { get; set; }
	}
}
