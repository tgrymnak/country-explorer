using CountryExplorer.BusinessLogic.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((ctx, services, config) => config
	.Enrich.FromLogContext()
	.WriteTo.Console()
);
builder.Services.AddBusinessLogic(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddApiVersioning(o =>
{
	o.AssumeDefaultVersionWhenUnspecified = true;
	o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
	o.ReportApiVersions = true;
	o.ApiVersionReader = ApiVersionReader.Combine(
		new UrlSegmentApiVersionReader(),
		new HeaderApiVersionReader("x-api-version"),
		new MediaTypeApiVersionReader("x-api-version"));
});
builder.Services.AddVersionedApiExplorer(options =>
{
	options.GroupNameFormat = "'v'VVV";
	options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddControllers();
builder.Services.AddResponseCaching();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.DefaultModelsExpandDepth(-1);
		foreach (var description in app.Services.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions)
		{
			options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
		}
	});
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
	ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseCors(builder => builder
.WithOrigins("http://localhost:4200")
.WithMethods("OPTIONS", "GET", "POST", "PUT", "DELETE")
.AllowAnyHeader());

app.UseResponseCaching();

app.UseAuthorization();
app.MapControllers();

app.Run();
