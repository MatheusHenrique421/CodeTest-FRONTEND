using CodeTest_FRONTEND.Dto.Usuario;

namespace CodeTest_FRONTEND.Service.Interfaces;

public interface IUsuarioService
{
	Task<List<UsuarioDto>> ObterUsuarios();
	Task<UsuarioDto> ObterUsuariosPorId(Guid id);
	Task<bool> CriarUsuario(UsuarioCreateDto usuario);
	Task<bool> AlterarUsuario(Guid id, UsuarioUpdateDto usuario); // novo método
}
