using CodeTest_FRONTEND.Models.Pessoa;

namespace CodeTest_FRONTEND.Service.Interfaces
{
	public interface IPessoaService
	{
		Task<List<PessoaViewModel>> ObterPessoas();
		Task<PessoaViewModel> ObterPessoaPorId(Guid id);
		Task<bool> CriarPessoa(PessoaViewModel pessoa);
		Task<bool> AlterarPessoa(Guid id, PessoaViewModel pessoa); 
	}
}
