using CodeTest_FRONTEND.Dto.Usuario;
using CodeTest_FRONTEND.Models.Usuario;

namespace CodeTest_FRONTEND.Service.Interfaces;

public interface IUsuarioService
{
	Task<List<UsuarioViewModel>> ObterUsuariosAsync();
	Task<bool> CriarUsuarioAsync(UsuarioDto usuario);
}
