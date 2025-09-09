using CodeTest_FRONTEND.Service.Interfaces;
using CodeTest_FRONTEND.Service.Services;
using System.Net.Http.Headers;
using NToastNotify;

namespace CodeTest_FRONTEND.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection ConfigureServices(this IServiceCollection services)
		{
			// Add  Controllers
			services.AddControllersWithViews();

			// Toast notifications
			services.ConfigureNToast();

			// Configurar HttpClients
			services.ConfigureHttpClients();

			// Authentication
			services.ConfigureAuthentication();

			return services;
		}

		private static IServiceCollection ConfigureNToast(this IServiceCollection services)
		{
			services.AddControllersWithViews()
				.AddNToastNotifyToastr(new ToastrOptions
				{
					ProgressBar = true,
					PositionClass = ToastPositions.TopRight,
					PreventDuplicates = true
				});

			return services;
		}

		private static IServiceCollection ConfigureHttpClients(this IServiceCollection services)
		{
			// agora você usa o método genérico
			services.AddApiService<IUsuarioService, UsuarioService>();
			services.AddApiService<IPessoaService, PessoaService>();

			return services;
			//services.AddHttpClient<IUsuarioService, UsuarioService>(client =>
			//{
			//	client.BaseAddress = new Uri("https://localhost:7011/api/"); // URL base da sua API
			//	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			//});

			//return services;
		}

		// 🔹 Aqui está o helper genérico
		private static IServiceCollection AddApiService<TInterface, TImplementation>(this IServiceCollection services) where TInterface : class where TImplementation : class, TInterface
		{
			services.AddHttpClient<TInterface, TImplementation>(client =>
			{
				client.BaseAddress = new Uri("https://localhost:7011/api/");
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			});

			return services;
		}
	}
}