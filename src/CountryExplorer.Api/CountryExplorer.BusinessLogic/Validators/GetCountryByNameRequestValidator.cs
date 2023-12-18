using CountryExplorer.BusinessLogic.Models.Requests;
using FluentValidation;

namespace CountryExplorer.BusinessLogic.Validators
{
	public class GetCountryByNameRequestValidator : AbstractValidator<GetCountryByNameRequest>
	{
		public GetCountryByNameRequestValidator()
		{
			RuleFor(e => e.Name).NotEmpty();
		}
	}
}
