using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

public void ConfigureServices(IServiceCollection services)
{
	services.AddDbContext<CosmosDbContext>();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
	if (env.IsDevelopment())
	{
		app.UseDeveloperExceptionPage();
	}

	app.UseHttpsRedirection();

	app.UseRouting();

	app.UseAuthorization();

	app.UseEndpoint(endpoints =>
	{
		endpoints.MapControllers();
	});
}
