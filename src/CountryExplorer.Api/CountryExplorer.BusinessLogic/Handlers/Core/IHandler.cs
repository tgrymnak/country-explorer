namespace CountryExplorer.BusinessLogic.Handlers.Core
{
	public interface IHandler<TRequest, TResponse>
	{
		Task<HandlerResponse<TResponse>> Handle(TRequest request, HandlerOptions options);
	}
}
