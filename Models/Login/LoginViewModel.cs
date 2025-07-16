using System.ComponentModel.DataAnnotations;

namespace CodeTest_FRONTEND.Models.Login
{
	public class LoginViewModel
	{
		[Required]
		public string? Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string? Senha { get; set; }
	}
}
