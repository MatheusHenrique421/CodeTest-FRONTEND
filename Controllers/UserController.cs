using CodeTest_FRONTEND.Service.Interfaces;
using CodeTest_FRONTEND.Factories.User;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CodeTest_FRONTEND.Controllers
{
	public class UserController : Controller
	{
		private readonly IToastNotification _toastNotification;
		private readonly IRandomUserService _userService;
		public UserController(IRandomUserService userService, IToastNotification toastNotification)
		{
			_userService = userService;
			_toastNotification = toastNotification;
		}

		public async Task<IActionResult> Index()
		{
			var userDtos = await _userService.GetAllUsers();
			var viewModels = UserViewModelFactory.CreateList(userDtos);
			_toastNotification.AddSuccessToastMessage("Usuário Listados com sucesso!");

			return View(viewModels);
		}
	}
}
