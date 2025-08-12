﻿namespace CodeTest_FRONTEND.Models.Usuario
{
	public class UsuarioViewModel
	{
		public Guid Id { get; set; }
		public string? Nome { get; set; }
		public string? Email { get; set; }
		public string? Role { get; set; }
		public DateTime? DataCriacao { get; set; }
	}
}
