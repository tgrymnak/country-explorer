namespace CountryExplorer.Api.Extensions
{
	internal static class HttpContextExtensions
	{
		public static string GetIpAddress(this HttpContext httpContext)
		{
#if DEBUG
			return "127.0.0.1";
#else
			return httpContext.Request.Headers.ContainsKey("X-Forwarded-For")
				? (string)httpContext.Request.Headers["X-Forwarded-For"]
				: httpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
#endif
		}
	}
}
