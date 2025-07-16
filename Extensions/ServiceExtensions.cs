using CodeTest_FRONTEND.Service.Interfaces;
using CodeTest_FRONTEND.Service.Services;
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
			services.AddHttpClient<IRandomUserService, RandomUserService>(client =>
			{
				client.BaseAddress = new Uri("https://dummyjson.com/");
			});

			return services;
		}
	}
}