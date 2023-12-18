using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryExplorer.Infrastructure.Logging
{
	internal static class LogMessages
	{
		/// <summary>
		/// Country messages
		/// </summary>
		public const string GetCountryByNameMessageFormat = "retrieve country {name} details";
		public const string GetCountriesMessageFormat = "retrieve countries";

		public static void LogAttempt(this ILogger logger, string format, params object[] args)
		{
			logger.LogInformation($"Trying to {format}", args);
		}

		public static void LogSucceed(this ILogger logger, string format, params object[] args)
		{
			logger.LogInformation($"Succeed to {format}", args);
		}

		public static void LogUnable(this ILogger logger, string format, params object[] args)
		{
			logger.LogWarning($"Unable to {format}", args);
		}

		public static void LogFailed(this ILogger logger, Exception exception, string format, params object[] args)
		{
			logger.LogError(exception, $"Failed to {format}", args);
		}
	}
}
