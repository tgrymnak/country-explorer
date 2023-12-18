using CountryExplorer.Api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CountryExplorer.Api.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public abstract class BaseApiController : ControllerBase
	{
		protected string? LoggedInUser => User.Identity?.Name;
		protected string IpAddress => HttpContext.GetIpAddress();

		protected IActionResult ToActionResult(int code, object? result)
		{
			return code switch
			{
				StatusCodes.Status400BadRequest => BadRequest(result),
				StatusCodes.Status404NotFound => NotFound(result),
				StatusCodes.Status401Unauthorized => Unauthorized(result),
				StatusCodes.Status200OK => Ok(result),
				_ => StatusCode(StatusCodes.Status500InternalServerError, result)
			};
		}
	}
}
