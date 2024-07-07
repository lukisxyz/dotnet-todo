using Microsoft.OpenApi.Models;

namespace Todo.Api
{
    public class Startup
    {

        public Startup(IConfiguration conf)
        {
            Configuration = conf;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection svc)
        {
            svc.AddSingleton<DataSource>();
            svc.AddControllers();
            svc.AddEndpointsApiExplorer();
            svc.AddSwaggerGen((c) =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Todo.Api",
                    Version = "v1",
                });
            });
            svc.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }
    }

}
