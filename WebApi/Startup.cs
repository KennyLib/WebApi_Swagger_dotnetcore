using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(c =>
        c.Conventions.Add(new ApiExplorerGroupPerVersionConvention())
                           );
            services.AddSwaggerGen(options => {

                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = " API 文档",
                    Description = "by bj Kenny",
                    Contact = new Contact
                    {
                        Name = "Kenny Developer",
                        Email = "KennyLib@foxmail.com"
                    },
                    License = new License
                    {
                        Name = "Apache 2.0",
                        Url = "http://www.apache.org/licenses/LICENSE-2.0.html"
                    }
                });
                options.SwaggerDoc("v2", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v2",
                    Title = " API 文档",
                    Description = "by bj Kenny",
                    Contact = new Contact
                    {
                        Name = "Kenny Developer",
                        Email = "KennyLib@foxmail.com"
                    },
                    License = new License
                    {
                        Name = "Apache 2.0",
                        Url = "http://www.apache.org/licenses/LICENSE-2.0.html"
                    }
                });

                //ApiKeyScheme/BasicAuthScheme/OAuth2Scheme/SecurityScheme
                //options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                //{
                // //Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                // Name = "Authorization",
                // In = "header",
                // Type = "apiKey"
                //});
                // options.OperationFilter<HttpHeaderFilter>();

            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");

                c.SwaggerEndpoint("/swagger/v2/swagger.json", "V2 Docs");
            });

        }
    }
}
