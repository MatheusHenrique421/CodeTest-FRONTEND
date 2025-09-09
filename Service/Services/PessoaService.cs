using CodeTest_FRONTEND.Dto.Usuario;
using CodeTest_FRONTEND.Models.Pessoa;
using CodeTest_FRONTEND.Service.Exceptions;
using CodeTest_FRONTEND.Service.Interfaces;
using Newtonsoft.Json;

namespace CodeTest_FRONTEND.Service.Services
{
	public class PessoaService : IPessoaService
	{
		private readonly ILogger<PessoaService> _logger;
		private readonly HttpClient _httpClient;
		public PessoaService(HttpClient httpClient, ILogger<PessoaService>logger)
		{
			_httpClient = httpClient;
			_logger = logger;
		}

		public async Task<List<PessoaViewModel>> ObterPessoas()
		{
			try
			{
				var response = await _httpClient.GetAsync("pessoa/BuscarTodas");
				response.EnsureSuccessStatusCode();

				var json = await response.Content.ReadAsStringAsync();
				var pessoas = JsonConvert.DeserializeObject<List<PessoaViewModel>>(json);
				return pessoas;
			}
			catch (HttpRequestException ex)
			{
				_logger.LogError(ex, "Erro ao buscar pessoas.");
				// Erro de conexão com API
				throw new ApiIndisponivelException("Não foi possível conectar à API.", ex);
			}
			catch (TaskCanceledException ex)
			{
				// Timeout
				throw new ApiIndisponivelException("A API demorou demais para responder.", ex);
			}
		}

		public Task<PessoaViewModel> ObterPessoaPorId(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> CriarPessoa(PessoaViewModel pessoa)
		{
			throw new NotImplementedException();
		}

		public Task<bool> AlterarPessoa(Guid id, PessoaViewModel pessoa)
		{
			throw new NotImplementedException();
		}
	}
}
