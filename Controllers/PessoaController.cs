using CodeTest_FRONTEND.Factories;
using CodeTest_FRONTEND.Models.Pessoa;
using CodeTest_FRONTEND.Models.Steps;
using CodeTest_FRONTEND.Service.Exceptions;
using CodeTest_FRONTEND.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CodeTest_FRONTEND.Controllers
{
	public class PessoaController : Controller
	{
		private readonly IPessoaService _pessoaService;
		private readonly ILogger<PessoaController> _logger;
		private readonly IToastNotification _toastNotification;

		public PessoaController(IPessoaService pessoaService, ILogger<PessoaController> logger, IToastNotification toastNotification)
		{
			_pessoaService = pessoaService;
			_logger = logger;
			_toastNotification = toastNotification;
		}

		// GET: Pessoa/Cadastrar
		public IActionResult Cadastrar(int currentStep = 2)
		{
			ViewBag.Step = currentStep;

			var steps = new CadastroStepsViewModel
			{
				CurrentStep = currentStep,
				Steps = new List<StepLinkViewModel>
			{
				new StepLinkViewModel { Step = 1, Label = "Usuário", Controller = "Usuario", Action = "Cadastrar" },
				new StepLinkViewModel { Step = 2, Label = "Pessoa", Controller = "Pessoa", Action = "Cadastrar" },
				new StepLinkViewModel { Step = 3, Label = "Endereço", Controller = "Endereco", Action = "Cadastrar" }
			}
			};

			ViewData["FormAction"] = "Cadastrar";

			return View(new PessoaViewModel());
		}

		// POST: Pessoa/Cadastrar
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Cadastrar(PessoaViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				//var pessoa = PessoaFactory.ConverteDto(model);

				await _pessoaService.CriarPessoa(model);

				_toastNotification.AddSuccessToastMessage("Pessoa cadastrada com sucesso!");

				// redireciona para próximo passo → Endereço
				return RedirectToAction("Cadastrar", "Endereco", new { currentStep = 3 });
			}
			catch (ApiIndisponivelException ex)
			{
				_logger.LogError(ex, "Erro ao cadastrar pessoa na API");

				_toastNotification.AddErrorToastMessage("Erro ao cadastrar pessoa!");
				return View(model);
			}
		}
	}

}
