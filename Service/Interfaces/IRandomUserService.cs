using CodeTest_FRONTEND.Dto;
using CodeTest_FRONTEND.ViewModel;

namespace CodeTest_FRONTEND.Service.Interfaces
{
	public interface IRandomUserService
	{
		Task<List<UserDto>> GetAllUsers();
	}
}
