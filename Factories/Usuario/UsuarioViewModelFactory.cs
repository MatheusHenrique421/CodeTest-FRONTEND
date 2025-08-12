using CodeTest_FRONTEND.Dto.Usuario;
using CodeTest_FRONTEND.Models.Usuario;

namespace CodeTest_FRONTEND.Factories.User;

public class UsuarioViewModelFactory
{
	public static UsuarioViewModel Create(UsuarioViewModel dto)
	{
		return new UsuarioViewModel
		{
			Nome = $"{dto.Nome}",
			Email = dto.Email,
			Role = dto.Role,
			DataCriacao = dto.DataCriacao
			//DataNascimento = dto.BirthDate,
			//EmailCorporativo = dto.Email.EndsWith("@empresa.com"), // Exemplo de verificação de email corporativo
		};
	}

	public static object CreateList(List<UsuarioViewModel> dtos)
	{
		return dtos.Select(Create).ToList();
	}
}
