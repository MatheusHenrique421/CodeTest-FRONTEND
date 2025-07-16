using Microsoft.AspNetCore.Authentication.Cookies;

namespace CodeTest_FRONTEND.Extensions
{
	public static class ApplicationExtensions
	{

		public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
		{
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					// Rota para onde será redirecionado se o usuário não estiver autenticado
					options.LoginPath = "/Account/Login";

					// Rota para onde será redirecionado após logout
					options.LogoutPath = "/Account/Logout";

					// Rota para onde será redirecionado se ele não tiver permissão de acesso
					options.AccessDeniedPath = "/Account/Login";

					// Tempo de expiração do cookie (opcional)
					options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

					// Manter o cookie renovado se o usuário estiver ativo
					options.SlidingExpiration = true;
				});

			return services;
		}

		public static WebApplication ConfigurePipeline(this WebApplication app)
		{
			// Configurar pipeline baseado no ambiente
			if (!app.Environment.IsDevelopment())
			{
				app.ConfigureProductionPipeline();
			}
			else
			{
				app.ConfigureDevelopmentPipeline();
			}

			// Configurar middlewares comuns
			app.ConfigureCommonMiddlewares();

			// Configurar roteamento
			app.ConfigureRouting();

			return app;
		}

		private static WebApplication ConfigureProductionPipeline(this WebApplication app)
		{
			app.UseExceptionHandler("/Home/Error");
			app.UseHsts();

			return app;
		}

		private static WebApplication ConfigureDevelopmentPipeline(this WebApplication app)
		{
			// Configurações específicas para desenvolvimento podem ser adicionadas aqui
			return app;
		}

		private static WebApplication ConfigureCommonMiddlewares(this WebApplication app)
		{
			// NToast middleware
			app.UseNToastNotify();

			// Middlewares padrão
			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			return app;
		}

		private static WebApplication ConfigureRouting(this WebApplication app)
		{
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			return app;
		}
	}
}
