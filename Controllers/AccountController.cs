using CodeTest_FRONTEND.Models.Login;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using NToastNotify;
using CodeTest_FRONTEND.Extensions;
using CodeTest_FRONTEND.Enums;

namespace CodeTest_FRONTEND.Controllers
{
	public class AccountController : Controller
	{
		private readonly IToastNotification _toastNotification;
		public AccountController(IToastNotification toastNotification)
		{
			_toastNotification = toastNotification;
		}
		// Exibe o formulário de login
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		// Processa o login
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			// Exemplo de validação fictícia
			if (model.Email == "admin@admin.com" && model.Senha == "123")
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, model.Email),
					new Claim(ClaimTypes.Role, "Usuario")
				};

				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

				_toastNotification.AddCustomToast(ToastTypeEnum.Success, "Sucesso!", "Login realizado com sucesso");
				return RedirectToAction("Index", "Home");
			}


			_toastNotification.AddCustomToast(ToastTypeEnum.Error, "Erro!", "Usuário ou senha inválidos, verifique e tente novamente.");
			ModelState.AddModelError("", "Usuário ou senha inválidos");
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Account");
		}
	}
}
