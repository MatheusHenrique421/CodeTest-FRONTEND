namespace CodeTest_FRONTEND.ViewModel
{
	public class UserViewModel
	{
		public int Id { get; set; }
		public string? NomeCompleto { get; set; }
		public string? Email { get; set; }
		public string? DataNascimento { get; set; } // <- origem bruta da data (do DTO)

		public DateTime? BirthDate
		{
			get
			{
				if (DateTime.TryParse(DataNascimento, out var result))
					return result;
				return null;
			}
		}
		public string DataNascimentoFormatada => BirthDate?.ToString("dd/MM/yyyy") ?? "-";
		public bool EmailCorporativo { get; set; }
	}
}
