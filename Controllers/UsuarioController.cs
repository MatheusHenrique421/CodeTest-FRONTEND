using CodeTest_FRONTEND.Service.Interfaces;
using CodeTest_FRONTEND.Factories.User;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using CodeTest_FRONTEND.Service.Exceptions;

namespace CodeTest_FRONTEND.Controllers
{
	public class UsuarioController : Controller
	{
		private readonly IToastNotification _toastNotification;
		private readonly IUsuarioService _usuarioService;
		private readonly ILogger<UsuarioController> _logger;
		public UsuarioController(IUsuarioService usuarioService, IToastNotification toastNotification, ILogger<UsuarioController> logger)
		{
			_logger = logger;
			_usuarioService = usuarioService;
			_toastNotification = toastNotification;
		}

		public async Task<IActionResult> Index()
		{
			try
			{
				var usuarios = await _usuarioService.ObterUsuariosAsync();
				var viewModels = UsuarioViewModelFactory.CreateList(usuarios);
				_toastNotification.AddSuccessToastMessage("Usuários listados com sucesso!");

				return View(usuarios);

			}
			catch (ApiIndisponivelException ex)
			{
				// Você pode logar o erro
				_logger.LogError(ex, "Erro ao buscar usuários na API. 123, 456 tiruriburio");

				// Redireciona para uma tela de erro amigável
				return View("ErrorApi", ex.Message);
			}

		}
	}
}
