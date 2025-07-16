using CodeTest_FRONTEND.Enums;
using NToastNotify;

namespace CodeTest_FRONTEND.Extensions
{
	public static class ToastNotificationExtensions
	{
		public static void AddCustomToast(this IToastNotification toast, ToastTypeEnum tipo, string titulo, string mensagem)
		{
			var opcoes = new ToastrOptions
			{
				Title = titulo,
				ProgressBar = true,
				PreventDuplicates = true,
				PositionClass = ToastPositions.TopRight
			};

			switch (tipo)
			{
				case ToastTypeEnum.Error:
					toast.AddErrorToastMessage(mensagem, opcoes);
					break;
				case ToastTypeEnum.Success:
					toast.AddSuccessToastMessage(mensagem, opcoes);
					break;
				case ToastTypeEnum.Info:
					toast.AddInfoToastMessage(mensagem, opcoes);
					break;
				case ToastTypeEnum.Warning:
					toast.AddWarningToastMessage(mensagem, opcoes);
					break;
				default:
					toast.AddInfoToastMessage(mensagem, opcoes);
					break;
			}
		}
	}
}
