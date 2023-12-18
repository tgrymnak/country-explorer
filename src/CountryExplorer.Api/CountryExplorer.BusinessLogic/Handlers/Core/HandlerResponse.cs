using CountryExplorer.BusinessLogic.Constants;
using FluentValidation.Results;

namespace CountryExplorer.BusinessLogic.Handlers.Core
{
	public record HandlerResponse<TResult>
	{
		public TResult? Result { get; set; }
		public ValidationResult ValidationResult { get; set; }

		public HandlerResponse(TResult result)
		{
			ValidationResult = new ValidationResult();
			Result = result;
		}

		public HandlerResponse(ValidationResult validationResult)
		{
			ValidationResult = validationResult;
		}

		public HandlerResponse(params ValidationFailure[] failures)
		{
			ValidationResult = new ValidationResult();
			ValidationResult.Errors.AddRange(failures);
		}

		public static HandlerResponse<TResult> Error500(Exception exception)
		{
			return new HandlerResponse<TResult>(new ValidationFailure
			{
				ErrorCode = StatusCode.Status500InternalServerError,
				ErrorMessage = $"Server Error. {exception.Message}"
			});
		}

		public static HandlerResponse<TResult> Error401(string message)
		{
			return new HandlerResponse<TResult>(new ValidationFailure
			{
				ErrorCode = StatusCode.Status401Unauthorized,
				ErrorMessage = message
			});
		}

		public static HandlerResponse<TResult> Error400(string message)
		{
			return new HandlerResponse<TResult>(new ValidationFailure
			{
				ErrorCode = StatusCode.Status400BadRequest,
				ErrorMessage = message
			});
		}

		public void Deconstruct(out int code, out object? result)
		{
			if (ValidationResult.IsValid)
			{
				(code, result) = (StatusCode.Status200OK, Result);
			}
			else
			{
				var badRequest = ValidationResult.Errors.FirstOrDefault(e => e.ErrorCode == StatusCode.Status400BadRequest);
				var notFound = ValidationResult.Errors.FirstOrDefault(e => e.ErrorCode == StatusCode.Status404NotFound);
				var unauthorized = ValidationResult.Errors.FirstOrDefault(e => e.ErrorCode == StatusCode.Status401Unauthorized);
				var serverError = ValidationResult.Errors.FirstOrDefault(e => e.ErrorCode == StatusCode.Status500InternalServerError);
				if (badRequest != null)
				{
					(code, result) = (StatusCode.Status400BadRequest, badRequest.ErrorMessage);
				}
				else if (notFound != null)
				{
					(code, result) = (StatusCode.Status404NotFound, notFound.ErrorMessage);
				}
				else if (unauthorized != null)
				{
					(code, result) = (StatusCode.Status401Unauthorized, unauthorized.ErrorMessage);
				}
				else if (serverError != null)
				{
					(code, result) = (StatusCode.Status500InternalServerError, serverError.ErrorMessage);
				}
				else
				{
					(code, result) = (StatusCode.Status500InternalServerError, ValidationResult.Errors.FirstOrDefault());
				}
			}
		}

		public bool IsValid => ValidationResult?.IsValid ?? true;
	}
}
