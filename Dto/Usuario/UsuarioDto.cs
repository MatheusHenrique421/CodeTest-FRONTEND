namespace CodeTest_FRONTEND.Dto.Usuario;

public class UsuarioDto
{
	public Guid Id { get; set; }
	public string? Nome { get; set; }
	public string? Email { get; set; }
	public string? Role { get; set; }
}

public class UsuarioCreateDto
{
	public required string Nome { get; set; }
	public required string Email { get; set; }
	public required string Senha { get; set; }
}

public class UsuarioUpdateDto
{
	public Guid Id { get; set; }
	public string? Nome { get; set; }
	public string? Email { get; set; }
}
