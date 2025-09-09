using CodeTest_FRONTEND.Models.Usuario;
using CodeTest_FRONTEND.Dto.Usuario;

namespace CodeTest_FRONTEND.Factories;

public class UsuarioFactory
{
	// ViewModel → DTO
	public static UsuarioCreateDto ConverteDto(UsuarioViewModel vm) =>
		new UsuarioCreateDto
		{
			Nome = vm.Nome!,
			Email = vm.Email!,
			Senha = vm.Senha!
		};

	// ViewModel → DTO
	public static UsuarioUpdateDto ConverteDtoParaAtualizar(UsuarioViewModel vm) =>
		new UsuarioUpdateDto
		{
			Id = vm.Id!,
			Nome = vm.Nome!,
			Email = vm.Email!,
			Senha = vm.Senha!
		};

	// DTO → ViewModel
	public static UsuarioViewModel ConverteViewModel(UsuarioDto dto)
	{
		return new UsuarioViewModel
		{
			Id = dto.Id,
			Nome = $"{dto.Nome}",
			Email = dto.Email,
			Senha = dto.Senha,
			Role = dto.Role,

			DataCriacao = dto.DataCriacao
		};
	}

	public static List<UsuarioViewModel> CriaLista(IEnumerable<UsuarioDto> dtos)
	{
		return dtos.Select(ConverteViewModel).ToList();
	}
}
