using CodeTest_FRONTEND.ViewModel;
using CodeTest_FRONTEND.Dto;

namespace CodeTest_FRONTEND.Factories.User
{
	public class UserViewModelFactory
	{
		public static UserViewModel Create(UserDto dto)
		{
			return new UserViewModel
			{
				NomeCompleto = $"{dto.FirstName} {dto.LastName}",
				Email = dto.Email,
				DataNascimento = dto.BirthDate,
				EmailCorporativo = dto.Email.EndsWith("@empresa.com")
			};
		}

		public static List<UserViewModel> CreateList(List<UserDto> dtos)
		{
			return dtos.Select(Create).ToList();
		}
	}
}
