using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;

namespace CountryExplorer.BusinessLogic.Handlers.Core
{
	internal abstract class BaseHandler
	{
		private readonly IServiceProvider _serviceProvider;

		protected BaseHandler(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		protected async Task<ValidationResult> Validate<TRequest>(TRequest request, CancellationToken ct = default)
		{
			using var scope = _serviceProvider.CreateScope();
			var validator = scope.ServiceProvider.GetRequiredService<IValidator<TRequest>>();
			return await validator.ValidateAsync(request, ct);
		}
	}
}
