using CodeTest_FRONTEND.Dto;
using CodeTest_FRONTEND.Service.Interfaces;
using System.Text.Json;

namespace CodeTest_FRONTEND.Service.Services;

public class RandomUserService /*: IRandomUserService*/
{
	private readonly HttpClient _httpClient;
	public RandomUserService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	//public class UserResponse
	//{
	//	public List<UserDto> Users { get; set; }
	//}

	//public async Task<List<UserDto>> GetAllUsers()
	//{
	//	var response = await _httpClient.GetAsync("users");
	//	response.EnsureSuccessStatusCode();

	//	var content = await response.Content.ReadAsStringAsync();

	//	var result = JsonSerializer.Deserialize<UserResponse>(content, new JsonSerializerOptions
	//	{
	//		PropertyNameCaseInsensitive = true
	//	});

	//	return result.Users;
	//}
}
