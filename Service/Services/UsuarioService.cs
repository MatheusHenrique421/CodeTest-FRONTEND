using CodeTest_FRONTEND.Service.Exceptions;
using CodeTest_FRONTEND.Service.Interfaces;
using CodeTest_FRONTEND.Dto.Usuario;
using Newtonsoft.Json;
using System.Text;
using CodeTest_FRONTEND.Models.Usuario;

namespace CodeTest_FRONTEND.Service.Services;

public class UsuarioService : IUsuarioService
{
	private readonly HttpClient _httpClient;
	private readonly ILogger<UsuarioService> _logger;

	public UsuarioService(HttpClient httpClient, ILogger<UsuarioService> logger)
	{
		_httpClient = httpClient;
		_logger = logger;
	}

	public async Task<List<UsuarioDto>> ObterUsuarios()
	{
		try
		{
			var response = await _httpClient.GetAsync("usuario/BuscarTodos");
			response.EnsureSuccessStatusCode();

			var json = await response.Content.ReadAsStringAsync();
			var usuarios = JsonConvert.DeserializeObject<List<UsuarioDto>>(json);
			return usuarios;
		}
		catch (HttpRequestException ex)
		{
			_logger.LogError(ex, "Erro ao buscar usuários.");
			// Erro de conexão com API
			throw new ApiIndisponivelException("Não foi possível conectar à API de Usuários.", ex);
		}
		catch (TaskCanceledException ex)
		{
			// Timeout
			throw new ApiIndisponivelException("A API de Usuários demorou demais para responder.", ex);
		}
	}

	public async Task<UsuarioDto> ObterUsuariosPorId(Guid id)
	{
		try
		{
			var response = await _httpClient.GetAsync($"usuario/BuscarPorId/{id}");
			response.EnsureSuccessStatusCode();

			var json = await response.Content.ReadAsStringAsync();
			var usuario = JsonConvert.DeserializeObject<UsuarioDto>(json);

			return usuario;
		}
		catch (HttpRequestException ex)
		{
			_logger.LogError(ex, "Erro ao buscar usuário por ID.");
			throw new ApiIndisponivelException("Não foi possível conectar à API de Usuários.", ex);
		}
		catch (TaskCanceledException ex)
		{
			// Timeout
			throw new ApiIndisponivelException("A API de Usuários demorou demais para responder.", ex);
		}
	}

	// Exemplo de criação de usuário
	public async Task<bool> CriarUsuario(UsuarioCreateDto usuario)
	{
		try
		{
			var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync("usuario/Criar", content);

			var respostaJson = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				_logger.LogError("Erro ao criar usuário: {StatusCode} - {Resposta}", response.StatusCode, respostaJson);
			}
			return response.IsSuccessStatusCode;
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Erro ao criar usuário.");
			return false;
		}
	}

	public async Task<bool> AlterarUsuario(Guid id, UsuarioUpdateDto usuario)
	{
		try
		{
			var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
			var response = await _httpClient.PutAsync($"usuario/Alterar/{id}", content);

			response.EnsureSuccessStatusCode();
			return true;
		}
		catch (HttpRequestException ex)
		{
			_logger.LogError(ex, "Erro ao alterar usuário.");
			throw new ApiIndisponivelException("Não foi possível conectar à API de Usuários.", ex);
		}
		catch (TaskCanceledException ex)
		{
			// Timeout
			throw new ApiIndisponivelException("A API de Usuários demorou demais para responder.", ex);
		}
	}

}
