namespace CountryExplorer.BusinessLogic.Handlers.Core
{
	public record HandlerOptions
	{
		public string? LoggedInUser { get; }
		public string IpAddress { get; }
		public CancellationToken CancellationToken { get; }

		public static HandlerOptions Default => new();

		private HandlerOptions()
		{
			LoggedInUser = "automation";
			IpAddress = "127.0.0.1";
			CancellationToken = CancellationToken.None;
		}

		public HandlerOptions(string? loggedInUser, string ipAddress, CancellationToken ct)
		{
			LoggedInUser = loggedInUser;
			IpAddress = ipAddress;
			CancellationToken = ct;
		}
	}
}
