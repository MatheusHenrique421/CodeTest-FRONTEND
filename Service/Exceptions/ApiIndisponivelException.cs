namespace CodeTest_FRONTEND.Service.Exceptions;

public class ApiIndisponivelException : Exception
{
	public ApiIndisponivelException(string mensagem, Exception innerException) : base(mensagem, innerException)
	{

	}
}