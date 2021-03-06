using MultiAdmin.Features.Attributes;

namespace MultiAdmin.Features
{
	[Feature]
	internal class RestartNextRound : Feature, ICommand, IEventRoundEnd
	{
		private bool restart;

		public RestartNextRound(Server server) : base(server)
		{
		}

		public string GetCommandDescription()
		{
			return "Restarts the server at the end of this round [Requires Modding]";
		}


		public void OnCall(string[] args)
		{
			Server.Write("Server will restart next round");
			restart = true;
		}

		public bool PassToGame()
		{
			return false;
		}

		public string GetCommand()
		{
			return "RESTARTNEXTROUND";
		}

		public string GetUsage()
		{
			return "";
		}

		public void OnRoundEnd()
		{
			if (!restart) return;

			Server.SoftRestartServer();
			restart = false;
		}

		public override void Init()
		{
			restart = false;
		}

		public override string GetFeatureDescription()
		{
			return "Restarts the server after the current round ends [Requires Modding]";
		}

		public override string GetFeatureName()
		{
			return "Restart Next Round";
		}

		public override void OnConfigReload()
		{
		}
	}
}
