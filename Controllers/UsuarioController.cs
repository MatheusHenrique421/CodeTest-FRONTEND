using CodeTest_FRONTEND.Service.Interfaces;
using CodeTest_FRONTEND.Service.Exceptions;
using CodeTest_FRONTEND.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Reflection;
using AspNetCoreGeneratedDocument;
using CodeTest_FRONTEND.Models.Steps;
using CodeTest_FRONTEND.Factories;

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
				var usuarios = await _usuarioService.ObterUsuarios();
				var viewModels = UsuarioFactory.CriaLista(usuarios);
				_toastNotification.AddSuccessToastMessage("Usuários listados com sucesso!");

				return View(viewModels);

			}
			catch (ApiIndisponivelException ex)
			{
				// Você pode logar o erro
				_logger.LogError(ex, "Erro ao buscar usuários na API. 123, 456 tiruriburio");

				// Redireciona para uma tela de erro amigável
				return View("ErrorApi", ex.Message);
			}
		}

		// GET: Usuario/Cadastrar
		[HttpGet]
		public IActionResult Cadastrar()
		{
			ViewBag.Step = 1;
			var steps = new CadastroStepsViewModel
			{
				CurrentStep = 1,
				Steps = new List<StepLinkViewModel>
				{
					new StepLinkViewModel { Step = 1, Label = "Usuário", Controller = "Usuario", Action = "Cadastrar" },
					new StepLinkViewModel { Step = 2, Label = "Pessoa", Controller = "Pessoa", Action = "Cadastrar" },
					new StepLinkViewModel { Step = 3, Label = "Endereço", Controller = "Endereco", Action = "Cadastrar" }
				}
			};
			ViewData["FormAction"] = "Cadastrar";
			return View();
		}

		// POST: Usuario/Cadastrar
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Cadastrar(UsuarioViewModel model)
		{
			if (model == null)
			{
				return View(model); // volta mostrando os erros de validação
			}

			try
			{
				var usuario = UsuarioFactory.ConverteDto(model); // converte ViewModel → DTO/Entidade

				await _usuarioService.CriarUsuario(usuario);

				_toastNotification.AddSuccessToastMessage("Usuário cadastrado com sucesso!");

				//return RedirectToAction(nameof(Cadastrar));
				// aqui já manda para Pessoa
				return RedirectToAction("Cadastrar", "Pessoa", new { currentStep = 2 });
			}
			catch (ApiIndisponivelException ex)
			{
				_logger.LogError(ex, "Erro ao cadastrar usuário na API");

				_toastNotification.AddErrorToastMessage("Erro ao cadastrar usuário!");
				return View(model);
			}
		}

		//GET: Usuario/Editar
		public async Task<IActionResult> Editar(Guid id)
		{
			if (id == Guid.Empty)
				_toastNotification.AddErrorToastMessage("Sem id, verifique");

			try
			{
				var usuario = await _usuarioService.ObterUsuariosPorId(id);

				if (usuario == null)
				{
					_toastNotification.AddWarningToastMessage("Usuário não encontrado!");
					return View("Editar", new UsuarioViewModel());
				}

				var viewModel = UsuarioFactory.ConverteViewModel(usuario); // converte DTO/Entidade → ViewModel
																		   // Para editar
				ViewData["FormAction"] = "Editar";
				return View("Editar", viewModel);
			}
			catch (ApiIndisponivelException ex)
			{
				_logger.LogError(ex, "Erro ao buscar usuário na API");

				_toastNotification.AddErrorToastMessage("Erro ao buscar usuário, para editar!");
				return RedirectToAction(nameof(Index));
			}
		}

		// POST: Usuario/Editar/{id}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(Guid id, UsuarioViewModel model)
		{
			if (id != model.Id)
			{
				_toastNotification.AddErrorToastMessage("Usuário inválido.");
				return RedirectToAction(nameof(Index));
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				var usuario = UsuarioFactory.ConverteDtoParaAtualizar(model); // ViewModel → DTO

				await _usuarioService.AlterarUsuario(id, usuario!);

				_toastNotification.AddSuccessToastMessage("Usuário atualizado com sucesso!");
				return RedirectToAction(nameof(Index));
			}
			catch (ApiIndisponivelException ex)
			{
				_logger.LogError(ex, "Erro ao atualizar usuário");
				_toastNotification.AddErrorToastMessage("Erro ao atualizar usuário!");
				return View(model);
			}
		}
	}
}
