using CodeTest_FRONTEND.Extensions;
using CodeTest_FRONTEND.Service.Interfaces;
using CodeTest_FRONTEND.Service.Services;
using NToastNotify;

namespace CodeTest_FRONTEND
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//// Add services to the container.
			//builder.Services.AddControllersWithViews();

			////Usando NToastNotify
			//builder.Services.AddControllersWithViews()
			//.AddNToastNotifyToastr(new ToastrOptions
			//{
			//	ProgressBar = true,
			//	PositionClass = ToastPositions.TopRight,
			//	PreventDuplicates = true
			//});


			//builder.Services.AddHttpClient<IRandomUserService, RandomUserService>(client =>
			//{
			//	client.BaseAddress = new Uri("https://dummyjson.com/");
			//});

			// Configurar serviços
			builder.Services.ConfigureServices();

			var app = builder.Build();

			// Configurar pipeline
			app.ConfigurePipeline();

			//// Configure the HTTP request pipeline.
			//if (!app.Environment.IsDevelopment())
			//{
			//	app.UseExceptionHandler("/Home/Error");
			//	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			//	app.UseHsts();
			//}
			////Usando NToastNotify
			//app.UseNToastNotify();

			//app.UseHttpsRedirection();
			//app.UseStaticFiles();

			//app.UseRouting();

			//app.UseAuthorization();

			//app.MapControllerRoute(
			//	name: "default",
			//	pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
