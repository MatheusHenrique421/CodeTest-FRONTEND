namespace CodeTest_FRONTEND.Models.Steps
{
	public class CadastroStepsViewModel
	{
		public int CurrentStep { get; set; }
		public List<StepLinkViewModel> Steps { get; set; } = new();
	}
}
