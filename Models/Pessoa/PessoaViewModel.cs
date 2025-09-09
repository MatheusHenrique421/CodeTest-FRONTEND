using System.ComponentModel.DataAnnotations;

namespace CodeTest_FRONTEND.Models.Pessoa
{
	public class PessoaViewModel
	{
		public Guid Id { get; set; }

		[Required(ErrorMessage = "O nome é obrigatório.")]
		[StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
		public string? Nome { get; set; }

		[Required(ErrorMessage = "O Sobrenome é obrigatório.")]
		[StringLength(100, ErrorMessage = "O sobrenome  deve ter no máximo 100 caracteres.")]
		public string? Sobrenome { get; set; }
	}
}
