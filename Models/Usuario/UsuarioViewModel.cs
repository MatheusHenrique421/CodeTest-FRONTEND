using System.ComponentModel.DataAnnotations;

namespace CodeTest_FRONTEND.Models.Usuario
{
	public class UsuarioViewModel
	{
		public Guid Id { get; set; }

		[Required(ErrorMessage = "O nome é obrigatório.")]
		[StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
		public string? Nome { get; set; }

		[Required(ErrorMessage = "O e-mail é obrigatório.")]
		[EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "A senha é obrigatória.")]
		[StringLength(20, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 20 caracteres.")]
		public string? Senha { get; set; }
		public string? Role { get; set; }
		public DateTime? DataCriacao { get; set; }
	}
}
